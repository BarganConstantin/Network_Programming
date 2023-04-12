using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTPClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClientApp httpClientApp = new HttpClientApp();

            httpClientApp.Run();
        }
    }
}
