using WebAPITutorial.Interfaces;

namespace WebAPITutorial.Repositories
{
    public class DummyRepository : IDummyRepository
    {
        public string GetName()
        {
            return "Fırat";
        }
    }
}
