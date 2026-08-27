using System.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockRoute.Models;

namespace StockRoute.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        public void OnGet()
        {
        }

        public void OnPostLogin()
        {
            var login = new StockRoute.Models.Login("", "");
            var hasher = new PasswordHasher<object>();

            string passwordHash = hasher.HashPassword(null, this.Password);

            var user = this.Username;
            var password = this.Password;
            if (password == null)
            {
                Redirect("/Error");
            }
        }
    }
}
