using EmailClientWebApp.Service;
using EmailClientWebApp.Services.Entities;
using MailKit;
using MailKit.Net.Pop3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailClientWebApp.Pages
{
    public class PopThreeModel : PageModel
    {
        public List<MessageHeader> Headers { get; set; }
        public int MsgNumber { get; set; }
        private readonly PopThreeServices _popThreeServices;

        public PopThreeModel() 
        {
            _popThreeServices = new PopThreeServices();
        }
        public IActionResult OnGet(string msgNumber)
        {
            string username = HttpContext.Session.GetString("email");
            string password = HttpContext.Session.GetString("password");

            if (msgNumber == null)
            {
                MsgNumber = 10; 
            }
            else
            {
                MsgNumber = Int32.Parse(msgNumber);
            }

            try
            {
                Headers = _popThreeServices.GetHeaders(username, password, MsgNumber);
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
