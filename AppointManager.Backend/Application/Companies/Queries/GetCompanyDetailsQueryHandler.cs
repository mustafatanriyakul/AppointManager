using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppointManager.Backend.Application.Companies.Queries
{
    public class GetCompanyDetailsQueryHandler : IRequestHandler<GetCompanyDetailsQuery, CompanyDto>
    {
        private readonly ApplicationDbContext _context;

        public GetCompanyDetailsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyDto> Handle(GetCompanyDetailsQuery query, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == query.Id, cancellationToken);

            if (company == null)
            {
                throw new Exception($"Bu şirket ID: {query.Id} bulunamadı");
            }

            var companyDto = new CompanyDto(
                    company.Id,
                    company.Name,
                    company.Address,
                    company.PhoneNumber
                );

            return companyDto;
            
        }
    }
}
