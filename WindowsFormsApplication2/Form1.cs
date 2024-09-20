using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GridPrintPreviewLib;
using static Transactions.CategoryType;


namespace Transactions
{


    public partial class Form1 : Form
    {
       
            public const int catColumn = 0;
            public const int typeColumn = 1;
            public const int currColumn = 2;
            public const int chgColumn = 3;
            public const int newColumn = 4;
            public const int commColumn = 5;

 

        Dictionary<string, Category> categoryList;
        bool loading;
        TransactionList transactions;
        bool modified = false;
        string mode = "Add";
        Transactions.SavingsDatabase myDb;
        private String currentAccount;

        public Form1()
        {
            loading = true;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void cbAccountList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckModified();

            loading = true;
            currentAccount = cbAccountList.SelectedItem.ToString();
            ReadCategories(currentAccount);
            transactions = new TransactionList(myDb, currentAccount);
            UpdateCategoryTotals();

            AddCategoriesToGrid();

            loading = false;
        }

        private void CheckModified()
        {
            if (modified)
            {
                DialogResult dialogResult = MessageBox.Show("Current Transaction was not saved.  Do you want to save it?", "Modified", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (mode == "Add") SaveCurrent();
                    else UpdateCurrent();
                }
               
            }
        }

        private void UpdateCategoryTotals()
        {
           
            List<string> keys = new List<string>(categoryList.Keys);
            foreach (string key in keys)

            {

                try
                {
                    categoryList[key].total = transactions.categoryTotals[key];
                }
                catch { categoryList[key].total = 0; }
            }
        }

        private void AddCategoriesToGrid()
        {
            int index;
            Category c;

            if (categoryList == null) return;

            dgBalances.Rows.Clear();
            foreach (KeyValuePair<string, Category> entry in categoryList)
            {
                c = entry.Value;

                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle { ForeColor = Color.FromName(entry.Value.color) };
                if (c.hidden != "Y")
                {
                    index = dgBalances.Rows.Add();
                    dgBalances.Rows[index].Cells[catColumn].Value = entry.Key;
                    dgBalances.Rows[index].Cells[typeColumn].Value = entry.Value.type;

                    if (entry.Value.color != "")
                    {
                        dgBalances.Rows[index].Cells[catColumn].Style = cellStyle;
                        dgBalances.Rows[index].Cells[typeColumn].Style = cellStyle;
                        dgBalances.Rows[index].Cells[currColumn].Style = cellStyle;
                        dgBalances.Rows[index].Cells[chgColumn].Style = cellStyle;
                        dgBalances.Rows[index].Cells[newColumn].Style = cellStyle;
                       
                    }

                }

            }

            dgBalances.Sort(dgBalances.Columns[0], ListSortDirection.Ascending);
            startNewTransaction();
        }

        private void ReadCategories(string account)
        {
            categoryList = Transactions.Category.readFromDb(myDb, account);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myDb = new SavingsDatabase();

            readAccountList();

            loading = false;
        }

        private void startNewTransaction()
        {
            dtTransDate.Value = DateTime.Now;
            float Balance = 0;


            foreach (DataGridViewRow r in dgBalances.Rows)
            {
                string entry = r.Cells[catColumn].Value.ToString();
                r.Cells[currColumn].Value = categoryList[entry].total;
                r.Cells[chgColumn].Value = 0;
                r.Cells[newColumn].Value = categoryList[entry].total;
                r.Cells[commColumn].Value = "";
                
            }

            Balance = transactions.getTransactionTotal();
            lbOldBalance.Text = String.Format("${0:C2}", Balance.ToString());
            lbNewBalance.Text = String.Format("${0:C2}", Balance.ToString());
            modified = false;
            mode = "Add";
        }


        private void displayOldTransaction()
        {
            /*
            loading = true;

            CheckModified();
            UpdateCategoryTotals();

            dtTransDate.Value = transactions.getTransactionDate() ;
            float Balance = 0;
            float adjustments = 0;


            foreach (DataGridViewRow r in dgBalances.Rows)
            {
                string entry = r.Cells[catColumn].Value.ToString();
                r.Cells[newColumn].Value = categoryList[entry].total;
                r.Cells[chgColumn].Value = transactions.getCategoryTransactionAmount(entry);
                r.Cells[currColumn].Value = categoryList[entry].total - transactions.getCategoryTransactionAmount(entry);
                r.Cells[commColumn].Value = transactions.getCategoryTransactionComment(entry);
                adjustments += transactions.getCategoryTransactionAmount(entry);
            }

            Balance = transactions.getTransactionTotal();
            lbTransTotal.Text = String.Format("${0:C2}", adjustments.ToString());
            lbOldBalance.Text = String.Format("${0:C2}", (Balance - adjustments).ToString()) ;
            lbNewBalance.Text = String.Format("${0:C2}", Balance.ToString());

            loading = false;
            mode = "Update";
            modified = false;
            */

        }

        private void readAccountList()
        {
            string[] lineOfContents = Account.ReadAllFromDb(myDb);
            foreach (var line in lineOfContents)
            {
                //string[] tokens = line.Split(',');
                cbAccountList.Items.Add(line);
                cbAccountList.SelectedIndex = 0;
                
            }
            currentAccount = cbAccountList.Items[0].ToString();
        }

        private void dgBalances_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loading) return;

            modified = true;
            float transTotal = 0;
            int i = 0;


            foreach (DataGridViewRow r in dgBalances.Rows)
            {
                i++;
                float oAmt = Convert.ToSingle(r.Cells[currColumn].Value.ToString());
                float tAmt = Convert.ToSingle(r.Cells[chgColumn].Value.ToString());
                float nAmt = oAmt + tAmt;
                transTotal += tAmt;

                r.Cells[newColumn].Value = nAmt;
            }

            float oldTotal = transactions.getTransactionTotal();
            lbTransTotal.Text = String.Format("${0:C2}", transTotal.ToString());
            lbOldBalance.Text = String.Format("${0:C2}", oldTotal.ToString());
            lbNewBalance.Text = String.Format("${0:C2}", (oldTotal + transTotal).ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys == Keys.Control))
            {
                if (mode != "Add" || modified)
                {
                    MessageBox.Show("Archive functionality only works when no changes have been made!");
                }
                else
                {
                    transactions.Archive();
                    MessageBox.Show("Archive complete!");

                }
            }
            else
            {
                if (mode == "Add") SaveCurrent();
                else UpdateCurrent();
            }
           
        }

        private void SaveCurrent()
        {
            foreach (DataGridViewRow r in dgBalances.Rows)
            {
                float amt = Convert.ToSingle(r.Cells[chgColumn].Value.ToString());
                string comment = r.Cells[commColumn].Value.ToString();
                string category = r.Cells[catColumn].Value.ToString();

                if (amt != 0 || comment.Length > 0)
                {
                    Transaction t = new Transaction(dtTransDate.Value, category, amt, comment);

                    transactions.addTransaction(t);
                }

            }

            transactions.Write();
            UpdateCategoryTotals();
            startNewTransaction();

            System.Windows.Forms.MessageBox.Show("Transaction Saved and totals updated.");
            modified = false;
        }

        private void UpdateCurrent()
        {
            System.Windows.Forms.MessageBox.Show("Updating not implemented.");

            /*
            foreach (DataGridViewRow r in dgBalances.Rows)
            {
                float amt = Convert.ToSingle(r.Cells[chgColumn].Value.ToString());
                string comment = r.Cells[commColumn].Value.ToString();
                string category = r.Cells[catColumn].Value.ToString();

                transactions.updateTransaction(category, amt, comment);
            }

            transactions.ReWrite();
            modified = false;

            displayOldTransaction();

            System.Windows.Forms.MessageBox.Show("Transaction Saved and totals updated.");
            */
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified) CheckModified();
            myDb.Close();

            myDb.Backup();
        }

        private void btnShowLast_Click(object sender, EventArgs e)
        {
            displayOldTransaction();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // https://www.codeproject.com/Articles/36488/DataGridView-Print-Print-Preview-Solution-Part-I
            // dataGridView1 is the DataGridView to print
            GridPrintDocument doc = new GridPrintDocument(this.dgBalances,
                                    this.dgBalances.Font, true);
            doc.DocumentName = "Savings Balances";
            GridSelectedArea selArea = new GridSelectedArea(0, 0, 2, dgBalances.RowCount-1);
            doc.SelectedArea = selArea;


            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.ClientSize = new Size(400, 300);
            printPreviewDialog.Location = new Point(29, 29);
            printPreviewDialog.Name = "Print Preview Dialog";
            printPreviewDialog.UseAntiAlias = true;
            printPreviewDialog.Document = doc;
            printPreviewDialog.ShowDialog();
            doc.Dispose();
            doc = null;
        }

        private void dgBalances_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void clearTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckModified();
            startNewTransaction();
        }

        private void reloadCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will re-load the Category list from categories.txt.  Do you want to continue?", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Transactions.Category.loadDbFromFile(myDb);
                MessageBox.Show("Please re-start this program to see the changes.");
            }
        }

        private void reloadCategoryTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will re-load the Category types and colors from Types.txt.  Do you want to continue?", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Transactions.CategoryType.loadDbFromFile(myDb);
                MessageBox.Show("Please re-start this program to see the changes.");
            }
        }

        private void reloadAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will re-load the Accounts from Accounts.txt.  Do you want to continue?", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Transactions.Account.loadDbFromFile(myDb);
                MessageBox.Show("Please re-start this program to see the changes.");
            }
        }

        private void Transaction_Click(object sender, EventArgs e)
        {
            List<Transaction> recent;
            string selCategory;

            selCategory = dgBalances.Rows[mouseLocation.RowIndex].Cells[0].Value.ToString();
            recent = transactions.getRecent(10, selCategory);

            DataReport r = new DataReport(Reports.CategoryHistory(recent));
            r.ShowDialog();
        }

        private DataGridViewCellEventArgs mouseLocation;
        private void dgBalances_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }

        private void Monthly_Click(object sender, EventArgs e)
        {
            List<Transaction> recent;
            string selCategory;

            selCategory = dgBalances.Rows[mouseLocation.RowIndex].Cells[0].Value.ToString();
            recent = transactions.getRecentMonths(12, selCategory);

            DataReport r = new DataReport(Reports.MonthlyHistory(recent));
            r.ShowDialog();
        }

        private void Weekly_Click(object sender, EventArgs e)
        {
            List<Transaction> recent;
            string selCategory;

            selCategory = dgBalances.Rows[mouseLocation.RowIndex].Cells[0].Value.ToString();
            recent = transactions.getRecentWeeks(12, selCategory);

            DataReport r = new DataReport(Reports.WeeklyHistory(recent));
            r.ShowDialog();
        }

        private void removeOldRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function Not Available Yet");
        }
    }
}
