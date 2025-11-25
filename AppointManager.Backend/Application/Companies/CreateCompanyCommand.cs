using MediatR;

namespace AppointManager.Backend.Application.Companies
{
    public record CreateCompanyCommand (
            string Name,
            string Address,
            string PhoneNumber
        ) : IRequest<Guid>;

}
