using EmailClientWebApp.Service;
using EmailClientWebApp.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;

namespace EmailClientWebApp.Pages
{
    public class ImapModel : PageModel
    {
        public List<MessageHeader> Headers { get; set; }
        public int MsgNumber { get; set; }

        private readonly ImapServices _imapServices;

        public ImapModel()
        {
            _imapServices = new ImapServices();
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
                Headers = _imapServices.GetHeaders(username, password, MsgNumber);
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
