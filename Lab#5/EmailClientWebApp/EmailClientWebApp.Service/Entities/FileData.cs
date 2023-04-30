using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClientWebApp.Service.Entities
{
    public class FileData
    {
        public byte[] FileContents;
        public string ContentType;
        public string FileDownloadName;


        public FileData(byte[] fileContents, string contentType, string fileDownloadName) 
        { 
            FileContents = fileContents;
            ContentType = contentType;
            FileDownloadName = fileDownloadName;
        }
    }
}
