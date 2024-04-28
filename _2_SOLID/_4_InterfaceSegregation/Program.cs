namespace _4_InterfaceSegregation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        interface IRepository
        {
            void Add();


        }

        interface IProductRepository : IRepository
        {
            void GetProducts();
        }

        interface ICategoryRepository : IRepository
        {
            void GetCategories();
        }


        class CategoryRepository : ICategoryRepository
        {
            public void Add()
            {
                throw new NotImplementedException();
            }

            public void GetCategories()
            {
                throw new NotImplementedException();
            }
        }

        class ProductRepository : IProductRepository
        {
            public void Add()
            {
                throw new NotImplementedException();
            }

            public void GetProducts()
            {
                throw new NotImplementedException();
            }
        }
    }
}
