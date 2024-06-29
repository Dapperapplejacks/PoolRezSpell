using PoolRezWebApi.Models;

namespace PoolRezWebApi
{
    public interface IUserService
    {

        void SetUser(UserInfo userInfo);

        UserInfo? GetUser();

        TokenData? GetToken();

        int? GetCustomerId();

    }
}
