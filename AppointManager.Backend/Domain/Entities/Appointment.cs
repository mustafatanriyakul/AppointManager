using AppointManager.Backend.Domain.Entities.Users;
using AppointManager.Backend.Domain.Enums;

namespace AppointManager.Backend.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTimeOffset Date {  get; set; }
        public string Notes { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
    }
}
