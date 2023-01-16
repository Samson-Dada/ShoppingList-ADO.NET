using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ShoppingListApp_ADONET.SQLDataAdapter
{
    public static class DataAdapterServices
    {
        public static void GetData()
        {

            string conString = ConfigurationManager.ConnectionStrings["DataBaseConnectString"].ConnectionString;
            using SqlConnection connection = new(conString);
            string selectCmdTxt = "GetCustomerByID";
            SqlDataAdapter dataAdapter = new(selectCmdTxt, connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("Enter Customer ID Here");
            string addValue = Console.ReadLine();
            dataAdapter.SelectCommand.Parameters.AddWithValue("@Customer_id", addValue);
            Thread.Sleep(1000);
            //DataSet dataSet =  new DataSet();
            System.Data.DataSet dataSet = new();
            dataAdapter.Fill(dataSet);
            Console.WriteLine("CUSTOMER TABLE");
            Console.WriteLine("ID| CustomerName| MobileNumber");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine($"{row[0]}, {row[1]}, {row[2]}");
            }
        }
    }
}
