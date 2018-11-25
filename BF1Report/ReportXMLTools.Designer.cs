namespace BF1Report
{
    partial class ReportXMLTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportXMLTools));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameBB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Myxml = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.CX_BOX = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.CBB_CXXZ = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button8 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HackName,
            this.ReportName,
            this.ID,
            this.UpTime,
            this.GameBB});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(175, 42);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(577, 438);
            this.dataGridView1.TabIndex = 1;
            // 
            // HackName
            // 
            this.HackName.HeaderText = "作弊玩家ID";
            this.HackName.Name = "HackName";
            this.HackName.ReadOnly = true;
            // 
            // ReportName
            // 
            this.ReportName.HeaderText = "举报者ID";
            this.ReportName.Name = "ReportName";
            this.ReportName.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "UUID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // UpTime
            // 
            this.UpTime.HeaderText = "提交时间";
            this.UpTime.Name = "UpTime";
            this.UpTime.ReadOnly = true;
            // 
            // GameBB
            // 
            this.GameBB.HeaderText = "游戏版本";
            this.GameBB.Name = "GameBB";
            this.GameBB.ReadOnly = true;
            // 
            // Myxml
            // 
            this.Myxml.Location = new System.Drawing.Point(12, 248);
            this.Myxml.Name = "Myxml";
            this.Myxml.Size = new System.Drawing.Size(136, 39);
            this.Myxml.TabIndex = 3;
            this.Myxml.Text = "我上传的档案";
            this.Myxml.UseVisualStyleBackColor = true;
            this.Myxml.Click += new System.EventHandler(this.Myxml_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(2, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "该窗口为测试性功能，未完善";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(907, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "查看选中档案";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 34);
            this.button2.TabIndex = 12;
            this.button2.Text = "提交申请删除档案";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(12, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 39);
            this.button3.TabIndex = 13;
            this.button3.Text = "重复举报的档案";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(907, 408);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(127, 72);
            this.button4.TabIndex = 14;
            this.button4.Text = "下载选中档案";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CX_BOX
            // 
            this.CX_BOX.Location = new System.Drawing.Point(374, 12);
            this.CX_BOX.Name = "CX_BOX";
            this.CX_BOX.Size = new System.Drawing.Size(245, 21);
            this.CX_BOX.TabIndex = 15;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(642, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 21);
            this.button5.TabIndex = 16;
            this.button5.Text = "查找";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // CBB_CXXZ
            // 
            this.CBB_CXXZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBB_CXXZ.FormattingEnabled = true;
            this.CBB_CXXZ.Items.AddRange(new object[] {
            "UUID",
            "举报者ID",
            "作弊玩家ID"});
            this.CBB_CXXZ.Location = new System.Drawing.Point(233, 13);
            this.CBB_CXXZ.Name = "CBB_CXXZ";
            this.CBB_CXXZ.Size = new System.Drawing.Size(111, 20);
            this.CBB_CXXZ.TabIndex = 71;
            this.CBB_CXXZ.DropDownClosed += new System.EventHandler(this.GV_CB_DropDownClosed);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 42);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(136, 39);
            this.button7.TabIndex = 73;
            this.button7.Text = "查看全部档案";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "从";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 75;
            this.label3.Text = "找";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(12, 378);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(136, 34);
            this.button6.TabIndex = 76;
            this.button6.Text = "同步到联BAN调查局";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(774, 357);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(127, 33);
            this.button10.TabIndex = 79;
            this.button10.Text = "查看他的EA举报主页";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(776, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 80;
            this.label4.Text = "可以在这里举报他至EA";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(774, 15);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 336);
            this.richTextBox1.TabIndex = 81;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(6, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 61);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "仅限操作自己的档案";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(29, 418);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 12);
            this.linkLabel1.TabIndex = 83;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "访问联BAN调查局";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(774, 408);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(127, 31);
            this.button8.TabIndex = 84;
            this.button8.Text = "查他战绩[BFtracker]";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(774, 449);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(127, 31);
            this.button11.TabIndex = 85;
            this.button11.Text = "查他战绩[BF1stats]";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button12.Location = new System.Drawing.Point(12, 171);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(136, 39);
            this.button12.TabIndex = 86;
            this.button12.Text = "所有申请删除的档案";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 21);
            this.textBox1.TabIndex = 87;
            // 
            // ReportXMLTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 496);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.Myxml);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.CBB_CXXZ);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.CX_BOX);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportXMLTools";
            this.Text = "服务器档案查看工具";
            this.Load += new System.EventHandler(this.ReportXMLTools_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Myxml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox CX_BOX;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox CBB_CXXZ;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameBB;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textBox1;
    }
}