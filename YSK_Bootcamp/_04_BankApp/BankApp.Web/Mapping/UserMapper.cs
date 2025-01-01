using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public class UserMapper : IUserMapper
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel
            {
                Name = x.Name,
                Id = x.Id,
                Surname = x.Surname
            }).ToList();
        }

        public UserListModel MapToUserList (ApplicationUser user)
        {
            UserListModel userResponse = new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };

            return userResponse; 
        }
    }
}
