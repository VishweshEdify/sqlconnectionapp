using sqlconnectionapp.Models;

namespace sqlconnectionapp.DBService
{
    public interface IdbConnectionService
    {
        List<Product> getProduct();
        Task<bool> IsAlpha();
    }
}