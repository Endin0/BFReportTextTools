using Aliyun.OSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BF1Report
{
    public partial class ReportXMLTools : Form
    {
        List<string> UUIDlist = new List<string>();
        List<string> XMLlist = new List<string>();
        List<string> FMD5list = new List<string>();
        string BUUID;
        string a;
        string b;
        string c;
        public string UpDelApplytext;
        int T;

        public ReportXMLTools()
        {

            InitializeComponent();
            CBB_CXXZ.SelectedIndex = 2;
            textBox1.Text ="UUID:"+ uuid();
            BUUID = uuid();
            List<string> FMD5list = new List<string>();//该数组用于存放服务器上读取的各个文件MD5代码
            XmlDocument doc = new XmlDocument();
            doc.Load("http://bf1report.oss-cn-beijing.aliyuncs.com/version/Version.xml");
            XmlNodeList nodes = doc.SelectNodes("/FWQXX/BBXX");
            foreach (XmlNode node in nodes)//将服务器的版本信息存入FMD5list数组
            {
                FMD5list.Add(node.InnerText);
            }

            a = "oss-cn-beijing.aliyuncs.com";
            b = "LTAIjOoHVuoXjhf8";
            c = "zTuZWpU3hdd6cPT0oVcsOIpxGgxtpC";
            ListObject( a, b,c,1);
 

        }
        //mod 0:查看全部档案列表
        //mod 1:查看没有申请删除的档案
        //mod 2:查看申请删除的档案


        public void ListObject( string a, string b, string c,int mod)
        {                                                         
            var client = new OssClient(a, b, c);
        
                ObjectListing result = null;
                string nextMarker = string.Empty;
                do
                {
                    // 每页列举的文件个数通过maxKeys指定，超过指定数将进行分页显示。
                    var listObjectsRequest = new ListObjectsRequest("bf1report")
                    {
                        Marker = nextMarker,
                        MaxKeys = 100
                    };
                    result = client.ListObjects(listObjectsRequest);
                    Console.WriteLine("File:");
                    int count = 0;
                    foreach (var summary in result.ObjectSummaries)
                    {
                        count += 1;
                        //Match m = Regex.Match(summary.Key, "/.+/(?<name1>.*)xml");
                        //Match d = Regex.Match(summary.Key, "Data/.+/.*?");
                        Match x = Regex.Match(summary.Key, "(Data/(?<name1>[^/]*).xml)");
                        // Match dux = Regex.Match(summary.Key, "Data/.+/.+xml");
                        //Match dx = Regex.Match(summary.Key, "(Data/(?<FileName>[^/]*).xml)|(Data/(?<Folder>[^/]*)/(?<FileName>[^/]*).xml)");
                        //Console.WriteLine(dx.Groups["FileName"].Value);
                        //GetMetaTime(dx.Groups["Folder"].Value, dx.Groups["FileName"].Value);



                        //MOD模式

                        //if (mod == 0)
                        //{

                        //    var oldMeta = client.GetObjectMetadata("bf1report", "Data/" + x.Groups["name1"].Value.ToString() + ".xml");
                        //    //listBox1.Items.Add(x.Groups["name1"].Value);
                        //    //fileName.Value = dx.Groups["FileName"].Value;
                        //    //dataGridView1.Rows.Add(row);
                        //        int index = dataGridView1.Rows.Add();
                        //        dataGridView1.Rows[index].Cells[0].Value = x.Groups["name1"].Value;//HackName
                        //        dataGridView1.Rows[index].Cells[1].Value = oldMeta.UserMetadata["reportname"];//ReportName
                        //        dataGridView1.Rows[index].Cells[2].Value = oldMeta.UserMetadata["uuid"];//UUID
                        //        DateTime st = oldMeta.LastModified;
                        //        dataGridView1.Rows[index].Cells[3].Value = st.ToLocalTime();//UpTime
                        //        dataGridView1.Rows[index].Cells[4].Value = oldMeta.UserMetadata["gamebb"];


                        //}
                         if (mod == 1)
                         {
                            if (x.Groups["name1"].Value.ToString() != "")
                            {

                                var oldMeta = client.GetObjectMetadata("bf1report", "Data/" + x.Groups["name1"].Value.ToString() + ".xml");
                                //listBox1.Items.Add(x.Groups["name1"].Value);
                                //fileName.Value = dx.Groups["FileName"].Value;
                                //dataGridView1.Rows.Add(row);
                                if (oldMeta.UserMetadata["delappyly"] == "no")
                                {
                                    int index = dataGridView1.Rows.Add();
                                    dataGridView1.Rows[index].Cells[0].Value = x.Groups["name1"].Value;//HackName
                                    dataGridView1.Rows[index].Cells[1].Value = oldMeta.UserMetadata["reportname"];//ReportName
                                    dataGridView1.Rows[index].Cells[2].Value = oldMeta.UserMetadata["uuid"];//UUID
                                    DateTime st = oldMeta.LastModified;
                                    dataGridView1.Rows[index].Cells[3].Value = st.ToLocalTime();//UpTime
                                    dataGridView1.Rows[index].Cells[4].Value = oldMeta.UserMetadata["gamebb"];
                                }

                            }
                        }
                        else if (mod == 2)
                        {
                            if (x.Groups["name1"].Value.ToString() != "")
                            {

                                var oldMeta = client.GetObjectMetadata("bf1report", "Data/" + x.Groups["name1"].Value.ToString() + ".xml");
                                //listBox1.Items.Add(x.Groups["name1"].Value);
                                //fileName.Value = dx.Groups["FileName"].Value;
                                //dataGridView1.Rows.Add(row);
                                if (oldMeta.UserMetadata["delappyly"] != "no")
                                {
                                    int index = dataGridView1.Rows.Add();
                                    dataGridView1.Rows[index].Cells[0].Value = x.Groups["name1"].Value;//HackName
                                    dataGridView1.Rows[index].Cells[1].Value = oldMeta.UserMetadata["reportname"];//ReportName
                                    dataGridView1.Rows[index].Cells[2].Value = oldMeta.UserMetadata["uuid"];//UUID
                                    DateTime st = oldMeta.LastModified;
                                    dataGridView1.Rows[index].Cells[3].Value = st.ToLocalTime();//UpTime
                                    dataGridView1.Rows[index].Cells[4].Value = oldMeta.UserMetadata["gamebb"];
                                }

                            }
                        }
                    }
                    nextMarker = result.NextMarker;
                } while (result.IsTruncated);
        


        }

        public string GetMetaTime(string a, string b)
        {
            string c;
            var client = new OssClient(FMD5list[13], FMD5list[14], FMD5list[15]);
            try
            {
                using (var fs = File.Open(a, FileMode.Open))
                {
                    // 获取文件元信息。
                    if (a == "")
                    {
                        var oldMeta = client.GetObjectMetadata("bf1report", b);
                        c = oldMeta.ToString();
                    }
                    else
                    {
                        var oldMeta = client.GetObjectMetadata("bf1report", a+"/"+b);
                        c = oldMeta.ToString();
                    }
                    
                }
                Console.WriteLine("C:" + c);
                return c;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Put object failed, {0}", ex.Message);
                return c="";
            }
        }


        public string uuid()//获取UUID
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
            Console.WriteLine("UUID:" + uuid);
            return uuid;
        }

        private void Myxml_Click(object sender, EventArgs e)
        {
            ListObject(a, b, c, 1);
            button2.Text = "提交申请删除档案";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
             {
                     if (dataGridView1.Rows[i].Cells[2].Value.ToString() != BUUID)
                     {
                          DataGridViewRow row = dataGridView1.Rows[i];
                         dataGridView1.Rows.Remove(row);
                         i--;
                     }

                
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                try
                {
                    string o = "";
                    List<string> Text = new List<string>();
                    XmlDocument doc = new XmlDocument();
                    int index = dataGridView1.CurrentRow.Index;


                    doc.Load("http://bf1report.oss-cn-beijing.aliyuncs.com/Data/" + dataGridView1.Rows[index].Cells[0].Value.ToString() + ".xml");
                    var client = new OssClient(a, b, c);
                    var oldMeta = client.GetObjectMetadata("bf1report", "Data/" + dataGridView1.Rows[index].Cells[0].Value.ToString() + ".xml");
                    o = "Game:" + oldMeta.UserMetadata["gamebb"] + "\n";


                    XmlNodeList nodes = doc.SelectNodes("/ReportText/Evil");
                    foreach (XmlNode node in nodes)
                    {
                       o = o + node.InnerText + "\n";
                    }
                    richTextBox1.Text = o;
                    richTextBox1.SelectAll();//全选
                    richTextBox1.Copy();//复制
                }
                catch
                { }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            ListObject(a,b,c,1);
            button2.Text = "提交申请删除档案";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(dataGridView1.Rows.Count);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //Console.WriteLine("DataUUID:"+dataGridView1.Rows[i].Cells[2].Value.ToString() );
                //Console.WriteLine("UUID:"+ BUUID);
                //Console.WriteLine("比结果:" + dataGridView1.Rows[i].Cells[2].Value.ToString() != BUUID);
                if (dataGridView1.Rows[i].Cells[T].Value.ToString() != CX_BOX.Text)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    dataGridView1.Rows.Remove(row);
                    i--;
                }


            }
        }

        private void GV_CB_DropDownClosed(object sender, EventArgs e)
        {
            if (CBB_CXXZ.Text == "作弊玩家ID") 
            {
                T = 0;
            }
            if (CBB_CXXZ.Text == "举报者ID") 
            {
                T = 1;
            }
            if (CBB_CXXZ.Text == "UUID") 
            {
                T = 2;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("Downloadxml") == false)//如果不存
            {
                Directory.CreateDirectory("Downloadxml");
            }
            WebClient Client = new WebClient();
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                Client.DownloadFile("http://bf1report.oss-cn-beijing.aliyuncs.com/Data/" + dataGridView1.Rows[index].Cells[0].Value.ToString() + ".xml", "Downloadxml/" + dataGridView1.Rows[index].Cells[0].Value.ToString()+".xml");//5
            }
            catch { MessageBox.Show("下载失败", "失败", MessageBoxButtons.OK); }
            MessageBox.Show("档案已从服务器下载到软件根目录下的Downloadxml文件夹内", "完成", MessageBoxButtons.OK);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string a="";
            List<string> Text = new List<string>();
            XmlDocument doc = new XmlDocument();
            int index = dataGridView1.CurrentRow.Index;
            doc.Load("http://bf1report.oss-cn-beijing.aliyuncs.com/Data/" + dataGridView1.Rows[index].Cells[0].Value.ToString() + ".xml");
            XmlNode nod = doc.SelectSingleNode("/ReportText/Game");
            try
            {
                a = a + nod.InnerText + "\n";
            }
            catch
                { }

            XmlNodeList nodes = doc.SelectNodes("/ReportText/Evil");
            foreach (XmlNode node in nodes)
            {
                a=a+node.InnerText+ "\n";
            }
            richTextBox1.Text = a;
            richTextBox1.SelectAll();//全选
            richTextBox1.Copy();//复制
            Console.WriteLine(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new OssClient(a, b, c);
            if (dataGridView1.RowCount != 0)
            { 
            int index = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[index].Cells[2].Value.ToString() == BUUID)
                {
                    //string f = "http://bf1report.oss-cn-beijing.aliyuncs.com/Data/" + dataGridView1.Rows[index].Cells[0].Value.ToString() + ".xml";
                    //try
                    //{
                    //    client.DeleteObject("bf1report", "Data/" + dataGridView1.Rows[index].Cells[0].Value.ToString() + ".xml");
                    //    Console.WriteLine("Delete object succeeded");
                    //    DataGridViewRow row = dataGridView1.Rows[index];
                    //    dataGridView1.Rows.Remove(row);
                    //}
                    //catch (Exception ex)
                    //{
                    //MessageBox.Show("删除失败. {0}", ex.Message);
                    //}
                    UpDelApply upDel = new UpDelApply(dataGridView1.Rows[index].Cells[0].Value.ToString(), dataGridView1.Rows[index].Cells[4].Value.ToString(), dataGridView1.Rows[index].Cells[3].Value.ToString());
                    upDel.UpDelApplytext = "";
                    upDel.ShowDialog();
                    UpDelApplytext = upDel.UpDelApplytext;
                    if (UpDelApplytext == "关闭")
                    {

                    }
                    else
                    {
                        var newMeta = new ObjectMetadata();

                        newMeta.UserMetadata.Add("reportname", dataGridView1.Rows[index].Cells[1].Value.ToString());
                        newMeta.UserMetadata.Add("uuid", dataGridView1.Rows[index].Cells[2].Value.ToString());
                        newMeta.UserMetadata.Add("gamebb", dataGridView1.Rows[index].Cells[4].Value.ToString());
                        newMeta.UserMetadata.Add("DelAppyly", UpDelApplytext);
                        try
                        {
                            client.ModifyObjectMeta("bf1report", "Data/" + dataGridView1.Rows[index].Cells[0].Value.ToString() + ".xml", newMeta);
                            MessageBox.Show("已经成功提交申请,现在" + dataGridView1.Rows[index].Cells[0].Value.ToString() + "的档案不会主动加载出来,如果申请不通过,它将会重新出现列表里");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("上传meta出错, {0}", ex.Message);
                            MessageBox.Show("上传meta出错," + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
               else
               {
                   MessageBox.Show("无权限操作他人档案");
               }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                int index = dataGridView1.CurrentRow.Index;

                XmlDocument boc = new XmlDocument();
                boc.Load("BFReportData.xml");
                XmlNode nobes = boc.SelectSingleNode("/UseData/SetWeb");
                if (nobes.InnerText == "true")
                {
                    System.Diagnostics.Process.Start("https://www.origin.com/irl/zh-tw/search?searchString=" + dataGridView1.Rows[index].Cells[0].Value.ToString());
                }
                else
                {
                    MessageBox.Show("这是利用EA的官网进行查找,需要在网页上登陆后才能搜索到用户\n\r[可以在主界面的选择中关闭这个弹窗提示]");
                    System.Diagnostics.Process.Start("https://www.origin.com/irl/zh-tw/search?searchString=" + dataGridView1.Rows[index].Cells[0].Value.ToString());
                }

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                System.Diagnostics.Process.Start("https://battlefieldtracker.com/bf1/profile/pc/" + dataGridView1.Rows[index].Cells[0].Value.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                System.Diagnostics.Process.Start("http://bf1stats.com/pc/" + dataGridView1.Rows[index].Cells[0].Value.ToString());
            }
        }

        private void ReportXMLTools_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            ListObject(a, b, c, 2);
            button2.Text = "更改删除的理由";
        }
    }

}