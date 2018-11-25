using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BF1Report
{
    public partial class UpDelApply : Form
    {
        public string UpDelApplytext;
        public UpDelApply(string HackName,string Game,string UpTime)
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Text = HackName;
            textBox2.Text = Game;
            textBox3.Text = UpTime;
            richTextBox1.Enabled = false;
            label4.Enabled = false;
            comboBox1.SelectedIndex = 0;

        }

        private void tijiao_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 5)
            {
                UpDelApplytext = comboBox1.Text;
                Close();
            }
            else if (comboBox1.SelectedIndex == 5 & richTextBox1.Text == "")
            {
                MessageBox.Show("你还没填写理由");
            }
            else if (comboBox1.SelectedIndex == 5 & richTextBox1.Text != "")
            {
                UpDelApplytext = comboBox1.Text + "|" + richTextBox1.Text;
                Close();
            }
        }


        private void quxiao_Click(object sender, EventArgs e)
        {
            UpDelApplytext = "关闭";
            Close();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 5)
            {
                richTextBox1.Enabled = true;
                label4.Enabled = true;
            }
            else
            {
                richTextBox1.Enabled = false;
                label4.Enabled = false;
            }

        }
    }
}
