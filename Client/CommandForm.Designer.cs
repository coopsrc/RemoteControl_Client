namespace Client
{
    partial class CommandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandForm));
            this.richTextBoxCMD = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxCMD
            // 
            this.richTextBoxCMD.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBoxCMD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxCMD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxCMD.ForeColor = System.Drawing.Color.Lime;
            this.richTextBoxCMD.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxCMD.Name = "richTextBoxCMD";
            this.richTextBoxCMD.Size = new System.Drawing.Size(584, 361);
            this.richTextBoxCMD.TabIndex = 0;
            this.richTextBoxCMD.Text = "";
            this.richTextBoxCMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxCMD_KeyDown);
            // 
            // CommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.richTextBoxCMD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "CommandForm";
            this.Text = "命令提示符";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommandForm_FormClosed);
            this.Load += new System.EventHandler(this.CommandForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCMD;
    }
}