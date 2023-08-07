using Blog_ASP.Net_Core_6.Models;
using Blog_ASP.Net_Core_6.Services.Interface;

namespace Blog_ASP.Net_Core_6.Services.Repository
{
    public class UserRepository : IUserRepository
    {

        public void CreateNewUser(UserModel objNewUser) => UserConstants.Users.Add(objNewUser);

        public string UpdateUser(UserModel objNewUser)
        {
           
                var query = (from h in UserConstants.Users
                             where h.EmailAddress.Equals(objNewUser.EmailAddress)
                             select h).First();

                if (query != null)
                {
                query = objNewUser;

                return "Updated User Suceessfully";
                }

            return string.Empty;

        }
        public UserModel GetProfile(string email)
        {
            return UserConstants.Users.Where(x => x.EmailAddress == email).FirstOrDefault();
        }
    }
}
