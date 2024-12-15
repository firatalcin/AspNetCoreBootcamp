using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ.Producer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConnectionFactory
            //Connection
            //Channel

            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments:  null);

            var message = "Hello RabbitMQ";

            var byteMessage = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: byteMessage);

            Console.WriteLine("Mesaj Gönderildi");
        }
    }
}
