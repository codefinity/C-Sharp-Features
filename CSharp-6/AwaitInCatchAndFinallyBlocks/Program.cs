using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AwaitInCatchAndFinallyBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MakeRequestAndLogFailures();
        }

        public static async Task<string> MakeRequestAndLogFailures()
        {
            //The implementation details for adding await support inside catch and finally 
            //clauses ensure that the behavior is consistent with the behavior for synchronous code. 
            //When code executed in a catch or finally clause throws, execution looks for a suitable 
            //catch clause in the next surrounding block.If there was a current exception, that exception 
            //is lost.The same happens with awaited expressions in catch and finally clauses: 
            //a suitable catch is searched for, and the current exception, if any, is lost.

            await LogMethodEntrance();
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                await LogError("Recovered from redirect", e);
                return "Site Moved";
            }
            finally
            {
                await LogMethodExit();
                client.Dispose();
            }
        }

        private static Task LogMethodEntrance()
        {
            throw new NotImplementedException();
        }

        private static Task LogMethodExit()
        {
            throw new NotImplementedException();
        }

        private static Task LogError(string v, HttpRequestException e)
        {
            throw new NotImplementedException();
        }
    }
}
