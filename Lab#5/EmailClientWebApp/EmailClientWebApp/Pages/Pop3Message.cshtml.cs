using MailKit.Net.Pop3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using MimeKit;
using System.IO;
using System.Linq;
using EmailClientWebApp.Services.Entities;
using EmailClientWebApp.Service;
using EmailClientWebApp.Service.Entities;
using Microsoft.AspNetCore.Http;

namespace EmailClientWebApp.Pages
{
    public class MessageModel : PageModel
    {
        public MsgToDisplay Msg { get; set; }
        private readonly PopThreeServices _popThreeServices;

        public MessageModel() 
        {
            _popThreeServices = new PopThreeServices();
        }

        public IActionResult OnGet(string id)
        {
            string username = HttpContext.Session.GetString("email");
            string password = HttpContext.Session.GetString("password");

            try
            {
                Msg = _popThreeServices.GetMessageById(username, password, Int32.Parse(id));
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPostDownload(string msgId, string attachId)
        {
            string username = HttpContext.Session.GetString("email");
            string password = HttpContext.Session.GetString("password");

            FileData file;

            try
            {
                file = _popThreeServices.GetAttachment(username, password, msgId, attachId);
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return File(file.FileContents, file.ContentType, file.FileDownloadName);
        }
    }
}
