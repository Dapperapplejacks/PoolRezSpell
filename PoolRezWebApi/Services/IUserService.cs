using PoolRezWebApi.Models;

namespace PoolRezWebApi.Services
{
    public interface IUserService
    {

        void SetUser(UserInfo userInfo);

        UserInfo? GetUser();

        TokenData? GetToken();

        int? GetCustomerId();

    }
}
