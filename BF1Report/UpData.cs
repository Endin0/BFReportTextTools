
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace BF1Report
{
    public partial class UpData : Form
    {
       public string HackerUserName;//作弊者ID
       public string ReportUserName;//举报者ID
       public string HuserName;
        public UpData(string UserName,string HackName)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.MaximizeBox = false;
            T_UUID.Text ="UUID:"+ UUID();
            YourID_TB.Text = UserName;
            HackID_TB.Text = HackName;
            YourID_TB.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)//点击取消按钮
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//我不想提交自己的ID的CheckBOX
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                YourID_TB.Enabled = false;
                label2.Text = "这会降低这份举报档案的真实性";
                YourID_TB.Text = "";
            }
            else//如果没打勾则：根据兵种选框，判定解锁对应的武器选框
            {
                YourID_TB.Enabled = true;
                
                label2.Text = "你的游戏ID";
            }
        }

        private void TiJiao_Click(object sender, EventArgs e)//提交按钮
        {
            Jc();
        }
        public string UUID()//获取UUID
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = "/c \"wmic CPU get ProcessorID\"";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            string result = p.StandardOutput.ReadToEnd();
            string uuid = result.Split('\n')[1].Trim();
            Console.WriteLine("UUID:"+uuid);
            return uuid;
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//说明链接
        {
            MessageBox.Show("这份档案是作为举报资料存储在我的服务器上，以备未来的联合举报功能，如果你选择输入自己的OriginID，那么文件会保存在" +
                "服务器内的一个专属文件夹里，你上传的一切输入了自己ID的档案都会存储在这个专属文件夹，这个文件夹名字以你电脑的UUID来命名，因此它是独一无二的" +
                "\n\r预计在未来几个版本的更新中，我会加入预览你上传的档案文件功能，以及对应的档案移除功能，用以防止误传等操作。" , "帮助", MessageBoxButtons.OK);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//说明链接
        {
            MessageBox.Show("UUID是基于你的计算机特定硬件序列号生成的，除非你更换了硬件，否则UUID是不会改变的，它的作用是在我的服务器中创建独一无二的对应的文件夹，用于存储你上传的档案", "帮助", MessageBoxButtons.OK);
        }

        private void HackID_TB_KeyPress(object sender, KeyPressEventArgs e)//当在文本框1中检查到回车键时，直接将焦点转入TextBox2
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                YourID_TB.Focus(); 
            }
        }

        private void YourID_TB_KeyPress(object sender, KeyPressEventArgs e)//当在文本框2中检查到回车键时，按下提交
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Jc();
            }
        }
        void Jc()//提交
        {
            if ((HackID_TB.Text == "" | Regex.IsMatch(HackID_TB.Text, "^[a-zA-Z0-9_-]+$")) & (Regex.IsMatch(YourID_TB.Text, "^[a-zA-Z0-9_-]+$") | YourID_TB.Text == ""))//检查输入内容是否存在且合法
            {
                if (YourID_TB.Text == "")
                {
                    ReportUserName = "匿名";
                }
                else
                {
                    ReportUserName = YourID_TB.Text;
                }

                if (HackID_TB.Text == "")//如果没写作弊者ID
                {
                    MessageBox.Show("必须填写作弊者的ID！", "缺少关键文本", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HackerUserName = HackID_TB.Text;
                    HuserName = HackerUserName;
                    this.Close();
                }
            }

            else//如果不合法
            {
                MessageBox.Show("输入的OriginID不符合规范！\n如果是出现在游戏中的规范ID，但依旧出现此提示，请前往贴吧留言告之我该ID的样式", "输入字符不符合Origin命名规则", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument boc = new XmlDocument();
            boc.Load("BFReportData.xml");
            XmlNode nobes = boc.SelectSingleNode("/UseData/SetWeb");
            if (nobes.InnerText == "true")
            {
                System.Diagnostics.Process.Start("https://www.origin.com/irl/zh-tw/search?searchString=" + HackID_TB.Text);
            }
            else
            {
                MessageBox.Show("这是利用EA的官网进行查找,需要在网页上登陆后才能搜索到用户\n\r[可以在主界面的选择中关闭这个弹窗提示]");
                System.Diagnostics.Process.Start("https://www.origin.com/irl/zh-tw/search?searchString=" + HackID_TB.Text);
            }
        }
    }
}
