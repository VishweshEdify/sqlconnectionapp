using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlconnectionapp.DBService;
using sqlconnectionapp.Models;

namespace sqlconnectionapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> productList;
        public void OnGet()
        {           
            dbConnectionService dbConn = new dbConnectionService();
            productList = dbConn.getProduct();

        }
    }
}