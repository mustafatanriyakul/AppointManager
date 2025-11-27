using MediatR;

namespace AppointManager.Backend.Application.Companies.Queries
{
    public record CompanyDto
    (
        Guid Id,
        string Name,
        string Address,
        string PhoneNumber
    );
}
