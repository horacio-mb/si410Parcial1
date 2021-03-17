using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace consumidorImpar
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("myqueue", Connection = "Endpoint=sb://qparmolina.servicebus.windows.net/;SharedAccessKeyName=EnviarImpar;SharedAccessKey=4yUPFjhWIqvzHKVXaFeD7B5EZTXCp3+XyicdcIMlFUo=;EntityPath=qimpar")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
