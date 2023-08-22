using Blog_ASP.Net_Core_6.Models;

namespace Blog_ASP.Net_Core_6.Services.Interface
{
    public interface ILoginRepository
    {
        string Generate(UserModel user);
        UserModel Authenticate(UserLogin userLogin);
    }
}
