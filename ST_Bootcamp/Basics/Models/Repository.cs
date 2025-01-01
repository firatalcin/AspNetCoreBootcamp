using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Models
{
    public static class Repository
    {
        private static readonly List<Course> _course = new();

        static Repository()
        {
            List<Course> courses = new List<Course>()
             {
                new Course(){Id = 1, Title = ".Net Core", Description = "C# ile yazilir", Image = "1.png"},
                new Course(){Id = 2, Title = "Spring Boot", Description = "Java ile yazilir", Image = "2.jpg"}
             };
        }

        public static List<Course> Courses
        {
            get{
                return _course;
            }
        }

        public static Course? GetById(int id){
            return _course.FirstOrDefault(x => x.Id == id);
        }
    }
}