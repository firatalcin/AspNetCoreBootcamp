namespace _1_SingleResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    class Customer
    {
        public string Name { get; set; }
    }

    class CustomerValidator
    {
        public bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }
    }

    class CustomerManager
    {
        public void SayHello(string name)
        {
            Console.WriteLine("Hello " + name);
        }
    }
}
