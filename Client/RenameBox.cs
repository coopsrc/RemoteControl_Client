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
    public partial class RenameBox : Form
    {
        public static string newName = null;
        public string oldName = null;      
      
        public RenameBox(string oldName)
        {
            InitializeComponent();
            this.oldName = oldName;
            newName = null;
            string[] splitStr = oldName.Split('.');
            textBoxName.Text = splitStr[0];
            if (splitStr.Length == 2)
                labelExtendName.Text = splitStr[1];
            else
                labelExtendName.Text = "";
        }
        // \     /    :    *   ?    #   ”   <   >   |
        private void buttonOK_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            if (name.Contains(@"\") || name.Contains(@"/") || name.Contains(@":") || name.Contains(@"*") ||
                name.Contains(@"?") || name.Contains(@"#") || name.Contains("\"") || name.Contains(@"”")
                || name.Contains(@"“") || name.Contains(@"<") || name.Contains(@">"))
            {
                labelWarn.Text = @"文件名中不得包含\ / : * ? # ” < > | ";
            }
            else if(textBoxName.Text == "")
            {
                labelWarn.Text = "文件名不能为空！";
            }
            else
            {
                if (labelExtendName.Text != "")
                    newName = textBoxName.Text + "." + labelExtendName.Text;
                else
                    newName = textBoxName.Text;
                this.Hide();
            }
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            MainForm.cancled = true;
            this.Hide();           
        }

        private void RenameBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void RenameBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.cancled = true;
        }

        
    }
}
