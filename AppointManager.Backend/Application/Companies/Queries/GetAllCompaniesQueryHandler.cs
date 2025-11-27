using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppointManager.Backend.Application.Companies.Queries
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyDto>>
    {

        private readonly ApplicationDbContext _context;

        public GetAllCompaniesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyDto>> Handle(GetAllCompaniesQuery query, CancellationToken cancellationToken)
        {
            var companies = await _context.Companies.ToListAsync(cancellationToken);

            var companyDtoList = companies.Select(company => new CompanyDto(
                    company.Id,
                    company.Name,
                    company.Address,
                    company.PhoneNumber
                )).ToList();

            return companyDtoList;
        }
    }
}
