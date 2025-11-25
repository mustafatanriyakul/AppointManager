namespace AppointManager.Backend.Application.Appointments.Queries
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Notes { get; set; }
    }
}
