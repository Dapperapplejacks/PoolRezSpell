using PoolRezWebApi.Models;

namespace PoolRezWebApi
{
    public interface ILoginExecutor
    {
        Task<TokenData?> Login(LoginInformation loginInformation, CancellationToken cancellationToken);
    }
}