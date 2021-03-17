using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using WebApplicationParcial1.Models;
using Newtonsoft.Json;

namespace WebApplicationParcial1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {
            //Impar Enviar
            string connectionStringImp = "Endpoint=sb://qparmolina.servicebus.windows.net/;SharedAccessKeyName=EnviarImpar;SharedAccessKey=4yUPFjhWIqvzHKVXaFeD7B5EZTXCp3+XyicdcIMlFUo=;EntityPath=qimpar";
            string queueNameImp = "qimpar";
            //Par Enviar
            string connectionStringP = "Endpoint=sb://qparmolina.servicebus.windows.net/;SharedAccessKeyName=EnviarPar;SharedAccessKey=lramtoolIvDlaDXwwbped+ykR3fhyXmZh/5BOgGZ3OI=;EntityPath=qpar";
            string queueNameP = "qpar";
            ///
            string Mensaje = JsonConvert.SerializeObject(data);
            if (data.random % 2 == 0){
                //es par
                // create a Service Bus client 
                await using (ServiceBusClient client = new ServiceBusClient(connectionStringP))
                {
                    // create a sender for the queue 
                    ServiceBusSender sender = client.CreateSender(queueNameP);

                    // create a message that we can send
                    ServiceBusMessage message = new ServiceBusMessage(Mensaje);

                    // send the message
                    await sender.SendMessageAsync(message);
                    Console.WriteLine($"Sent a single message to the queue: {queueNameP}");
                }

            }
            else {
                // es impar
                await using (ServiceBusClient client = new ServiceBusClient(connectionStringImp))
                {
                    // create a sender for the queue 
                    ServiceBusSender sender = client.CreateSender(queueNameImp);

                    // create a message that we can send
                    ServiceBusMessage message = new ServiceBusMessage(Mensaje);

                    // send the message
                    await sender.SendMessageAsync(message);
                    Console.WriteLine($"Sent a single message to the queue: {queueNameImp}");
                }

            }
            

            return true;
        }
        

    }
}
