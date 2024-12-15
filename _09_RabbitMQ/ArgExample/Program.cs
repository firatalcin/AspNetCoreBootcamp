namespace ArgExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                foreach (var item in args)
                {
                    Console.WriteLine("Item: " + item);
                }
            }
            else
            {
                Console.WriteLine("Hello World");
            }
        }
    }
}
