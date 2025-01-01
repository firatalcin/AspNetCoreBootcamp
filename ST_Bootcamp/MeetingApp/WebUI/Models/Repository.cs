namespace WebUI.Models
{
    public static class Repository
    {
        private static List<UserInfo> _users = new();
        
        public static List<UserInfo> Users()
        {
            return _users;
        }

        public static void CreateUser(UserInfo user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
        }

        public static UserInfo GetUserDetail(int id)
        {
            var model = _users.Where(x => x.Id == id).FirstOrDefault();
            return model;
        }
    }
}
