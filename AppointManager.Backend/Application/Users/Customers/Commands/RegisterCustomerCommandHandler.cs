using AppointManager.Backend.Domain.Entities.Users;
using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AppointManager.Backend.Application.Users.Customers.Commands
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public RegisterCustomerCommandHandler(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<string> Handle(RegisterCustomerCommand command, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = command.Email,
                Email = command.Email,
                FirstName = command.Firstname,
                LastName = command.Lastname,
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));

                throw new Exception(errors);
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            var customer = new Customer
            {
                UserId = user.Id
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
