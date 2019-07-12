using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionOliAPI.Entities;


namespace FunctionOliAPI
{
    public static class FunctionOliUrl
    {
        [FunctionName("FunctionOliUrl")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            JsonSerializerSettings formatJson = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver()
            };
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            /* string str = Environment.GetEnvironmentVariable("sqlCustomer");

            if (string.IsNullOrEmpty(str))
            {
                return Funciones.DevolverError("register reservation ", "428",
                                                "You must configure the database connection!");
            }*/

            if (data != null)
            {
                var dataSent = new DataSent
                {
                    NameCustomer = (string)data?.NameCustomer,
                    EmailCustomer = (string)data?.EmailCustomer,
                    IdBusiness = (int)data?.IdBusiness,
                    StartDate = (DateTime)data?.StartDate,
                    EndDate = (DateTime)data?.EndDate
                };
            }

            /* using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                var insert = "INSERT INTO dbo.tbl_reserv(" +
                                "NameCustomer, " +
                                "EmailCustomer, " +
                                "IdBusiness, " +
                                "StartDate, " +
                                "EndDate, " +
                                "VALUES ('" +
                                dataSent.NameCustomer + "', " +
                                dataSent.EmailCustomer + ", '" +
                                dataSent.IdBusiness + "', '" +
                                dataSent.StartDate + "', '" +
                                dataSent.EndDate + "'); ";

                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                    log.Info("The record is created in the database! " + dataSent.IdCustomer.ToString());
                    
                    DataBack dataBack = new DataBack
                    {
                        IdCustomer = 1036,
                        UrlWebchat = "www.bot.com/"
                    };

                    return new JsonResult(dataBack, formatoJson);
                }
            }*/

            var dataBack = new DataBack
            {
                IdCustomer = 1036,
                UrlWebchat = "www.bot.com/"
            };

            return new JsonResult(dataBack, formatJson);

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
