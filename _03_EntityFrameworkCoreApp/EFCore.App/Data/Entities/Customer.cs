using System.ComponentModel.DataAnnotations;

namespace EFCore.Data
{
    public class Customer
    {
        //[Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
