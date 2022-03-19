using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionRouter
{
    public static class ApiAddTicket
    {
        [Function("ApiAddTicket")]
        public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            var json = await req.ReadAsStringAsync();
            Console.WriteLine(json);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            var http = new HttpClient();
            await http.PostAsync("https://pabamacorp.com/api/addticket", data);

            return response;
        }
    }
}
