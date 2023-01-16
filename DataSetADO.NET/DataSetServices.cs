using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingListApp_ADONET.DataSetADO.NET
{
    public class DataSetServices
    {
        public static void GetTablesData()
        {
            string conString = ConfigurationManager.ConnectionStrings["DataBaseConnectString"].ConnectionString;
            using SqlConnection connection = new(conString);
            string selectCmdTxt = "SELECT * FROM Customers; SELECT * FROM OrderItems";
            SqlDataAdapter dataAdapter = new(selectCmdTxt, connection);

            DataSet dataSet = new();
            dataAdapter.Fill(dataSet);

            dataSet.Tables[0].TableName = "customers";
            Console.WriteLine("CUSTOMER TABLE");
            Console.WriteLine("ID| Customer name| Phone number");
            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (DataRow row in dataSet.Tables["customers"].Rows)
            {
                Console.WriteLine($"{row[0]}, {row[1]}, {row[2]}");

            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ORDER ITEM TABLE");
            Console.WriteLine("ID| Customer ID| ItemOrder| Amount");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                Console.WriteLine(String.Format("{0}, {1}, {2} {3}", row["OrderItems_id"], row["Customer_id"], row["ItemOrder"], row["Amount"]));

            }
            Console.ForegroundColor = ConsoleColor.White;    
        }
    }
}
