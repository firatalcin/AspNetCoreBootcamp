namespace EFCore.Dependency.Services
{
    public class SingletonManager : ISingletonService
    {
        private string _guidId;

        public SingletonManager()
        {
            _guidId = Guid.NewGuid().ToString();
        }

        public string GuidId => _guidId;
    }
}
