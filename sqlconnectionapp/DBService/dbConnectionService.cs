using Microsoft.FeatureManagement;
using sqlconnectionapp.Models;
using System.Data.SqlClient;

namespace sqlconnectionapp.DBService
{
    public class dbConnectionService : IdbConnectionService
    {

        private readonly IConfiguration config;
        private readonly IFeatureManager _featureManager;
        public dbConnectionService(IConfiguration _config , IFeatureManager featureManager)
        {
            config = _config;
            _featureManager = featureManager;
        }
        private SqlConnection getConnection()
        {     

            return new SqlConnection(config["SQLConnection"]);

        }

        public async Task<bool> IsAlpha()
        {
            if (await _featureManager.IsEnabledAsync("alpha"))
                return true;
            else 
                return false;

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
