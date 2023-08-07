using Blog_ASP.Net_Core_6.Models;

namespace Blog_ASP.Net_Core_6.Services.Interface
{
    public interface IUserRepository
    {
        void CreateNewUser(UserModel objNewUser);
        string UpdateUser(UserModel objNewUser);
        UserModel GetProfile(string email);
    }
}
