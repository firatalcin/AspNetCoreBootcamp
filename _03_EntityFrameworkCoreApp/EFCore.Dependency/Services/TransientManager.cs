namespace EFCore.Dependency.Services
{
    public class TransientManager : ITransientService
    {
        private string _guidId;

        public TransientManager()
        {
            _guidId = Guid.NewGuid().ToString();
        }

        public string GuidId => _guidId;
    }
}
