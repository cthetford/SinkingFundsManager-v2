using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Transactions
{
    public class SavingsDatabase
    {
        static String dbFile =  "SavingsDatabase.sqlite";
        SQLiteConnection dbConnection;
        static bool Changed = false;


        public string fileName() { return dbFile; }

        public SavingsDatabase()
        {
            if (File.Exists(dbFile))
            {
                Initialize();
            }
            else
            {
                CreateNew();
            }
        }

        public void Close()
        {
            dbConnection.Close();
        }

        internal void Execute(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            Changed = true;
        }

        private void CreateNew()
        {
            SQLiteConnection.CreateFile(dbFile);

            Initialize();

            string sql = "create table d_Accounts (name varchar(50))";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            Transactions.Account.loadDbFromFile(this);

            sql = "create table d_Categories (account varchar(50), name varchar(50), hidden character(1), type varchar(20))";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            Transactions.Category.loadDbFromFile(this);

            sql = "create table Transactions (account varchar(50), id integer, create_ts datetime, category varchar(50), net_change decimal(10,2), comment varchar (256))";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "create table d_Types (name varchar(50), color varchar(20))";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            Transactions.CategoryType.loadDbFromFile(this);

            sql = "CREATE TABLE d_Date( `Date` , `Year` int, `Month` int, `MonName` , `DayName` , `WeekOfYear` int, `DayOfYear` int, `DayOfWeek` int, `MonthStart` , `MonthEnd` , `WeekStart` , `WeekEnd` )";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            Transactions.Account.loadDateFromFile(this);


            // Create views to enable reporting

            sql = "CREATE VIEW v_TotalsByMonth as select account, category, strftime('%Y', create_ts) as Y, strftime('%m', create_ts) as M, max(create_ts) as maxdate, sum(net_change) as amt from Transactions group by account, category, Y, M";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE VIEW v_PeriodTotals as select a.account, a.category, a.maxdate, strftime('%Y-%m', a.maxdate) as period, max(a.amt) as month_change, sum(b.amt) as ending_balance from v_TotalsByMonth a left join v_TotalsByMonth b on a.account = b.account and a.category = b.category and b.maxdate <= a.maxdate group by 1,2,3,4";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE VIEW v_TotalsByWeek as select account, category, strftime('%Y',create_ts) as Y, strftime('%W',create_ts) as M, max(create_ts) as maxdate, sum(net_change) as amt from Transactions group by account, category, Y, M";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE VIEW v_WeeklyTotals as select a.account, a.category, a.maxdate, strftime('%Y-%W', a.maxdate) as period, max(a.amt) as week_change, sum(b.amt) as ending_balance from v_TotalsByWeek a left join v_TotalsByWeek b on a.account = b.account and a.category = b.category and b.maxdate <= a.maxdate group by 1,2,3,4";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        internal SQLiteDataReader ExecuteReader(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            return command.ExecuteReader();
        }

        private void Initialize()
        {
            dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            dbConnection.Open();
        }

        public static string DateTimeSQLite(DateTime datetime)
        {
            //string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return datetime.ToString("yyyy-MM-dd HH:mm:ss");
            // return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }

        internal void Backup()
        {
            if (!Changed) return;

            System.IO.DirectoryInfo d = System.IO.Directory.CreateDirectory("Backup");

            FileInfo[] files = d.GetFiles();

            foreach (FileInfo fi in files)
            {
                if (fi.LastAccessTime < DateTime.Now.AddDays(-7))
                    fi.Delete();
            }

            string dir = System.IO.Directory.GetCurrentDirectory();
            string target = "Backup\\" + Path.GetFileName(dbFile)+ "." + DateTime.Now.ToString("yyyyMMdd-HHmmss");
            System.IO.File.Copy(dbFile,target);
            

        }
    }
}
