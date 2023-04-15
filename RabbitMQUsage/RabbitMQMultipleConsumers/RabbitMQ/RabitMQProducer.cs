
using global::RabbitMQ.Client;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
namespace RabbitMQMultipleConsumers.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using
            var channel = connection.CreateModel();
            //declare the exchange with fanout type
            channel.ExchangeDeclare("product", ExchangeType.Fanout);
            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue
            channel.BasicPublish(exchange: "product", routingKey: string.Empty, body: body);
        }
    }
}

