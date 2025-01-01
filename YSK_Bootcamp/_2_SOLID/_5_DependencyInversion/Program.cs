namespace _5_DependencyInversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Index();
            Index2();
            Index3();
        }

        static void Index()
        {
            Repository repository = new Repository();
            repository.GetInstance().GetCategories();
        }

        static void Index2()
        {
            Repository repository = new Repository();
            repository.GetInstance().GetCategories();
        }

        static void Index3()
        {
            Repository repository = new Repository();
            repository.GetInstance().GetCategories();
        }
    }

    interface IRepository
    {
        void GetCategories();
    }

    class Repository
    {
        public IRepository GetInstance()
        {
            return new HibernateCategoryRepository();
        }
    }




    class EFCategoryRepository : IRepository
    {
        public void GetCategories()
        {
            Console.WriteLine("EF");
        }
    }

    class DapperCategoryRepository : IRepository
    {
        public void GetCategories()
        {
            Console.WriteLine("Dapper");
        }
    }

    class HibernateCategoryRepository : IRepository
    {
        public void GetCategories()
        {
            Console.WriteLine("Hibernate");
        }
    }
}
