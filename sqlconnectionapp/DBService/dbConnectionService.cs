using Microsoft.FeatureManagement;
using sqlconnectionapp.Models;
using System.Data.SqlClient;
using System.Text.Json;

namespace sqlconnectionapp.DBService
{
    public class dbConnectionService : IdbConnectionService
    {

        private readonly IConfiguration config;
        private readonly IFeatureManager _featureManager;
        public dbConnectionService(IConfiguration _config, IFeatureManager featureManager)
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

        public async Task<List<Product>> getProduct()
        {
            //var conn = getConnection();
            //List<Product> productList = new List<Product>();

            //conn.Open();
            //string query = "SELECT ProductID , ProductName , Quantity FROM Products";
            //SqlCommand comm = new SqlCommand(query, conn);

            //using (SqlDataReader reader = comm.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        Product product = new Product();
            //        product.ProductId = reader.GetInt32(0);
            //        product.ProductName = reader.GetString(1);
            //        product.Quantity = reader.GetInt32(2);
            //        productList.Add(product);
            //    }
            //}
            //conn.Close();

            //return productList;

            string functionURL = "https://myfirstfunctionvish.azurewebsites.net/api/GetProducts?code=k2nHSENnUmDfp3t9VYxhbyVN-KG-dO2KelBtI6P2V1uWAzFuS9416A==";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(functionURL);
                HttpResponseMessage res = await client.GetAsync(functionURL);
                var content = await res.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Product>>(content);

            }
    
        }
    }
}
