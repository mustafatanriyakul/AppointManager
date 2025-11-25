using AppointManager.Backend.Domain.Entities;
using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;

namespace AppointManager.Backend.Application.Companies
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateCompanyCommandHandler(ApplicationDbContext context)
        { 
            _context = context;
        }


        public async Task<Guid> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {

            var company = new Company
            {
                Id = new Guid(),
                Name = command.Name,
                Address = command.Address,
                PhoneNumber = command.PhoneNumber,
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync(cancellationToken);

            return company.Id;

        }
    }
}
