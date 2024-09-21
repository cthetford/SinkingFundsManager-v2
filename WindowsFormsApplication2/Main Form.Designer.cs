namespace Transactions
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAccountList = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTransTotal = new System.Windows.Forms.Label();
            this.dtTransDate = new System.Windows.Forms.DateTimePicker();
            this.lbNewBalance = new System.Windows.Forms.Label();
            this.lbOldBalance = new System.Windows.Forms.Label();
            this.dgBalances = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Monthly = new System.Windows.Forms.ToolStripMenuItem();
            this.Weekly = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Transaction = new System.Windows.Forms.ToolStripMenuItem();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadCategoryTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeOldRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgBalances)).BeginInit();
            this.Data.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbAccountList
            // 
            this.cbAccountList.FormattingEnabled = true;
            this.cbAccountList.Location = new System.Drawing.Point(83, 37);
            this.cbAccountList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAccountList.Name = "cbAccountList";
            this.cbAccountList.Size = new System.Drawing.Size(320, 24);
            this.cbAccountList.TabIndex = 1;
            this.cbAccountList.SelectedIndexChanged += new System.EventHandler(this.cbAccountList_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(856, 555);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 521);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Transaction Total:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 548);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Transaction Date:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(799, 463);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Old Balance:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(799, 495);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "New Balance:";
            // 
            // lbTransTotal
            // 
            this.lbTransTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTransTotal.AutoSize = true;
            this.lbTransTotal.Location = new System.Drawing.Point(140, 521);
            this.lbTransTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTransTotal.Name = "lbTransTotal";
            this.lbTransTotal.Size = new System.Drawing.Size(44, 17);
            this.lbTransTotal.TabIndex = 10;
            this.lbTransTotal.Text = "$0.00";
            // 
            // dtTransDate
            // 
            this.dtTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtTransDate.Location = new System.Drawing.Point(144, 548);
            this.dtTransDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtTransDate.Name = "dtTransDate";
            this.dtTransDate.Size = new System.Drawing.Size(265, 22);
            this.dtTransDate.TabIndex = 11;
            // 
            // lbNewBalance
            // 
            this.lbNewBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNewBalance.AutoSize = true;
            this.lbNewBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewBalance.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbNewBalance.Location = new System.Drawing.Point(968, 495);
            this.lbNewBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNewBalance.Name = "lbNewBalance";
            this.lbNewBalance.Size = new System.Drawing.Size(24, 25);
            this.lbNewBalance.TabIndex = 12;
            this.lbNewBalance.Text = "0";
            // 
            // lbOldBalance
            // 
            this.lbOldBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbOldBalance.AutoSize = true;
            this.lbOldBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOldBalance.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbOldBalance.Location = new System.Drawing.Point(967, 463);
            this.lbOldBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOldBalance.Name = "lbOldBalance";
            this.lbOldBalance.Size = new System.Drawing.Size(24, 25);
            this.lbOldBalance.TabIndex = 13;
            this.lbOldBalance.Text = "0";
            // 
            // dgBalances
            // 
            this.dgBalances.AllowUserToAddRows = false;
            this.dgBalances.AllowUserToDeleteRows = false;
            this.dgBalances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBalances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBalances.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgBalances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBalances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.Type,
            this.cBalance,
            this.changeAmt,
            this.nBalance,
            this.Comments});
            this.dgBalances.Location = new System.Drawing.Point(4, 71);
            this.dgBalances.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgBalances.Name = "dgBalances";
            this.dgBalances.RowHeadersVisible = false;
            this.dgBalances.Size = new System.Drawing.Size(1097, 370);
            this.dgBalances.TabIndex = 2;
            this.dgBalances.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBalances_CellMouseEnter);
            this.dgBalances.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBalances_CellValueChanged);
            // 
            // Category
            // 
            this.Category.ContextMenuStrip = this.Data;
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 130;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 130;
            // 
            // Data
            // 
            this.Data.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Data.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monthly,
            this.Weekly,
            this.toolStripSeparator3,
            this.Transaction});
            this.Data.Name = "contextMenuStrip1";
            this.Data.Size = new System.Drawing.Size(317, 82);
            this.Data.Text = "View Data";
            // 
            // Monthly
            // 
            this.Monthly.Name = "Monthly";
            this.Monthly.Size = new System.Drawing.Size(316, 24);
            this.Monthly.Text = "Monthly Balance History (12 month)";
            this.Monthly.Click += new System.EventHandler(this.Monthly_Click);
            // 
            // Weekly
            // 
            this.Weekly.Name = "Weekly";
            this.Weekly.Size = new System.Drawing.Size(316, 24);
            this.Weekly.Text = "Weekly Balance History (12 week)";
            this.Weekly.Click += new System.EventHandler(this.Weekly_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(313, 6);
            // 
            // Transaction
            // 
            this.Transaction.Name = "Transaction";
            this.Transaction.Size = new System.Drawing.Size(316, 24);
            this.Transaction.Text = "View Last 10 Transactions";
            this.Transaction.Click += new System.EventHandler(this.Transaction_Click);
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 100;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // cBalance
            // 
            this.cBalance.ContextMenuStrip = this.Data;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.cBalance.DefaultCellStyle = dataGridViewCellStyle1;
            this.cBalance.HeaderText = "Current Balance";
            this.cBalance.Name = "cBalance";
            this.cBalance.ReadOnly = true;
            this.cBalance.Width = 127;
            // 
            // changeAmt
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.changeAmt.DefaultCellStyle = dataGridViewCellStyle2;
            this.changeAmt.HeaderText = "Change Amount";
            this.changeAmt.Name = "changeAmt";
            this.changeAmt.Width = 127;
            // 
            // nBalance
            // 
            this.nBalance.ContextMenuStrip = this.Data;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.nBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.nBalance.HeaderText = "New Balance";
            this.nBalance.Name = "nBalance";
            this.nBalance.ReadOnly = true;
            this.nBalance.Width = 109;
            // 
            // Comments
            // 
            this.Comments.ContextMenuStrip = this.Data;
            this.Comments.HeaderText = "Comments";
            this.Comments.MinimumWidth = 300;
            this.Comments.Name = "Comments";
            this.Comments.Width = 300;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(972, 555);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 28);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearTransactionToolStripMenuItem,
            this.toolStripSeparator2,
            this.reloadCategoriesToolStripMenuItem,
            this.reloadCategoryTypesToolStripMenuItem,
            this.reloadAccountsToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeOldRecordsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // clearTransactionToolStripMenuItem
            // 
            this.clearTransactionToolStripMenuItem.Name = "clearTransactionToolStripMenuItem";
            this.clearTransactionToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.clearTransactionToolStripMenuItem.Text = "Clear Transaction";
            this.clearTransactionToolStripMenuItem.Click += new System.EventHandler(this.clearTransactionToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(233, 6);
            // 
            // reloadCategoriesToolStripMenuItem
            // 
            this.reloadCategoriesToolStripMenuItem.Name = "reloadCategoriesToolStripMenuItem";
            this.reloadCategoriesToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.reloadCategoriesToolStripMenuItem.Text = "Reload Categories";
            this.reloadCategoriesToolStripMenuItem.Click += new System.EventHandler(this.reloadCategoriesToolStripMenuItem_Click);
            // 
            // reloadCategoryTypesToolStripMenuItem
            // 
            this.reloadCategoryTypesToolStripMenuItem.Name = "reloadCategoryTypesToolStripMenuItem";
            this.reloadCategoryTypesToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.reloadCategoryTypesToolStripMenuItem.Text = "Reload Category Types";
            this.reloadCategoryTypesToolStripMenuItem.Click += new System.EventHandler(this.reloadCategoryTypesToolStripMenuItem_Click);
            // 
            // reloadAccountsToolStripMenuItem
            // 
            this.reloadAccountsToolStripMenuItem.Name = "reloadAccountsToolStripMenuItem";
            this.reloadAccountsToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.reloadAccountsToolStripMenuItem.Text = "Reload Accounts";
            this.reloadAccountsToolStripMenuItem.Click += new System.EventHandler(this.reloadAccountsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // removeOldRecordsToolStripMenuItem
            // 
            this.removeOldRecordsToolStripMenuItem.Name = "removeOldRecordsToolStripMenuItem";
            this.removeOldRecordsToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.removeOldRecordsToolStripMenuItem.Text = "Remove Old Records";
            this.removeOldRecordsToolStripMenuItem.Click += new System.EventHandler(this.removeOldRecordsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 598);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lbOldBalance);
            this.Controls.Add(this.lbNewBalance);
            this.Controls.Add(this.dtTransDate);
            this.Controls.Add(this.lbTransTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgBalances);
            this.Controls.Add(this.cbAccountList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Saving Balance Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBalances)).EndInit();
            this.Data.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAccountList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTransTotal;
        private System.Windows.Forms.DateTimePicker dtTransDate;
        private System.Windows.Forms.Label lbNewBalance;
        private System.Windows.Forms.Label lbOldBalance;
        private System.Windows.Forms.DataGridView dgBalances;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reloadCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadCategoryTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removeOldRecordsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip Data;
        private System.Windows.Forms.ToolStripMenuItem Monthly;
        private System.Windows.Forms.ToolStripMenuItem Weekly;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Transaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn nBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
    }
}

