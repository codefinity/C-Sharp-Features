using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionFilters
{
    internal class WebRequest
    {
        public async static Task<string> MakeRequest()
        {

            using HttpClient client = new HttpClient();

            try
            {
                string responseBody = await client.GetStringAsync("http://www.this-site-should-never-ever-exist.net/");

                return responseBody;
            }
            catch (HttpRequestException e) when (e.Message.Contains("No such host is known"))
            {
                return "Site Moved";
            }

        }
    }
}
