using sqlconnectionapp.Models;

namespace sqlconnectionapp.DBService
{
    public interface IdbConnectionService
    {
        Task<List<Product>> getProduct();
        Task<bool> IsAlpha();
    }
}