using sqlconnectionapp.Models;
using System.Data.SqlClient;

namespace sqlconnectionapp.DBService
{
    public class dbConnectionService
    {
        private static string source = "az204firstdbserver.database.windows.net";
        private static string userName = "vishgmail";
        private static string password = "Es@1506@pN";
        private static string database = "az204firstdb";

        private SqlConnection getConnection()
        {
            var dbString = new SqlConnectionStringBuilder();
            dbString.DataSource = source;
            dbString.UserID = userName;
            dbString.Password = password;
            dbString.InitialCatalog = database;

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = dbString.ConnectionString;
            return myConnection;

        }

        public List<Product> getProduct()
        {
            var conn = getConnection();
            List<Product> productList = new List<Product>();

            conn.Open();
            string query = "SELECT ProductID , ProductName , Quantity FROM Products";
            SqlCommand comm = new SqlCommand(query, conn);

            using (SqlDataReader reader = comm.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.Quantity = reader.GetInt32(2);
                    productList.Add(product);
                }
            }
            conn.Close();  

            return productList;
        }
    }
}
