using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions;
using ExtensionMethods;

namespace Transactions
{
    class Reports
    {
        static public  string CategoryHistory(List<Transaction> tlist)
        {
            string result = "";

            if (tlist.Count == 0)
            {
                result += "<h3><center>No Transaction history for this category.</center></h3><p></p>";
            }
            else
            {
                result += "<h3><center>Transaction history for category '" + tlist[0].category + "'</center></h3><p></p>";
                result += "<table border=\"1\" style=\"width: 100 % \">";
                result += "<tr><th>Date</th><th>Comment</th><th>Change</th>";
            }

            
            foreach (Transaction t in tlist )
            {
                result += "<tr><td>" + t.transactionDate.ToString() + "</td><td>" + t.comment + "</td><td>" + String.Format("{0:C}", t.amount) + "</td></tr>";
            }

            result += "</table>";

            return result;
        }

        internal static string MonthlyHistory(List<Transaction> tlist)
        {
            string result = "";

            if (tlist.Count == 0)
            {
                result += "<h3><center>No Transaction history for this category.</center></h3><p></p>";
            }
            else
            {
                result += "<h3><center>Monthly history for category '" + tlist[0].category + "'</center></h3><p></p>";
                result += "<table border=\"1\" style=\"width: 100 % \">";
                result += "<tr><th>Period</th><th>Change</th><th>Ending Amt</th>";
            }


            foreach (Transaction t in tlist)
            {
                result +=  "<tr><td>" + t.transactionDate.ToString("yyyy-MMM")+ "</td><td>" + String.Format("{0:C}", t.amount) + "</td><td>" + String.Format("{0:C}", t.total) + "</td></tr>";
            }

            result += "</table>";

            return result;
        }

        internal static string WeeklyHistory(List<Transaction> tlist)
        {
            string result = "";

            if (tlist.Count == 0)
            {
                result += "<h3><center>No Transaction history for this category.</center></h3><p></p>";
            }
            else
            {
                result += "<h3><center>Weekly history for category '" + tlist[0].category + "'</center></h3><p></p>";
                result += "<table border=\"1\" style=\"width: 100 % \">";
                result += "<tr><th>Week Ending</th><th>Change</th><th>Ending Amt</th>";
            }


            foreach (Transaction t in tlist)
            {
                result += "<tr><td>" + t.transactionDate.ToString("yyyy-MM-dd") + "</td><td>" + String.Format("{0:C}", t.amount) + "</td><td>" + String.Format("{0:C}", t.total) + "</td></tr>";
            }

            result += "</table>";

            return result;
        }
    }
}
