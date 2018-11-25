using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Aliyun.OSS;


namespace BF1Report
{

    public partial class BF1Report : Form
    {
        const double BB = 1.66;//版本号
        public string ReportUserName;//举报者ID
        public string HackerUserName;//作弊者ID
        public string HuserName;
        public string ReportText = "";//作弊者行为文本
        double FBB;//服务器上获取的最新版本号
        string FMD5bt;//服务器上软件本体的MD5
        string FMD5sj;//服务器升级文件的MD５
        string FMD5wb;//服务器文本的ＭＤ5
        string BMD5sj;//本地升级文件的MD5
        string BMD5wb;//本地文本MD5
        string WJ = "MD5同步"; //用于对比MD5是否同步
        string all;  //储存总文本
        string KD;   //存储KD值
        string bz;   //兵种
        string a2;   //武器载具文本
        string a3;   //地图文本
        string tb;   //包含游戏版本
        string t0;   //整合t1,t2,t3生成的文本
        string t1;   //透视
        string t2;   //自瞄
        string t3;   //伤害修改
        string t4;   //隐身
        string t5;   //子弹穿墙
        string t6;   //一枪秒杀

        List<string> WPE = new List<string>();//存放分割后的武器英文
        List<string> WPC = new List<string>(); //存放分割后的中文
        List<string> ME = new List<string>();//存放分割后的地图英文
        List<string> MC = new List<string>();//存放分割后的地图中文
        List<int> list = new List<int>();//该数组用于存放0/1，来表示各个文件是否存在
        public List<string> FMD5list = new List<string>();//该数组用于存放服务器上读取的各个文件MD5代码

        public BF1Report()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.Text = "战地刷箱工具 V"+BB ;
            GV_CB.SelectedIndex = 0;
            if (File.Exists(@"Aliyun.OSS.dll") == false)
            {
                WebClient Client = new WebClient();
                Client.DownloadFile("http://bf1report.oss-cn-beijing.aliyuncs.com/version/Aliyun.OSS.dll", "Aliyun.OSS.dll");//5'
                MessageBox.Show("检测到DLL缺失，已自动从服务器获取，请重新启动软件","提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
                    
            for (int i = 0; i < 3; i++)//给list创建对象
            {
                list.Add(1);
                Console.WriteLine("List-" + i + ":0");
            }
            if (!File.Exists(@"BFReportData.xml"))
            {
                StreamWriter sbre = new StreamWriter("BFReportData.xml");
                sbre.Write("<UseData>\r\n<ReportName></ReportName>\r\n<Setbackups>false</Setbackups>\r\n<SetWeb>false</SetWeb>\r\n<Game>BF1</Game>\r\n</UseData>");
                sbre.Flush();
                sbre.Dispose();
            }
            if (File.Exists(@"UseData.xml"))
            {
                File.Delete(@"UseData.xml");
            }
            XmlDocument boc = new XmlDocument();
            boc.Load("BFReportData.xml");
            try
            {
                XmlNode nobes = boc.SelectSingleNode("/UseData/ReportName");
                Name_T.Text = nobes.InnerText;
                nobes = boc.SelectSingleNode("/UseData/Setbackups");
                if (nobes.InnerText == "true")
                {
                    CB_BU.CheckState = CheckState.Checked;

                }
                else
                {
                    CB_BU.CheckState = CheckState.Unchecked;
                }
                nobes = boc.SelectSingleNode("/UseData/SetWeb");
                if (nobes.InnerText == "true")
                {
                    checkBox1.CheckState = CheckState.Checked;

                }
                else
                {
                    checkBox1.CheckState = CheckState.Unchecked;
                }
                nobes = boc.SelectSingleNode("/UseData/Game");
                if (nobes.InnerText == "BF1")
                {
                    GV_CB.SelectedIndex = 0;

                }
                else
                {
                    GV_CB.SelectedIndex = 1;
                }
            }
            catch
            {
                StreamWriter sbre = new StreamWriter("BFReportData.xml");
                sbre.Write("<UseData>\r\n<ReportName></ReportName>\r\n<Setbackups>false</Setbackups>\r\n<SetWeb>false</SetWeb>\r\n<Game>BF1</Game>\r\n</UseData>");
                sbre.Flush();
                sbre.Dispose();

            }

            if (Name_T.Text != "")
            {
                Name_T.Enabled = false;
                Name_B.Text = "修改";
            }
        }

        


        private void Form1_Load(object sender, EventArgs e)//启动软件时执行
        {
            CBB_WQLB.Enabled = false;
            CB_Unknow_WQ.Enabled = false;
            B_WBGX.Visible = false;
            //从服务器获取公告

            //检测文件是否有缺失，如果有则更改对应的list数组内容（0为缺失，1为存在）。最后调用XZ（下载）函数
            if (File.Exists(@"Zh-En.xml")  & File.Exists(@"BF1Report-Updata.exe") )
            {
            }
            else
            {
                Console.WriteLine("List-1:" + list[0]);
                if (File.Exists(@"BF1Report-Updata.exe") == false)
                {
                    list[1] = 0;
                    Console.WriteLine("List-1:"  + list[1]);
                }
                if (File.Exists(@"Zh-En.xml") == false)
                {
                    list[2] = 0;
                    Console.WriteLine("List-2:" + list[2]);
                }
                MessageBox.Show("检测到必要文件丢失，正在从服务器重新下载缺失文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                XZ();
            }
            try
            {

                XmlDocument boc = new XmlDocument();
                boc.Load("http://bf1report.oss-cn-beijing.aliyuncs.com/version/FXX.xml");
                XmlNodeList nobes = boc.SelectNodes("/FWQXX/GXNR");
                foreach (XmlNode nobe in nobes)
                {
                    richTextBox1.AppendText(nobe.InnerText + "\n");//将公告输出在richTextBox                }
                }
            }
            catch
            {

            }
            BBJC();
        }

        private void button1_Click(object sender, EventArgs e)//生成最终的文本，并复制文本的按钮
        {
            SCWB();

            if (CB_BU.CheckState == CheckState.Checked)
            {
                if ((HName_T.Text == "" | Regex.IsMatch(HName_T.Text, "^[a-zA-Z0-9_-]+$")))//检查输入内容是否存在且合法
                {

                    if (HName_T.Text == "")//如果没写作弊者ID
                    {
                        MessageBox.Show("保存到本地时必须填写作弊者的ID！", "缺少关键文本", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (Directory.Exists("BackupsUser") == false)//如果不存
                        {
                            Directory.CreateDirectory("BackupsUser");
                        }
                        StreamWriter snn = new StreamWriter("BackupsUser\\" + HName_T.Text + ".xml");
                        ReportText = "<?xml version=\"1.0\" ?>" + "\r\n<ReportText>" + "\n<Game>" + tb + "</Game>" + "\n<Hacker>" + HackerUserName + "</Hacker>" + ToXmlRUN(ReportUserName) + ToXmlRT(t0) + ToXmlRT(t1) + ToXmlRT(t2) + ToXmlRT(t3) + ToXmlRT(t4) + ToXmlRT(t5) + ToXmlRT(t6) + ToXmlRT(bz) + ToXmlRT(KD) + ToXmlRT(a2) + ToXmlRT(a3) + "\r\n</ReportText>";
                        snn.Write(ReportText);
                        snn.Flush();
                        snn.Dispose();
                    }
                }

                else//如果不合法
                {
                    MessageBox.Show("输入的OriginID不符合规范！\n如果是出现在游戏中的规范ID，但依旧出现此提示，请前往贴吧或SteamCN留言告之我该ID的样式", "输入字符不符合Origin命名规则", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
        }

        public static string HH(string a)//换行

        {
            if (a == "")
            {
                Console.WriteLine("空");
                return a;
            }
            else
            {
                string b = "\r\n" + a;
                Console.WriteLine(b);
                return b;
            }
        }


        private void comboBox1_DropDown(object sender, EventArgs e)//获取软件目录下的地图列表txt文件，并读取到下拉选项内
        {
            CBB_Map.Items.Clear();
            string a = "BF1";
            if (GV_CB.Text == "BF V")
            {
                a = "BFV";
            }
            GetXDTLB(a);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Unknow_WQ.CheckState == CheckState.Checked)//如果不知道武器这项打勾后就清空列表，并上锁
            {
                CBB_WQLB.Enabled = false;
                CBB_WQLB.Text = "";
                bz = "";
            }
            else//如果没打勾则：根据兵种选框，判定解锁对应的武器选框
            {
                CBB_WQLB.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)//清空文本框，初始化数据
        {
            richTextBox1.Clear();
            CBB_WQLB.Text = "";
            CBB_BZ.Text = "";
            CBB_Map.Text = "";
            KD = "";
            TB_DIE.Text = "";
            TB_KILL.Text = "";
            all = "";
            t1 = "";
            t2 = "";
            t3 = "";
            t4 = "";
            t5 = "";
            t6 = "";
            CBB_WQLB.Enabled = false;

            CB_TS.Checked = false;
            CB_ZM.Checked = false;
            CB_YQMS.Checked = false;
            CB_Unknow_WQ.Checked = false;
            CB_SHXG.Checked = false;
            CB_YS.Checked = false;
            CB_YQMS.Checked = false;
            CB_Unknow_WQ.Checked = false;
            CB_ZDCQ.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)//跳转到贴吧
        {
            System.Diagnostics.Process.Start("https://tieba.baidu.com/p/5902376368");
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CB_Unknow_MAP.CheckState == CheckState.Checked)//如果不知道地图这项打勾后就清空列表，并上锁
            {
                CBB_Map.Enabled = false;
                CBB_Map.Text = "";
                LB_MAP.Enabled = false;
            }
            else//如果没打勾则：根据兵种选框，判定解锁对应的武器选框
            {
                CBB_Map.Enabled = true;
                LB_MAP.Enabled = true;
            }
        }

        private void CB_Unknow_BZ_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Unknow_BZ.CheckState == CheckState.Checked)//如果不知道兵种这项打勾后就清空列表，并上锁
            {
                CB_Unknow_WQ.Enabled = false;
                CBB_WQLB.Enabled = false;
                CBB_BZ.Enabled = false;
                CBB_WQLB.Text = "";
                LB_BZ.Enabled = false;
                CBB_BZ.Text = "";

            }
            else//如果没打勾则：根据兵种选框，判定解锁对应的武器选框
            {
                CBB_BZ.Enabled = true;
                LB_BZ.Enabled = true;

            }
        }

        private void B_WBGX_Click(object sender, EventArgs e)//下载更新按钮
        {
            if (B_WBGX.Text == "下载更新")
            {
                Process.Start(@"BF1Report-Updata.exe");
                System.Environment.Exit(0);
            }
            else if (B_WBGX.Text == "更新文本" | B_WBGX.Text == "更新")
            {
                XZ();
                BBJC();
                BBXX.Visible = true;
                if (B_WBGX.Text == "文本修复")
                {
                    MessageBox.Show("当前文本列表与服务器同步成功", "修复完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (B_WBGX.Text == "更新文本")
                {
                    MessageBox.Show("更新完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        void BBJC()//版本检测，用于检测服务器和本地版本是否有区别
        {
            try
            {
                //服务器MD5获取
                var cliente = new OssClient("oss-cn-beijing.aliyuncs.com", "LTAIjOoHVuoXjhf8", "zTuZWpU3hdd6cPT0oVcsOIpxGgxtpC");
                var oldMeta = cliente.GetObjectMetadata("bf1report", "version/Version.xml");
                FMD5bt = oldMeta.UserMetadata["bf1report"];
                FMD5sj = oldMeta.UserMetadata["bf1report-updata"];
                FMD5wb = oldMeta.UserMetadata["zh-en"];
                FBB = double.Parse(oldMeta.UserMetadata["version"]);
                Console.WriteLine(FMD5bt);
                Console.WriteLine(FMD5sj);
                Console.WriteLine(FMD5wb);
                Console.WriteLine(FBB);//打印FMD5list数组
            }
            catch
            {
                MessageBox.Show("尝试从服务器获取信息失败", "版本检测出现错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //本地MD5获取
            Console.WriteLine(FBB);
            Console.WriteLine(FBB==0);
            if (FBB == 0)
            {
                BBXX.Text = "版本检测：[失败]无法连接到服务器";
                B_WBGX.Visible = false;
            }
            else
            {
                BMD5sj = GetMD5("BF1Report-Updata.exe");
                BMD5wb = GetMD5("Zh-En.xml");
                if (BMD5sj == FMD5sj)
                {
                    list[1] = 1;

                }
                else
                {
                    list[1] = 0;

                }

                if (BMD5wb == FMD5wb)
                {

                    list[2] = 1;

                }
                else
                {
                    list[2] = 0;

                }
                for (int b = 1; b < 3; b++)//检测list数组中，是否包含0，如果包含，说明有文件不一致，此时出现更新文本按钮
                {
                    if (list[b] == 0)
                    {
                        WJ = "MD5不同步";
                        //Console.WriteLine("list-" + b + "的" + "MD5不同步，它的值为："+ list[b]);
                    }
                    else//如果不包含0，说明无需更新
                    {
                        //Console.WriteLine("list-" + b + "的" + "MD5同步，它的值为："+ list[b]);
                    }
                }

                if (FBB == BB & WJ == "MD5同步")
                {
                    BBXX.Text = "版本检测：当前软件已是最新版本";
                    B_WBGX.Visible = false;

                }
                else if (FBB < BB & WJ == "MD5同步")
                {
                    BBXX.Text = "版本检测：软件版本高于与现有版本，无需更新";
                    B_WBGX.Visible = false;
                }
                else if (FBB > BB & WJ != "MD5同步" | WJ == "MD5同步")
                {
                    BBXX.Text = "版本检测：[有软件更新]最新版本:V" + FBB;
                    B_WBGX.Text = "下载更新";
                    B_WBGX.Visible = true;
                }
                else if (FBB == BB | FBB < BB & WJ != "MD5同步")
                {
                    BBXX.Text = "版本检测：[有文本更新]";
                    B_WBGX.Text = "更新文本";
                    B_WBGX.Visible = true;

                    if (FMD5sj != BMD5sj)
                    {
                        BBXX.Text = "版本检测：[下载器有更新]";
                        B_WBGX.Visible = true;
                        B_WBGX.Text = "更新";
                    }
                }

            }
        }

        void XZ()//下载，调用后依据list数组，自动下载缺失文件
        {
            WebClient Client = new WebClient();
            BBXX.Visible = false;
            B_WBGX.Enabled = false;
          //  try
          //  {
                if (list[1] == 0)
                {
                    Client.DownloadFile("http://bf1report.oss-cn-beijing.aliyuncs.com/version/BF1Report-Updata.exe", "BF1Report-Updata.exe");//5
                    list[1] = 1;
                   // Console.WriteLine("XZ:List-1:" + list[3]);
                }
                if (list[2] == 0)
                {
                    Client.DownloadFile("http://bf1report.oss-cn-beijing.aliyuncs.com/version/Text/Zh-En.xml", "Zh-En.xml");//5
                    list[2] = 1;
                    //Console.WriteLine("XZ:List-2:" + list[3]);
                }
                B_WBGX.Enabled = true;
                Console.WriteLine("XZ完成,WJ=MD5同步");
                WJ = "MD5同步";
           // }
          //  catch
          //  {

               // MessageBox.Show("从服务器下载文本失败", "获取文件失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }

}

        public void GetLB(string Name)//获取软件目录下的txt列表，并写入对应的选项框传入参数是对应的TXT兵种中文
        {

            CB_Unknow_WQ.Enabled = true;
            CBB_WQLB.Enabled = true;
            CBB_WQLB.Items.Clear();

            if (Name == "驾驶员")
            {
                string a = "";
                if (GV_CB.Text == "BF V")
                {
                    a = "2";
                }

                FileInfo fii = new FileInfo(@Name + "载具列表" + a + ".txt");
                StreamReader ssr = fii.OpenText();
                string strLine = string.Empty;
                while ((strLine = ssr.ReadLine()) != null)
                {
                    CBB_WQLB.Items.Add(strLine);
                }
                ssr.Dispose();
            }
            else if (Name == "飞行员" )
            {
                string a = "";
                if (GV_CB.Text == "BF V")
                {
                    a = "2";
                }
                FileInfo fii = new FileInfo(@Name + "载具列表" + a + ".txt");
                StreamReader ssr = fii.OpenText();
                string strLine = string.Empty;
                while ((strLine = ssr.ReadLine()) != null)
                {
                    CBB_WQLB.Items.Add(strLine);
                }
                ssr.Dispose();
            }
            else if (Name == "支援兵"| Name == "医疗兵"| Name == "突击兵"| Name == "侦察兵"| Name == "精英兵"  | Name == "骑兵")
            {
                 string a = "";
                 if (GV_CB.Text == "BF V")
                 {
                     a = "2";
                 }
                 FileInfo fii = new FileInfo(Name + "武器列表" + a + ".txt");
                 StreamReader ssr = fii.OpenText();
                 string strLine = string.Empty;
                 while ((strLine = ssr.ReadLine()) != null)
                 {
                     CBB_WQLB.Items.Add(strLine);
                 }
                ssr.Dispose();
            
            }
            else if (Name =="混合兵种")
            {

                FileInfo fii = new FileInfo("混合兵种武器列表.txt");
                StreamReader ssr = fii.OpenText();
                string strLine = string.Empty;
                while ((strLine = ssr.ReadLine()) != null)
                {
                    CBB_WQLB.Items.Add(strLine);
                }
                ssr.Dispose();
            }

        }

        public double GetWB()//获取本地的文本版本信息
        {
            FileInfo fi = new FileInfo(@"地图列表.txt");
            StreamReader sr = fi.OpenText();
            double DT = double.Parse(sr.ReadLine());
            sr.Dispose();
            return DT;
        }

        private void CBB_WQLB_DropDown(object sender, EventArgs e)//列表按钮按下时，触发的事件
        {
            GetLB(CBB_BZ.Text);
            
        }

        public static string GetMD5(string fileName)//MD5代码获取
        {
            string a = "";
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch// (Exception ex)
            {
                return a;
                //throw new Exception("GetMD5() fail,error:" + ex.Message);
            }
        }

        private void B_about_Click(object sender, EventArgs e)//问号按钮
        {
            MessageBox.Show("软件版本：V" + BB + "\nBy : GenesisAN" + "\n\n上传作弊者是指将其ID与作弊行为上传到我私人服务器上，上传前务必核对作弊者的玩家Origin ID，你可以选择是否填写您的Origin ID，收集这些信息是做数据记录用途,以后会开放浏览这些数据文件的功能", "关于/上传作弊者功能", MessageBoxButtons.OK);
        }

        private void B_Updata_Click(object sender, EventArgs e)//上传作弊者按钮
        {
            if (all == null|all=="")
            {
                MessageBox.Show("你还没生成文本信息" , "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpData upData = new UpData(Name_T.Text,HName_T.Text);
                upData.ReportUserName = "";
                upData.HuserName = "";
                upData.HackerUserName = "";
                upData.ShowDialog();
                HuserName = upData.HuserName;
                ReportUserName = upData.ReportUserName;
                HackerUserName = upData.HackerUserName;
                Console.WriteLine(ReportUserName + "|"+ HackerUserName+ "|" +HuserName);
                if (HackerUserName == "")
                {

                }
                else//此处是生成要上传到服务器的XML文件字符串
                {
                    ReportText = "<?xml version=\"1.0\" ?>" + "\r\n<ReportText>" + "\n<Game>" + tb + "</Game>"  + "\n<Hacker>" + HackerUserName + "</Hacker>" + ToXmlRUN(ReportUserName) + ToXmlRT(t0) + ToXmlRT(t1) + ToXmlRT(t2) + ToXmlRT(t3) + ToXmlRT(t4) + ToXmlRT(t5) + ToXmlRT(t6) + ToXmlRT(bz) + ToXmlRT(KD) + ToXmlRT(a2) + ToXmlRT(a3) + "\r\n</ReportText>";
                    var client = new OssClient("oss-cn-beijing.aliyuncs.com", "LTAIjOoHVuoXjhf8", "zTuZWpU3hdd6cPT0oVcsOIpxGgxtpC");
                    try
                    {
                        byte[] binaryData = Encoding.UTF8.GetBytes(ReportText);
                        MemoryStream requestContent = new MemoryStream(binaryData);
                        // 上传文件。
                        client.PutObject("bf1report", "Data/" + HuserName + ".xml", requestContent);
                        var newMeta = new ObjectMetadata();
                        newMeta.UserMetadata.Add("uuid",UUID());
                        newMeta.UserMetadata.Add("reportname", ReportUserName);
                        newMeta.UserMetadata.Add("gamebb", GV_CB.Text);
                        newMeta.UserMetadata.Add("delappyly", "no");
                        client.ModifyObjectMeta("bf1report", "Data/" + HuserName+".xml", newMeta);
                        Console.WriteLine("上传成功");
                        MessageBox.Show("作弊者：" + HackerUserName + " 的恶劣行为已经上传到服务器\n并且在软件目录下的ReportUser文件夹内生成对应档案", "上传成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show(ReportText, "存储文本内容", MessageBoxButtons.OK);
                        if (Directory.Exists("ReportUser") == false)//如果不存
                        {
                            Directory.CreateDirectory("ReportUser");
                        }
                        StreamWriter sbr = new StreamWriter("ReportUser\\" + HackerUserName + ".xml");
                        sbr.Write(ReportText);
                        sbr.Flush();
                        sbr.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("上传出错, {0}", ex.Message);
                        MessageBox.Show("上传出错," + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Console.ReadLine();
                }
            }
        }

    


        void SCWB()//生成文本
        {
            richTextBox1.Clear();//清空文本框，并清空各项文本值
            tb = "Game:"+GV_CB.Text;
            all = "";
            t1 = "";
            t2 = "";
            t3 = "";
            t4 = "";
            t5 = "";
            if (CB_TS.CheckState == CheckState.Checked)//判断透视的CheckBOX是否勾选

            {
                t1 = "-WallHack";
            }
            else
            {
                t1 = "";

            }
            if (CB_ZM.CheckState == CheckState.Checked)//判断自瞄的CheckBOX是否勾选

            {

                t2 = "-Aimbot";

            }
            else
            {
                t2 = "";

            }

            if (CB_SHXG.CheckState == CheckState.Checked)//判断伤害修改的CheckBOX是否勾选

            {

                t3 = "-Change weapon's damage";

            }
            else
            {
                t3 = "";

            }

            if (CB_YS.CheckState == CheckState.Checked)//判断隐身的CheckBOX是否勾选

            {

                t4 = "-Invisible";

            }
            else
            {
                t4 = "";

            }
            if (CB_ZDCQ.CheckState == CheckState.Checked)//判断子弹穿墙·的CheckBOX是否勾选

            {

                t5 = "-Bullet penetration hack";
            }
            else
            {
                t5 = "";

            }
            if (CB_YQMS.CheckState == CheckState.Checked)//判断一枪秒杀的CheckBOX是否勾选
            {
                t6 = "-One shot kill in every range without a headshot";
            }
            else
            {
                t6 = "";

            }
            //如果有任何一个作弊选项被勾选，就设置t0的值
            if (CB_TS.CheckState == CheckState.Checked | CB_ZM.CheckState == CheckState.Checked | CB_YQMS.CheckState == CheckState.Checked | CB_YS.CheckState == CheckState.Checked | CB_ZDCQ.CheckState == CheckState.Checked
                | CB_SHXG.CheckState == CheckState.Checked)
            {
                t0 = "Cheating:";
            }
            if (CBB_BZ.Text == "医疗兵")//判断兵种下拉框内的选项并赋值给bz
            {
                bz = "Class:Medic";

            }
            else if (CBB_BZ.Text == "突击兵")//判断兵种下拉框内的选项并赋值给bz
            {
                bz = "Class:Assault";

            }
            else if (CBB_BZ.Text == "侦察兵")//判断兵种下拉框内的选项并赋值给bz
            {
                bz = "Class:Scout";

            }
            else if (CBB_BZ.Text == "支援兵")//判断兵种下拉框内的选项并赋值给bz
            {
                if (GV_CB.Text == "BF V")
                {
                    bz = "Class:Recon";
                }
                else
                {
                    bz = "Class:Support";
                }
            }
            else if (CBB_BZ.Text == "飞行员")//判断兵种下拉框内的选项并赋值给bz
            {
                bz = "Class:Pilot";

            }
            else if (CBB_BZ.Text == "驾驶员")//判断兵种下拉框内的选项并赋值给bz
            {
                bz = "Class:Tanker";

            }
            else if (CBB_BZ.Text == "骑兵")//判断兵种下拉框内的选项并赋值给bz
            {
                bz = "Class:Cavalry";

            }
            else if (CBB_BZ.Text == "精英兵")//判断兵种下拉框内的选项并赋值给bz
            {
                bz = "Class:Elite Class";

            }
            else//如果不符合条件（兵种下拉框内没钩选），设置bz值为空
            {
                bz = "";
            }

            if (TB_KILL.Text == ""  & TB_DIE.Text == "" )//判断杀敌框内是否有进行输入，如果两个框为空，则KD为空
            {
                KD = "";
            }
            else if (TB_KILL.Text == "")//如果杀敌框为空，则输出DIE的数字
            {
                KD = "DIE:" + TB_DIE.Text;
            }
            else if (TB_DIE.Text == "")//如果死亡数框为空，则输出杀敌的数字
            {
                KD = "KILL:" + TB_KILL.Text;
            }
            else//如果杀敌死亡都没空，则两个值都输出
            {
                KD = "KILL:" + TB_KILL.Text + ",DEATH:" + TB_DIE.Text;
            }


            if (CB_Unknow_WQ.CheckState == CheckState.Checked)//判断是否知道武器的CheckBox是否打勾
            {
                a2 = "";//打勾的话给a2赋值
            }
            else//如果没打勾则
            {
                if (CBB_BZ.Text == "" | CBB_WQLB.Text == "")//判断兵种选项和武器列表是否有进行选择
                {
                    a2 = "";
                }
                else
                {
                    a2 = "Useing:" + WPE[WPC.IndexOf(CBB_WQLB.Text)];
                }
            }
            if (CBB_Map.Text == "")//判断地图选项是否有进行选择
            {
                a3 = "";
            }
            else
            {
                a3 = "Map:" + ME[MC.IndexOf(CBB_Map.Text)];
            }

            all =tb+ HH(t0) + HH(t1) + HH(t2) + HH(t3) + HH(t4) + HH(t5) + HH(t6) + HH(bz) + HH(KD) + HH(a2) + HH(a3);//整合所有文本到all里
            richTextBox1.Text = all;
            richTextBox1.SelectAll();//全选
            richTextBox1.Copy();//复制
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
            Console.WriteLine(uuid);
            return uuid;
        }

        public static string ToXmlHUN(string a)//用于生成XML文本内，作弊者名称的方法

        {
            string b = "\r\n<HackName>" + a+"</HackName>";
            return b;
        }

        public static string ToXmlRUN(string a)//用于生成XML文本内，举报者名称的方法

        {
            if (a == "")//如果没写举报者的ID则默认为空
            {

                return a;
            }
            else
            {
                string b = "\r\n<ReportName>" + a + "</ReportName>";
                return b;
            }
        }
        public static string ToXmlRT(string a)//用于生成XML文本内，作弊者作弊行为的方法

        {

            if (a == "")
            {

                return a;
            }
            else//格式为<Evil>作弊行为</Evil>
            {
                string b = "\r\n<Evil>" + a + "</Evil>";
                return b;
            }

            
        }

        private void TB_KILL_KeyPress(object sender, KeyPressEventArgs e)//限制杀敌数输入框输入内容只能为数字
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void TB_DIE_KeyPress(object sender, KeyPressEventArgs e)//限制死亡数输入框输入内容只能为数字
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bfban.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tieba.baidu.com/p/5958672389");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamcn.com/t440092-1-1");
        }

        private void button3_Click(object sender, EventArgs e)//打开服务器文档操纵窗口
        {
            ReportXMLTools reportXMLTools = new ReportXMLTools();
            reportXMLTools.Show();
        }

        private void CBB_BZ_DropDown(object sender, EventArgs e)
        {
            CBB_WQLB.Enabled = true;
            if (GV_CB.Text == "BF V")
            {
                CBB_BZ.Items.Clear();
                CBB_BZ.Items.Add("突击兵");
                CBB_BZ.Items.Add("医疗兵");
                CBB_BZ.Items.Add("侦察兵");
                CBB_BZ.Items.Add("支援兵");
                CBB_BZ.Items.Add("飞行员");
                CBB_BZ.Items.Add("驾驶员");
            }
            else
            {
                CBB_BZ.Items.Clear();
                CBB_BZ.Items.Add("突击兵");
                CBB_BZ.Items.Add("医疗兵");
                CBB_BZ.Items.Add("侦察兵");
                CBB_BZ.Items.Add("支援兵");
                CBB_BZ.Items.Add("飞行员");
                CBB_BZ.Items.Add("驾驶员");
                CBB_BZ.Items.Add("精英兵");
                CBB_BZ.Items.Add("骑兵");
                CBB_BZ.Items.Add("混合兵种");
            }
        }

        private void CBB_WQLB_DropDown_1(object sender, EventArgs e)
        {
            CBB_WQLB.Items.Clear();
            //GetLB(CBB_BZ.Text);
            string a = "BF1";
            
            if (GV_CB.Text == "BF V")
            {
                a = "BFV";
            }
            string b="";
            if (CBB_BZ.Text == "突击兵")
            {
                b  = "TJ";
            }
            else if (CBB_BZ.Text == "医疗兵")
            {
                b = "YL";
            }
            else if (CBB_BZ.Text == "支援兵")
            {
                b = "ZY";
            }
            else if (CBB_BZ.Text == "侦察兵")
            {
                b = "ZC";
            }
            else if (CBB_BZ.Text == "精英兵")
            {
                b = "JY";
            }
            else if (CBB_BZ.Text == "骑兵")
            {
                b = "QB";
            }
            else if (CBB_BZ.Text == "驾驶员")
            {
                b = "JS";
            }
            else if (CBB_BZ.Text == "飞行员")
            {
                b = "FX";
            }
            else if (CBB_BZ.Text == "混合兵种")
            {
                b = "HH";

            }
            CB_Unknow_WQ.Enabled = true;
            GetXWQLB(a, b);
        }

        private void CBB_BZ_DropDownClosed(object sender, EventArgs e)
        {
            CBB_WQLB.Items.Clear();
            CBB_WQLB.Text="";
        }

        private void GV_CB_DropDownClosed(object sender, EventArgs e)
        {
            CBB_BZ.Items.Clear();
            CBB_BZ.Text="";
            CBB_WQLB.Items.Clear();
            CBB_Map.Items.Clear();
            CBB_WQLB.Enabled = false;
            if (GV_CB.SelectedIndex == 0)
            {
                XmlDocument boce = new XmlDocument();
                boce.Load("BFReportData.xml");
                XmlNode nsss = boce.SelectSingleNode("/UseData/Game");
                nsss.InnerText = "BF1";
                boce.Save("BFReportData.xml");
            }
            else
            {
                XmlDocument boce = new XmlDocument();
                boce.Load("BFReportData.xml");
                XmlNode nsss = boce.SelectSingleNode("/UseData/Game");
                nsss.InnerText = "BFV";
                boce.Save("BFReportData.xml");

            }

        }

        private void GetXWQLB(string a, string b)
        {

            WPE.Clear();
            WPC.Clear();
            XmlDocument boc = new XmlDocument();
            boc.Load("Zh-En.xml");
            XmlNodeList nobes = boc.SelectNodes("/EnCh/" + a + "/" + b + "/L");
            string d;
            foreach (XmlNode nobe in nobes)
            {
                d = nobe.InnerText;
                string[] sArray = d.Split('#');
                WPE.Add(sArray[0]);
                WPC.Add(sArray[1]);
                CBB_WQLB.Items.Add(sArray[1]);
            }
        }

        private void GetXDTLB(string a)
        {
            ME.Clear();
            MC.Clear();
            XmlDocument boc = new XmlDocument();
            boc.Load("Zh-En.xml");
            XmlNodeList nobes = boc.SelectNodes("/EnCh/" + a + "/MAP/L");
            string d;
            foreach (XmlNode nobe in nobes)
            {
                d = nobe.InnerText;
                string[] sArray = d.Split('#');
                ME.Add(sArray[0]);
                MC.Add(sArray[1]);
                CBB_Map.Items.Add(sArray[1]);
            }
        }

        private void Name_B_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Name_B.Text);
            if (Name_B.Text == "修改")
            {
                
                Name_T.Enabled = true;
                Name_B.Text = "保存";
                Console.WriteLine(Name_B.Text);
            }
             else if(Name_B.Text == "保存")
            {
                Name_T.Enabled = false;
                Name_B.Text = "修改";
                Console.WriteLine(Name_B.Text);
                XmlDocument boce = new XmlDocument();
                boce.Load("BFReportData.xml");
                XmlNode nsss = boce.SelectSingleNode("/UseData/ReportName");
                nsss.InnerText = Name_T.Text;
                boce.Save("BFReportData.xml");

            }
        }

        private void CB_BU_Click(object sender, EventArgs e)
        {
            if (CB_BU.CheckState==CheckState.Checked)
            {
                XmlDocument boce = new XmlDocument();
                boce.Load("BFReportData.xml");
                XmlNode nsss = boce.SelectSingleNode("/UseData/Setbackups");
                nsss.InnerText ="true" ;
                boce.Save("BFReportData.xml");
            }
            else
            {
                XmlDocument boce = new XmlDocument();
                boce.Load("BFReportData.xml");
                XmlNode nsss = boce.SelectSingleNode("/UseData/Setbackups");
                nsss.InnerText = "false";
                boce.Save("BFReportData.xml");

            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                XmlDocument boce = new XmlDocument();
                boce.Load("BFReportData.xml");
                XmlNode nsss = boce.SelectSingleNode("/UseData/SetWeb");
                nsss.InnerText = "true";
                boce.Save("BFReportData.xml");
            }
            else
            {
                XmlDocument boce = new XmlDocument();
                boce.Load("BFReportData.xml");
                XmlNode nsss = boce.SelectSingleNode("/UseData/SetWeb");
                nsss.InnerText = "false";
                boce.Save("BFReportData.xml");

            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tieba.baidu.com/p/5958653939");
        }
    }
}