using System.Configuration;
using System.Data.SqlClient;

namespace ShoppingListApp_ADONET.SQLDataReader
{
    public static class DataReaderServices
    {
        public static void FetchTableData()
        {
            string conString = ConfigurationManager.ConnectionStrings["DataBaseConnectString"].ConnectionString;
            using SqlConnection connection = new(conString);
            string cmdText = "SELECT * FROM Customers";
            using SqlCommand sqlCommand = new(cmdText, connection);
            connection.Open();

            Console.WriteLine("Fetching Table........");
            Thread.Sleep(1000);
            Console.WriteLine("| Customer ID| Customer Name| Customer phoneNumber |");
            Console.WriteLine("CUSTOMER TABLE");
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            while (sqlReader.Read())
            {
                Console.WriteLine(String.Format("{0}  | {1}  | {2}", sqlReader[0], sqlReader[1], sqlReader[2]));
            }
        }

    }
}
