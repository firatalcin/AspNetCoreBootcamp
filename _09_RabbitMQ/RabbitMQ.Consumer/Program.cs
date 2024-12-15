using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQ.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConnectionFactory
            //Connection

            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var byteMessage = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(byteMessage);
                Console.WriteLine("Okunan Mesaj : " + message);
            };

            channel.BasicConsume(queue: "hello", autoAck: false, consumer: consumer);
        }
    }
}
