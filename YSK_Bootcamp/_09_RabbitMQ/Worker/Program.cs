using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.HostName = "localhost";
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    Thread.Sleep(2000);
    var byteMessage = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(byteMessage);
    Console.WriteLine("Okunan Mesaj : " + message);
};

channel.BasicConsume(queue: "hello", autoAck: false, consumer: consumer);
