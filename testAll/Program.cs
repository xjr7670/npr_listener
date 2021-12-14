/*
 * Created by SharpDevelop.
 * User: 广州哇嘎
 * Date: 2021/12/13
 * Time: 9:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace testAll
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

            // TODO: Implement Functionality Here
            // ShowRSS("http://feed.cnblogs.com/blog/u/18638/rss");
            string url = "https://www.npr.org/programs/morning-edition";
            string html = DoHttpRequest(url);
            // string html = ReadFile("e:/temp/temp.txt");
            ParseHtml(html);

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

        public static string ReadFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            StringBuilder content = new StringBuilder();
            string line;
            while ((line = reader.ReadLine()) != null) {
                content.Append(line);
            }
            return content.ToString();
        }

        public static void ParseHtml(string htmlString)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlString);
            var root = doc.DocumentNode;
            var storyList = root.SelectSingleNode("//div[@id='story-list']");
            var articles = storyList.SelectNodes("article");
            if (articles != null)
            {
                foreach(var article in articles)
                {
                    // 解析标题和链接
                    var aTag = article.SelectSingleNode("div/h3/a");
                    string title = aTag.GetDirectInnerText();
                    string url = aTag.GetAttributeValue("href", "none");

                    // 获取 mp3 链接
                    var mp3Tag = article.SelectSingleNode("article/div/div/div/a");
                    string mp3Url = mp3Tag.GetAttributeValue("href", "mp3None");

                    Console.WriteLine($"标题：{title}\n文章链接：{url}\n音频链接：{mp3Url}\n");
                }
            }
        }

        public static string DoHttpRequest(string url)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest) System.Net.WebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.93 Safari/537.36 Edg/96.0.1054.53";

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string html = reader.ReadToEnd();

            string filePath = "e:/temp/temp.txt";
            StreamWriter writer = new StreamWriter(filePath, false);
           
            writer.WriteLine(html);
            writer.Close();

            return html;
        }
		
		public static void ShowRSS(string rssURI)
        {
            SyndicationFeed sf = SyndicationFeed.Load(XmlReader.Create(rssURI));
 
            string textBox1 = "";
            textBox1 += "title:" + sf.Title.Text + "\r\n";
            if (sf.Links.Count > 0)
                textBox1 += "Link:" + sf.Links[0].Uri.ToString() + "\r\n";
            if (sf.Authors.Count > 0 && !string.IsNullOrEmpty(sf.Authors[0].Uri))
                textBox1 += "Link:" + sf.Authors[0].Uri.ToString() + "\r\n";
            textBox1 += "pubDate:" + sf.LastUpdatedTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
 
            foreach (SyndicationItem it in sf.Items)
            {
                textBox1 += "\r\n-----------------------------------------------------\r\n";
                textBox1 += "title:" + it.Title.Text + "\r\n";
                if (it.Links.Count > 0)
                    textBox1 += "Link:" + it.Links[0].Uri.ToString() + "\r\n";
                textBox1 += "PubDate:" + it.PublishDate.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                if(it.Summary!=null)
                    textBox1 += "Summary:" + it.Summary.Text + "\r\n";
                if(it.Content!=null)
                	textBox1 += "Content:" + ((TextSyndicationContent)it.Content).Text + "\r\n";
                Console.WriteLine(textBox1);
            }
             
        }
	}
}