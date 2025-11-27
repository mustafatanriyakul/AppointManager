using MediatR;

namespace AppointManager.Backend.Application.Companies.Queries
{
    public record GetCompanyDetailsQuery(Guid Id) : IRequest<CompanyDto>;
}
