using PoolRezWebApi.Models;

namespace PoolRezWebApi
{
    public class UserService : IUserService
    {
        private UserInfo? _userInfo;
        private int? _customerId;

        public UserInfo? GetUser()
        {
            return _userInfo;
        }

        public int? GetCustomerId()
        {
            return _customerId;
        }

        public TokenData? GetToken()
        {
            return _userInfo?.Token;
        }

        public void SetUser(UserInfo userInfo)
        {
            if (_userInfo != userInfo)
            {
                _userInfo = userInfo;
            }
        }

        public UserInfo? GetUserInfo()
        {
            return _userInfo;
        }
    }
}
