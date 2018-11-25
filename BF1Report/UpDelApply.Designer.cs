namespace BF1Report
{
    partial class UpDelApply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpDelApply));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tijiao = new System.Windows.Forms.Button();
            this.quxiao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.理由 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(26, 257);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(281, 88);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tijiao
            // 
            this.tijiao.Location = new System.Drawing.Point(26, 352);
            this.tijiao.Name = "tijiao";
            this.tijiao.Size = new System.Drawing.Size(97, 42);
            this.tijiao.TabIndex = 1;
            this.tijiao.Text = "申请";
            this.tijiao.UseVisualStyleBackColor = true;
            this.tijiao.Click += new System.EventHandler(this.tijiao_Click);
            // 
            // quxiao
            // 
            this.quxiao.Location = new System.Drawing.Point(210, 352);
            this.quxiao.Name = "quxiao";
            this.quxiao.Size = new System.Drawing.Size(97, 42);
            this.quxiao.TabIndex = 2;
            this.quxiao.Text = "取消";
            this.quxiao.UseVisualStyleBackColor = true;
            this.quxiao.Click += new System.EventHandler(this.quxiao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "申请删除的档案:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 21);
            this.textBox1.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(87, 64);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(216, 21);
            this.textBox3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "游戏版本:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "上传时间:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(123, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 21);
            this.textBox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "其他理由:";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Enabled = false;
            this.richTextBox2.ForeColor = System.Drawing.Color.Red;
            this.richTextBox2.Location = new System.Drawing.Point(24, 91);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(279, 102);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "申请提交后,该文档并不会立即删除,只是不会主动载入到浏览列表中,在1-5天内,我会进行审核操作,通过便删除\n如果是符合选项内的申请,一般都会直接删除\n本人技术有限" +
    ",该选项是防止针对服务器存储文本的保护措施,请见谅";
            // 
            // 理由
            // 
            this.理由.AutoSize = true;
            this.理由.ForeColor = System.Drawing.Color.Red;
            this.理由.Location = new System.Drawing.Point(24, 214);
            this.理由.Name = "理由";
            this.理由.Size = new System.Drawing.Size(59, 12);
            this.理由.TabIndex = 11;
            this.理由.Text = "选择理由:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1.作弊者ID有误",
            "2.作弊者行为有误",
            "3.自己的ID有误",
            "4.删除匿名档案重新上传实名档案",
            "5.删除实名档案重新上传匿名档案",
            "6.其他理由(自己填)"});
            this.comboBox1.Location = new System.Drawing.Point(88, 211);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 20);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // UpDelApply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 430);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.理由);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quxiao);
            this.Controls.Add(this.tijiao);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpDelApply";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提交申请删除档案";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button tijiao;
        private System.Windows.Forms.Button quxiao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label 理由;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}