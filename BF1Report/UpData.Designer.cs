namespace BF1Report
{
    partial class UpData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpData));
            this.TiJiao = new System.Windows.Forms.Button();
            this.Quxiao = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.HackID_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.YourID_TB = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.T_UUID = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.网页需登陆后刷新 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TiJiao
            // 
            this.TiJiao.Location = new System.Drawing.Point(24, 174);
            this.TiJiao.Name = "TiJiao";
            this.TiJiao.Size = new System.Drawing.Size(122, 36);
            this.TiJiao.TabIndex = 0;
            this.TiJiao.Text = "提交";
            this.TiJiao.UseVisualStyleBackColor = true;
            this.TiJiao.Click += new System.EventHandler(this.TiJiao_Click);
            // 
            // Quxiao
            // 
            this.Quxiao.Location = new System.Drawing.Point(211, 174);
            this.Quxiao.Name = "Quxiao";
            this.Quxiao.Size = new System.Drawing.Size(122, 36);
            this.Quxiao.TabIndex = 1;
            this.Quxiao.Text = "取消";
            this.Quxiao.UseVisualStyleBackColor = true;
            this.Quxiao.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(25, 128);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "匿名提交";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // HackID_TB
            // 
            this.HackID_TB.Location = new System.Drawing.Point(24, 29);
            this.HackID_TB.Name = "HackID_TB";
            this.HackID_TB.Size = new System.Drawing.Size(309, 21);
            this.HackID_TB.TabIndex = 3;
            this.HackID_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HackID_TB_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "作弊者的游戏ID:(可修改)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "你的游戏ID:(需回主页面修改)";
            // 
            // YourID_TB
            // 
            this.YourID_TB.Location = new System.Drawing.Point(25, 101);
            this.YourID_TB.Name = "YourID_TB";
            this.YourID_TB.Size = new System.Drawing.Size(308, 21);
            this.YourID_TB.TabIndex = 6;
            this.YourID_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YourID_TB_KeyPress);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Help;
            this.linkLabel1.Location = new System.Drawing.Point(25, 149);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(137, 12);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "提交这些档案有什么用？";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // T_UUID
            // 
            this.T_UUID.AutoSize = true;
            this.T_UUID.Cursor = System.Windows.Forms.Cursors.Default;
            this.T_UUID.Location = new System.Drawing.Point(111, 129);
            this.T_UUID.Name = "T_UUID";
            this.T_UUID.Size = new System.Drawing.Size(35, 12);
            this.T_UUID.TabIndex = 8;
            this.T_UUID.Text = "UUID:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Cursor = System.Windows.Forms.Cursors.Help;
            this.linkLabel2.Location = new System.Drawing.Point(256, 149);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(77, 12);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "UUID是什么？";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 21);
            this.button1.TabIndex = 10;
            this.button1.Text = "打开页面";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 网页需登陆后刷新
            // 
            this.网页需登陆后刷新.AutoSize = true;
            this.网页需登陆后刷新.Location = new System.Drawing.Point(222, 76);
            this.网页需登陆后刷新.Name = "网页需登陆后刷新";
            this.网页需登陆后刷新.Size = new System.Drawing.Size(125, 12);
            this.网页需登陆后刷新.TabIndex = 11;
            this.网页需登陆后刷新.Text = "页面需登陆后才能显示";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "建议打开他的举报页面查看ID是否正确";
            // 
            // UpData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 230);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.网页需登陆后刷新);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.T_UUID);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.YourID_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HackID_TB);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Quxiao);
            this.Controls.Add(this.TiJiao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "作弊者档案提交";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TiJiao;
        private System.Windows.Forms.Button Quxiao;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox HackID_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox YourID_TB;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label T_UUID;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label 网页需登陆后刷新;
        private System.Windows.Forms.Label label3;
    }
}