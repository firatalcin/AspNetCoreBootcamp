using RabbitMQ.Client;
using System.Text;

static string GetMessage(string[] args)
{
    return args.Length > 0 ? string.Join(" ", args) : "Hello World";
}

var message = GetMessage(args);

int dots = message.Split('.').Length -1 ;
Thread.Sleep(dots * 1000);

var factory = new ConnectionFactory();
factory.HostName = "localhost";
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare("hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
channel.BasicPublish(exchange: string.Empty, routingKey: "hello", basicProperties: null, body: Encoding.UTF8.GetBytes(message));
