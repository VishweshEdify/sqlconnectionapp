using sqlconnectionapp.Models;
using System.Data.SqlClient;

namespace sqlconnectionapp.DBService
{
    public class dbConnectionService : IdbConnectionService
    {

        private readonly IConfiguration config;
        public dbConnectionService(IConfiguration _config)
        {
            config = _config;
        }
        private SqlConnection getConnection()
        {     

            return new SqlConnection(config.GetConnectionString("SQLConnection"));

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
