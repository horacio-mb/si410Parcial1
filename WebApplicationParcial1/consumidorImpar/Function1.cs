using System;
using System.Threading.Tasks;
using consumidorImpar.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace consumidorImpar
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync([ServiceBusTrigger("qimpar", Connection = "MyConn")]string myQueueItem, 
            [CosmosDB(
            databaseName:"si410-P1Horacio",
            collectionName:"imparesDDBB",
            ConnectionStringSetting ="ConBaseImPar"
            )]IAsyncCollector<object> datos,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Data>(myQueueItem);

                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No fue posible insertar datos:{ex.Message}");
            }
        }
    }
}
