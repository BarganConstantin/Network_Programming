using MailKit.Net.Pop3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EmailClientWebApp.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string email, string password)
        {
            try
            {
                using (var client = new Pop3Client())
                {
                    client.Connect("pop.mail.ru", 995, true);
                    client.Authenticate(email, password);
                }
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("password", password);

            return RedirectToPage("/Index");
        }
    }
}
