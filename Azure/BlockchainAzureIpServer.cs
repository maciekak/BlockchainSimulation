#r "Newtonsoft.Json"

using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static string Ip {get;set;}

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
            if(req.Method == "POST")
            {
                log.LogInformation("Set Ip");

                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                Ip = data?.Ip;
                log.LogInformation(Ip);
                return new OkObjectResult(Ip);
            }
            else 
            {
                log.LogInformation("Get Ip");

                return await Task.FromResult(new OkObjectResult(Ip));
            }
}
