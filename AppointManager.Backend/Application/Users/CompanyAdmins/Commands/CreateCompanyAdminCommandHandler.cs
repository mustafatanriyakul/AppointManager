using AppointManager.Backend.Domain.Entities.Users;
using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AppointManager.Backend.Application.Users.CompanyAdmins.Commands
{
    public class CreateCompanyAdminCommandHandler : IRequestHandler<CreateCompanyAdminCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public CreateCompanyAdminCommandHandler(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<string> Handle(CreateCompanyAdminCommand command, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = command.Email,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));

                throw new Exception(errors);
            }

            await _userManager.AddToRoleAsync(user, "CompanyAdmin");

            var companyAdmin = new CompanyAdmin
            {
                UserId = user.Id,
                CompanyId = command.CompanyId,
            };

            

            _context.CompanyAdmins.Add(companyAdmin);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;

        }
    }
}
