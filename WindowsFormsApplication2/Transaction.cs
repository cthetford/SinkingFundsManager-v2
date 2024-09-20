using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Transactions
{

    public class Account
    {
        public string name;

        public static void loadDbFromFile(SavingsDatabase db)
        {
            string[] lineOfContents = File.ReadAllLines("Data\\Accounts.txt");
            String sql;

            sql = "delete from d_Accounts";
            db.Execute(sql);

            foreach (var line in lineOfContents)
            {
                if (line.Trim()[0] == '#') { continue; }
                sql = "insert into d_Accounts (name) values ('" + line.Trim().Replace("'", "''") + "')";
                db.Execute(sql);
            }
        }

        internal static string[] ReadAllFromDb(SavingsDatabase db)
        {
            string sql = "select * from d_Accounts order by name";
            List<string> results = new List<string>();

            SQLiteDataReader reader = db.ExecuteReader(sql);

            while (reader.Read())
                results.Add(reader["name"].ToString());

            return results.ToArray();
        }

        internal static void loadDateFromFile(SavingsDatabase db)
        {
            return; 

        }
    }


    public class CategoryType
    {
        public string name;

        public static void loadDbFromFile(SavingsDatabase db)
        {
            string[] lineOfContents = File.ReadAllLines("Data\\Types.txt");
            String sql;

            sql = "delete from d_Types";
            db.Execute(sql);

            foreach (var line in lineOfContents)
            {
                if (line.Trim()[0] == '#') { continue; }
                string[] tokens = line.Split(',');

                String name = tokens[0].Replace("'", "''");
                String color = tokens[1];

                sql = "insert into d_Types (name, color) values ('" + name + "','" + color + "')";
                db.Execute(sql);

            }
        }
    }


    public class Category
    {
        public string name;
        public string type;
        public string hidden;
        public string color;
        public float total;

        internal static void loadDbFromFile(SavingsDatabase db)
        {
            string[] lineOfContents = File.ReadAllLines("Data\\Categories.txt");
            String sql;

            sql = "delete from d_Categories";
            db.Execute(sql);

            foreach (var line in lineOfContents)
            {
                if (line.Trim()[0] == '#') { continue; }
                string[] tokens = line.Split(',');

                String account = tokens[0].Replace("'", "''");
                String name = tokens[1].Replace("'", "''");
                String hidden = tokens[2];
                String type = tokens[3].Replace("'", "''");

                sql = "insert into d_Categories (account, name, hidden, type) values ('" + account + "','" + name + "','" + hidden + "','" + type + "')";
                db.Execute(sql);
            }
        }

        internal static Dictionary<string, Category> readFromDb(SavingsDatabase db, string account)
        {
            account = account.Replace("'", "''");
            string sql = "select d_Categories.*, d_Types.color from d_Categories left join d_Types on d_Categories.type = d_Types.name where account = '" + account + "' order by name";
            Dictionary<string, Category> results = new Dictionary<string, Category>();

            SQLiteDataReader reader = db.ExecuteReader(sql);

            while (reader.Read()) { 
                Transactions.Category c = new Transactions.Category();
                c.name = reader["name"].ToString();
                c.type = reader["type"].ToString();
                c.hidden = reader["hidden"].ToString();
                c.color = reader["color"].ToString().Trim();
                c.total = 0;
                results.Add(c.name, c);
            }
            return results;
        }
    }


    public class Transaction
    {
        public int id;
        public DateTime transactionDate;
        public string category;
        public float amount;
        public float total;
        public string comment;
        public bool newTransaction;

        public Transaction(DateTime d, string cat, float a, string comm)
        {
            id = -1;
            transactionDate = d;
            category = cat;
            amount = a;
            comment = comm;
        }
        public Transaction()
        {
            
        }

        public void parse(string data)
        {
            string[] lines = data.Split('|');

            id = Int32.Parse(lines[0]);
            transactionDate = DateTime.Parse(lines[1]);
            category = lines[2];
            amount = Convert.ToSingle(lines[3]);
            comment = lines[4];
            newTransaction = false;
        }

        public string toFileLine()
        {
            string result;

            result = id + "|";
            result += transactionDate.ToString() + "|";
            result += category + "|";
            result += amount.ToString() + "|";
            result += comment;

            return result;
        }

        internal string toValues()
        {
            // account, id, create_ts, category, net_change, comment
            string result = "";
            result +=  this.id  + ",";
            result += "'" + SavingsDatabase.DateTimeSQLite(this.transactionDate) + "',";
            result += "'" + this.category.Replace("'", "''") + "',";
            result += "'" + this.amount + "',";
            result += "'" + this.comment + "'";

            return result;
        }
    }

    public class TransactionList
    {
        List<Transaction> transactions;
        int currentTransactionIdx;
        int latestId;
        string account;
        private SavingsDatabase myDb;



        public Dictionary<string, float> categoryTotals { get; set; }

        public TransactionList(SavingsDatabase db, string a)
        {
            account = a.Replace("'","''");
            myDb = db;
            transactions = new List<Transaction>();
            Load();
        }

        private void Load()
        {
            currentTransactionIdx = -1;
            categoryTotals = new Dictionary<string, float>();
            ReadTotals();
            latestId = readLatestId();
        }

        private int readLatestId()
        {
            string sql = "select max(id) from Transactions where account = '" + account + "'";

            SQLiteDataReader reader = myDb.ExecuteReader(sql);

            long result = 0;
            try
            {
                while (reader.Read())
                    result = reader.GetInt64(0);
            }
            catch { }

            return (int) result;
        }

        private void ReadTotals()
        {
            categoryTotals.Clear();
            string sql = "select category, sum(net_change) as total from Transactions where account = '" + account + "' group by category";

            SQLiteDataReader reader = myDb.ExecuteReader(sql);

            while (reader.Read())
                categoryTotals.Add(reader["category"].ToString(), reader.GetFloat(1));
        }

        public float getCategorySum(string category)
        {
            float result = categoryTotals[category];

            return result;
        }

        public void addTransaction(Transaction t, bool updateTotals = true)
        {
            if (t.amount == 0 && t.comment.Length == 0) return;   // don't add empty transactions


            t.newTransaction = true;
            transactions.Add(t);
            if (updateTotals)
            {
                try
                {
                    categoryTotals[t.category] += t.amount;
                }
                catch { categoryTotals[t.category] = t.amount; }
            }

        }




        internal int getCategoryTransactionIndex(string entry)
        {
            int result = -1;

            int x;
            for (x = currentTransactionIdx; x < transactions.Count && transactions[x].category != entry && transactions[x].transactionDate == transactions[currentTransactionIdx].transactionDate; x++) ;

            if (x < transactions.Count &&
                transactions[x].transactionDate == transactions[currentTransactionIdx].transactionDate &&
                transactions[x].category == entry) result = x;

            return result;
        }


        internal DateTime getTransactionDate()
        {
            return transactions[currentTransactionIdx].transactionDate;
        }

        public int count()
        {
            return transactions.Count;
        }



        public void Write()
        {
            string sql;
            latestId++;

            foreach (Transaction t in transactions)
            {
                if (!t.newTransaction) continue;

                t.id = latestId;
                string values;
                values = t.toValues();

                sql = "insert into Transactions (account, id, create_ts, category, net_change, comment) values ('" + account + "'," + values + ")";
                myDb.Execute(sql);

            }

            transactions.Clear();
        }


        internal float getTransactionTotal()
        {
            float result = 0;
            foreach (KeyValuePair<string, float> entry in categoryTotals)
            {
                result += entry.Value;

            }

            return result;
        }

        internal int getNextID()
        {
            throw new NotImplementedException();
        }

        internal void Archive()
        {
            MessageBox.Show("Archiving not implemented");
            /*
            Transaction.ClearTable(myDb);

            currentTransactionIdx = -1;

            foreach (KeyValuePair<string, float> entry in categoryTotals)
            {
                if (entry.Value != 0)
                {
                    Transaction t = new Transaction("0", DateTime.Now, entry.Key, entry.Value, "Starting Balance");
                    count++;

                    addTransaction(t, false);
                }
            }
            File.Copy(filename, System.IO.Path.GetFileNameWithoutExtension(filename) 
                               + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", true);

            ReWrite();
            */
        }

        internal List<Transaction> getRecent(int numToGet, string selCategory)
        {
            /*
             * select * from (
             * select 
             * create_ts,
             * net_change as amt, comment
             * from Transactions
             * where account = 'Primary Savings'
             * and Category = 'Discover' 
             * order by create_ts desc
             * LIMIT 0, 10) 
             * order by create_ts
             */
            string sql;
            sql = "select * from (select create_ts, net_change as amt, 0 as dummy_total, comment from Transactions";
            sql += " where account='" + account.Replace("'", "''") + "'";
            sql += " and category='" + selCategory.Replace("'", "''") + "'";
            sql += " order by create_ts desc LIMIT 0, 10) order by create_ts";

            return getRresults(sql, selCategory);
        }

        private List<Transaction> getRresults(string sql, string cat)
        {
            List<Transaction> results = new List<Transaction>();

            SQLiteDataReader reader = myDb.ExecuteReader(sql);

            string dt;
            while (reader.Read())
            {
                Transactions.Transaction t = new Transactions.Transaction();
                t.category = cat;
                t.comment = reader["comment"].ToString();
                dt = reader.GetString(0).Substring(0,10);
                t.transactionDate = DateTime.ParseExact(dt, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                t.amount = reader.GetFloat(1);
                t.total = reader.GetFloat(2);
                results.Add(t);
            }

            return results;
        }

        internal List<Transaction> getRecentMonths(int v, string selCategory)
        {
            /*
              select * from (
              select * from v_PeriodTotals
              where account = "Primary Savings" and category = "Discover"
              order by 1,2,3 desc
              limit 10)
 */
            string sql;
            sql = "select * from (select maxdate, month_change, ending_balance, period as comment from v_PeriodTotals";
            sql += " where account='" + account.Replace("'", "''") + "'";
            sql += " and category='" + selCategory.Replace("'", "''") + "'";
            sql += " order by 1 desc limit " + v +") order by 1";

            return getRresults(sql, selCategory);
        }

        internal List<Transaction> getRecentWeeks(int v, string selCategory)
        {
            /*
              select * from (
              select * from v_WeeklyTotals
              where account = "Primary Savings" and category = "Discover"
              order by 1,2,3 desc
              limit 10)
 */
            string sql;
            sql = "select * from (select maxdate, week_change, ending_balance, maxdate,' ' as comment from v_WeeklyTotals";
            sql += " where account='" + account.Replace("'", "''") + "'";
            sql += " and category='" + selCategory.Replace("'", "''") + "'";
            sql += " order by 1 desc  limit " + v + ") order by 1";

            return getRresults(sql, selCategory);
        }
    }
}
