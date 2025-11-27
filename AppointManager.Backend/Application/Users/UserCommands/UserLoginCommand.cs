using MediatR;

namespace AppointManager.Backend.Application.Users.UserCommands
{
    public record UserLoginCommand(
            string Email,
            string Password,
            string RequestedRole
        ) : IRequest<string>;
}
