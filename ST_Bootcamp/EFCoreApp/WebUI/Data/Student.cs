namespace WebUI.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NameSurname
        {
            get
            {
                return this.Name + " " + this.Surname;
            }
        }
        public ICollection<Register> Registers { get; set; }
    }
}
