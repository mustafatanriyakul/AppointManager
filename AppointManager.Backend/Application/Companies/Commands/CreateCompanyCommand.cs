using MediatR;

namespace AppointManager.Backend.Application.Companies.Commands
{
    public record CreateCompanyCommand (
            string Name,
            string Address,
            string PhoneNumber
        ) : IRequest<Guid>;

}
