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
    
    public partial class NewFileBox : Form
    {
        public static string newName = "";
        public NewFileBox(string type)
        {
            InitializeComponent();            
            textBoxName.Text = type;
        }

        private void buttonNewFile_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            if (name.Contains(@"\") || name.Contains(@"/") || name.Contains(@":") || name.Contains(@"*") ||
                name.Contains(@"?") || name.Contains(@"#") || name.Contains("\"") || name.Contains(@"”")
                || name.Contains(@"“") || name.Contains(@"<") || name.Contains(@">"))
            {
                labelWarn.Text = @"文件名中不得包含\ / : * ? # ” < > | ";
            }
            else if (textBoxName.Text == "")
            {
                labelWarn.Text = "文件名不能为空！";
            }        
            else
            {
                newName = textBoxName.Text;
                this.Hide();
            }
        }

        private void NewFileBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.cancled = true;
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            MainForm.cancled = true;
            this.Hide();
        }
    }
}
