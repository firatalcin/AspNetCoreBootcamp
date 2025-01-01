namespace EFCore.Dependency.Services
{
    public class ScopedManager : IScopedService
    {
        private string _guidId;

        public ScopedManager()
        {
            _guidId = Guid.NewGuid().ToString();
        }

        public string GuidId => _guidId;
    }
}
