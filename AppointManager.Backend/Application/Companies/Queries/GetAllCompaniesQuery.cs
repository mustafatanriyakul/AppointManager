using MediatR;

namespace AppointManager.Backend.Application.Companies.Queries
{
    public record GetAllCompaniesQuery : IRequest<List<CompanyDto>>
    {
    }
}
