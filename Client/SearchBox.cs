using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SearchBox : Form
    {
        public static string searchKey = null;
        public static bool condition = true;// false表示非精确查找,true表示精确查找
        
        public SearchBox()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(textBoxKey.Text!="")
            {
                searchKey = textBoxKey.Text;
            }
            else
            {
                labelWarn.Text = "请输入要查找的文件名！";
            }
            if(radioButton2.Checked)
            {
                condition = false;
            }
            this.Hide();
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            MainForm.cancled = true;
            this.Hide();
        }

        private void SearchBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            condition = true;
        }

        private void SearchBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.cancled = true;
        }

    }
}
