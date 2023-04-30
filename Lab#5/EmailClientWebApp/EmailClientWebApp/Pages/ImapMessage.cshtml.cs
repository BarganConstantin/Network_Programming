using EmailClientWebApp.Service;
using EmailClientWebApp.Service.Entities;
using EmailClientWebApp.Services.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EmailClientWebApp.Pages
{
    public class ImapMessageModel : PageModel
    {
        public MsgToDisplay Msg { get; set; }
        private readonly ImapServices _imapServices;

        public ImapMessageModel()
        {
            _imapServices = new ImapServices();
        }

        public IActionResult OnGet(string id)
        {
            string username = HttpContext.Session.GetString("email");
            string password = HttpContext.Session.GetString("password");

            try
            {
                Msg = _imapServices.GetMessageById(username, password, Int32.Parse(id));
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
                file = _imapServices.GetAttachment(username, password, msgId, attachId);
            }
            catch (Exception)
            {
                return RedirectToPage("/Error");
            }

            return File(file.FileContents, file.ContentType, file.FileDownloadName);
        }
    }
}
