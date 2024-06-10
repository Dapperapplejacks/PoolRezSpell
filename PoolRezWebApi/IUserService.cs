using PoolRezWebApi.Models;

namespace PoolRezWebApi
{
    public interface IUserService
    {
        TokenData? GetToken();

        void SetToken(TokenData token);

        int? GetCustomerId();

        void SetCustomerId(int customerId);

    }
}
