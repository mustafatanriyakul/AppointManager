namespace AppointManager.Backend.Application.Appointments.Queries
{
    public record AppointmentDto
    (
        Guid Id,
        DateTimeOffset Date,
        string Notes,
        string CustomerFullName,
        string CompanyName,
        string Status
    );
}
