/*
 * Created by SharpDevelop.
 * User: 广州哇嘎
 * Date: 2021/12/13
 * Time: 10:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace winformTestAll
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        Hashtable voiceList = new Hashtable();

        public static string GetNewsUrl(string jsonPath, string newsName)
        {
            /*
             * 读取json文件，返回新闻 URL
             */

            string jsonString = ReadFile(jsonPath);
            JObject jObject = (JObject)JsonConvert.DeserializeObject(jsonString);
            JObject items = (JObject)jObject["items"];
            JObject news = (JObject)items[newsName];

            string url = "";
            try
            {
                url = news["url"].ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("所选择的源不存在于配置文件中");
            }

            return url;
        }

        public static string ReadFile(string filePath)
        {
            /*
             * 读取文件，以字符串形式返回文件内容
             */
            
            StreamReader reader = new StreamReader(filePath);
            StringBuilder content = new StringBuilder();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                content.Append(line);
            }
            return content.ToString();
        }

        private ArrayList ParseHtml(string htmlString)
        {
            /*
             * 解析 NPR 的 HTML，提取新闻标题、链接、对应的音频链接
             */

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlString);
            var root = doc.DocumentNode;
            var storyList = root.SelectSingleNode("//div[@id='story-list']");
            var articles = storyList.SelectNodes("article");
            ArrayList ret = new ArrayList();
            string year, month, day;

            if (articles != null)
            {
                foreach (var article in articles)
                {
                    NewsInfo news = new NewsInfo();

                    // 解析标题和链接
                    var aTag = article.SelectSingleNode("div/h3/a");
                    string title = aTag.GetDirectInnerText();
                    string url = aTag.GetAttributeValue("href", "none");

                    // 获取 mp3 链接
                    var mp3Tag = article.SelectSingleNode("article/div/div/div/a");
                    string mp3Url = mp3Tag.GetAttributeValue("href", "mp3None");

                    Match m = Regex.Match(url, @"https://www.npr.org/(\d{4})/(\d{2})/(\d{2})/.+");
                    year = m.Groups[1].ToString();
                    month = m.Groups[2].ToString();
                    day = m.Groups[3].ToString();

                    title = $"{year}-{month}-{day}_{title}";
                    news.Title = title;
                    news.Url = url;
                    news.Mp3link = mp3Url;

                    voiceList.Add(title, mp3Url);
                    ret.Add(news);
                }
            }
            return ret;
        }

        public static string DoHttpRequest(string url)
        {
            /*
             * 发送 HTTP GET 请求，返回页面 HTML
             */

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.93 Safari/537.36 Edg/96.0.1054.53";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string html = reader.ReadToEnd();
            return html;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /*
             * 更新列表
             */

            // 点击更新按钮时要先清空 voiceList 
            voiceList.Clear();
            string selectedSrc = this.sourceCbb.SelectedItem.ToString();
            string configPath = Application.StartupPath + "/newssource.json";
            string targetUrl = GetNewsUrl(configPath, selectedSrc);

            string htmlString = "";
            try
            {
                htmlString = DoHttpRequest(targetUrl);
            }
            catch (WebException)
            {
                MessageBox.Show("无法访问目标地址！");

                return;
            }

            ArrayList data = ParseHtml(htmlString);

            // 重新添加上去之前要清空 listBox1 的内容
            this.listBox1.Items.Clear();

            // 顺便把结果保存到文件里面
            string resultFilePath = Application.StartupPath + "/result.txt";
            WriteResult(data, resultFilePath);

            foreach (NewsInfo news in data)
            {
                this.listBox1.Items.Add(news.Title);
            }
            this.listBox1.SelectedIndex = 0;
        }
       
        private void ListBox1_MouseHover(object sender, EventArgs e)
        {
            /*
             * 列表框内的鼠标悬浮事件，提示被选中的标题
             */
            ToolTip tip = new ToolTip();
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 1000;
            tip.ShowAlways = true;
            string txt;

            int n = listBox1.SelectedIndex;
            if (n >= 0)
            {
                txt = listBox1.SelectedItem.ToString();
                tip.SetToolTip(this.listBox1, txt);
            }
        }

        private void WriteResult(ArrayList data, string path)
        {
            /*
             * 把解析后的数据写入本地文件
             */
            StreamWriter writer = new StreamWriter(path);
            foreach(NewsInfo news in data)
            {
                writer.Write(news.ToString());
                writer.WriteLine();
            }
            writer.Close();
        }

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            /*
             * 双击列表时播放音频
             */

            int index = this.listBox1.SelectedIndex;
            if (index != ListBox.NoMatches)
            {
                string title = this.listBox1.SelectedItem.ToString();
                string url = (string)voiceList[title];
                this.axWindowsMediaPlayer1.URL = url;
            }
        }


        private void TransBtn_Click(object sender, EventArgs e)
        {
            /*
             *   翻译功能
             */

            string text = this.wordTbx.Text.Trim();
            string baseUrl = $"https://dict-mobile.iciba.com/interface/index.php?c=word&m=getsuggest&is_need_mean=0&word={text}";
            Console.WriteLine(baseUrl);
            string result = DoHttpRequest(baseUrl);
            JObject res = (JObject)JsonConvert.DeserializeObject(result);
            string ret = "（无结果）";
            int status = (int)res["status"];
            JArray message = (JArray)res["message"];

            if (status != 1)
            {
                ret = res.ToString();
            }
            else if (message != null)
            {
                ret = (string)message[0]["paraphrase"];
            }

            this.transResultLbl.Text = String.Join("\n", ret.Split(';'));
        }

        private void ShortKeyOfTrans(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                this.wordTbx.Focus();
                MessageBox.Show("按下了ctrl+f");
            }
            MessageBox.Show(e.Modifiers.ToString()+"\n");
            
        }
    }
}
