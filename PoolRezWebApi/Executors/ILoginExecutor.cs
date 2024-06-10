using PoolRezWebApi.Models;

namespace PoolRezWebApi.Executors
{
    public interface ILoginExecutor
    {
        Task<TokenData?> Login(LoginInformation loginInformation, CancellationToken cancellationToken);
    }
}