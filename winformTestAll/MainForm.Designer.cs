/*
 * Created by SharpDevelop.
 * User: 广州哇嘎
 * Date: 2021/12/13
 * Time: 10:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace winformTestAll
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.wordTbx = new System.Windows.Forms.TextBox();
            this.contentLbl = new System.Windows.Forms.Label();
            this.transResultLbl = new System.Windows.Forms.Label();
            this.TransBtn = new System.Windows.Forms.Button();
            this.sourceCbb = new System.Windows.Forms.ComboBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateBtn.Location = new System.Drawing.Point(284, 64);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 26);
            this.UpdateBtn.TabIndex = 1;
            this.UpdateBtn.Text = "更新";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(33, 150);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(342, 379);
            this.listBox1.TabIndex = 3;
            this.listBox1.DoubleClick += new System.EventHandler(this.ListBox_DoubleClick);
            this.listBox1.MouseHover += new System.EventHandler(this.ListBox1_MouseHover);
            // 
            // wordTbx
            // 
            this.wordTbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wordTbx.Location = new System.Drawing.Point(452, 151);
            this.wordTbx.Name = "wordTbx";
            this.wordTbx.Size = new System.Drawing.Size(188, 21);
            this.wordTbx.TabIndex = 4;
            // 
            // contentLbl
            // 
            this.contentLbl.AutoSize = true;
            this.contentLbl.Location = new System.Drawing.Point(381, 154);
            this.contentLbl.Name = "contentLbl";
            this.contentLbl.Size = new System.Drawing.Size(41, 12);
            this.contentLbl.TabIndex = 4;
            this.contentLbl.Text = "label1";
            // 
            // transResultLbl
            // 
            this.transResultLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.transResultLbl.AutoEllipsis = true;
            this.transResultLbl.AutoSize = true;
            this.transResultLbl.Location = new System.Drawing.Point(450, 196);
            this.transResultLbl.Name = "transResultLbl";
            this.transResultLbl.Size = new System.Drawing.Size(41, 12);
            this.transResultLbl.TabIndex = 4;
            this.transResultLbl.Text = "label1";
            // 
            // TransBtn
            // 
            this.TransBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransBtn.Location = new System.Drawing.Point(659, 149);
            this.TransBtn.Name = "TransBtn";
            this.TransBtn.Size = new System.Drawing.Size(75, 23);
            this.TransBtn.TabIndex = 5;
            this.TransBtn.Text = "翻译";
            this.TransBtn.UseVisualStyleBackColor = true;
            this.TransBtn.Click += new System.EventHandler(this.TransBtn_Click);
            // 
            // sourceCbb
            // 
            this.sourceCbb.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sourceCbb.FormattingEnabled = true;
            this.sourceCbb.ItemHeight = 13;
            this.sourceCbb.Location = new System.Drawing.Point(42, 68);
            this.sourceCbb.Name = "sourceCbb";
            this.sourceCbb.Size = new System.Drawing.Size(220, 21);
            this.sourceCbb.TabIndex = 7;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(385, 7);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(349, 136);
            this.axWindowsMediaPlayer1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 592);
            this.Controls.Add(this.sourceCbb);
            this.Controls.Add(this.TransBtn);
            this.Controls.Add(this.transResultLbl);
            this.Controls.Add(this.contentLbl);
            this.Controls.Add(this.wordTbx);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.UpdateBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "winformTestAll";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShortKeyOfTrans);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.ListBox listBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TextBox wordTbx;
        private System.Windows.Forms.Label contentLbl;
        private System.Windows.Forms.Label transResultLbl;
        private System.Windows.Forms.Button TransBtn;
        private System.Windows.Forms.ComboBox sourceCbb;
    }
}
