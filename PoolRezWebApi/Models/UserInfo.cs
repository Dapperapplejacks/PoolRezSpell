namespace PoolRezWebApi.Models
{
    public class UserInfo
    {
        public int CustomerId {  get; set; }

        public int HomeClub {  get; set; }
        
        public int CustomerPermissions { get; set; }

        public TokenData? Token { get; set; }

    }
}
