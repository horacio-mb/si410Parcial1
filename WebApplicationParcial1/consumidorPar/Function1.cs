
namespace consumidorPar
{
    using System;
    using consumidorPar.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync([ServiceBusTrigger("qpar", Connection = "MyConn")] string myQueueItem,
            [CosmosDB(
            databaseName:"si410-P1Horacio",
            collectionName:"paresDDBB",
            ConnectionStringSetting ="ConBasePar"
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
