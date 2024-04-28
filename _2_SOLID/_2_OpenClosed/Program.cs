namespace _2_OpenClosed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalaryCalculater salaryCalculater = new SalaryCalculater(new PartTimeEmployee());

            salaryCalculater.CalculateSalary();
        }
    }

    interface IEmployee
    {
        void CalculateSalary();

    }

    class FullTimeEmployee : IEmployee
    {
        public void CalculateSalary()
        {
            Console.WriteLine("Full");
        }
    }



    class PartTimeEmployee : IEmployee
    {
        public void CalculateSalary()
        {
            Console.WriteLine("Part");
        }
    }

    class SupportEmployee : IEmployee
    {
        public void CalculateSalary()
        {
            Console.WriteLine("Part");
        }
    }

    class SalaryCalculater
    {
        private readonly IEmployee employee;

        public SalaryCalculater(IEmployee employee)
        {
            this.employee = employee;
        }

        public void CalculateSalary()
        {
            this.employee.CalculateSalary();
        }
    }
}
