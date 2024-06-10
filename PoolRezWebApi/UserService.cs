using PoolRezWebApi.Models;

namespace PoolRezWebApi
{
    public class UserService : IUserService
    {
        private TokenData? _token;
        private int? _customerId;

        public int? GetCustomerId()
        {
            return _customerId;
        }

        public TokenData? GetToken()
        {
            return _token;
        }

        public void SetCustomerId(int customerId)
        {
            if (customerId != _customerId)
            {
                _customerId = customerId;
            }
        }

        public void SetToken(TokenData token)
        {
            if (token != _token)
            {
                _token = token;
            }
        }
    }
}
