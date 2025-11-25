using MediatR;

namespace AppointManager.Backend.Application.Users.CompanyAdmins.Commands
{
    public record CreateCompanyAdminCommand(
            string Email,    
            string Password,    
            string FirstName,    
            string LastName,
            Guid CompanyId
        ) : IRequest<string>;
}
