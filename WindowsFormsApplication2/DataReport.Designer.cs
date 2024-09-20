namespace Transactions
{
    partial class DataReport
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnReportClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Top;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(404, 451);
            this.webBrowser1.TabIndex = 0;
            // 
            // btnReportClose
            // 
            this.btnReportClose.Location = new System.Drawing.Point(153, 469);
            this.btnReportClose.Name = "btnReportClose";
            this.btnReportClose.Size = new System.Drawing.Size(75, 23);
            this.btnReportClose.TabIndex = 1;
            this.btnReportClose.Text = "Close";
            this.btnReportClose.UseVisualStyleBackColor = true;
            this.btnReportClose.Click += new System.EventHandler(this.btnReportClose_Click);
            // 
            // DataReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 504);
            this.Controls.Add(this.btnReportClose);
            this.Controls.Add(this.webBrowser1);
            this.Name = "DataReport";
            this.ShowInTaskbar = false;
            this.Text = "View Data";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnReportClose;
    }
}