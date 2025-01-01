using System.ComponentModel.DataAnnotations;

namespace WebUI.Data
{
    public class Teacher
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
