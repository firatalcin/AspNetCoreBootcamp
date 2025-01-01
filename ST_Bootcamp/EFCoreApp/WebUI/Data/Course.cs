namespace WebUI.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Register> Registers { get; set; }
    }
}
