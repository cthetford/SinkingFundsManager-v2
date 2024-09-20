﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transactions
{
    public partial class DataReport : Form
    {
        public DataReport(string html)
        {
            InitializeComponent();
            webBrowser1.DocumentText = html;
        }

        private void btnReportClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
