

using IdentityRepository.Model;

namespace IdentityRepository.Interfaces
{
    public interface ILoginService
    {
        Login AuthenticateUser(Login login);
    }
}
