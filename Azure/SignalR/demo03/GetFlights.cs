using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SignalRFlights
{
    public static class GetFlights
    {
        [FunctionName("GetFlights")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
            [CosmosDB("demo", "flights", ConnectionStringSetting = "signalrcosmosdb_DOCUMENTDB")]
                IEnumerable<object> flights,
            ILogger log)
        {
            return new OkObjectResult(flights);
        }
    }
}
