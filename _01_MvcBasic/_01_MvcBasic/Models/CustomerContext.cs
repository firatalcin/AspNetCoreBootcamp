namespace MvcBasic.Models
{
    public static class CustomerContext
    {
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer() { Id = 1, FirstName = "Fırat", LastName = "Kahraman", Age = 25},
            new Customer(){ Id  =2, FirstName = "Enes", LastName = "Çiçek", Age=25}
        };
    }
}
