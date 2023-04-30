using EmailClientWebApp.Service;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using System;
using System.Collections.Generic;

namespace EmailClientWebApp.Pages
{
    public class SendMsgModel : PageModel
    {
        private readonly SmtpService _smtpService;

        public SendMsgModel() 
        {
            _smtpService = new SmtpService();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string to, string subject, string message, List<IFormFile> attachment) 
        {
            string username = HttpContext.Session.GetString("email");
            string password = HttpContext.Session.GetString("password");

            try
            {
                _smtpService.sendNewEmail(username, password, to, subject, message, attachment);
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/Index");
        }
    }
}
