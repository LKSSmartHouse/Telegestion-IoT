//https://telegestion-iot.azurewebsites.net/api/HttpTrigger1?freq=100

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Devices;
using System.Text;

namespace Company.Function
{
    public static class HttpTrigger1
    {
        private const string iotConnectionString = "HostName=iothub-deusto.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=JFIJGmHCl+c6YkyQQcPJts0j0ZQRLon07AIoTGzJ8ek=";
        private const string targetDevice = "smartmeter1";

        [FunctionName("HttpTrigger1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string freq = req.Query["freq"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            freq = freq ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(freq)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {freq}. This HTTP triggered function executed successfully.";

            await SendCloudToDeviceMessageAsync(freq);

            return new OkObjectResult(responseMessage);
        }

        private async static Task SendCloudToDeviceMessageAsync(string freq)
        {
            ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(iotConnectionString);

            var commandData = new
            {
                freq_ = freq
            };

            string jsonMessage = JsonConvert.SerializeObject(commandData);

            var commandMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            {
            ContentType = "application/json", 
            ContentEncoding = "utf-8" 
            };

            await serviceClient.SendAsync(targetDevice, commandMessage);
        }
    }
}
