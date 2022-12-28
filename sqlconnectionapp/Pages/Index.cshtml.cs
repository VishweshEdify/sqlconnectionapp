using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlconnectionapp.DBService;
using sqlconnectionapp.Models;

namespace sqlconnectionapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> productList;
        public bool isAlpha;

        private readonly IdbConnectionService connDB;

    public IndexModel(IdbConnectionService _connDB)
        {
            connDB = _connDB;
        }
        public void OnGet()
        {
            isAlpha = connDB.IsAlpha().Result;
            productList = connDB.getProduct();

        }
    }
}