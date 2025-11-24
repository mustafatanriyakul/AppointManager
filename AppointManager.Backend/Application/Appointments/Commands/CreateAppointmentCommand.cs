using MediatR;

namespace AppointManager.Backend.Application.Appointments.Commands
{
    public class CreateAppointmentCommand : IRequest<Guid>
    {
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public DateTimeOffset Date {  get; set; }
        public string Notes {  get; set; }
    }
}
