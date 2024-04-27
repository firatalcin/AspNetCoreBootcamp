using MvcBasic.Models;

namespace _01_MvcBasic.Models
{
    public static class NewsContext
    {
        public static List<News> news = new List<News>()
        {
            new News() { Title = "A Haberi"},
            new News(){  Title = "B Haberi"},
            new News(){  Title = "C Haberi"}
        };
    }
}
