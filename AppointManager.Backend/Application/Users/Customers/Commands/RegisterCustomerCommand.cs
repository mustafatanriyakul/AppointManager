using MediatR;

namespace AppointManager.Backend.Application.Users.Customers.Commands
{
    public record RegisterCustomerCommand(
            string Email,
            string Password,
            string Firstname,
            string Lastname
        ) : IRequest<string>;
}
