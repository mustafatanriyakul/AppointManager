using AppointManager.Backend.Domain.Entities.Users;

namespace AppointManager.Backend.Infrastructure.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, IList<string> roles);
    }
}
