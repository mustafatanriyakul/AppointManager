namespace AppointManager.Backend.Domain.Entities.Users
{
    public class Customer
    {
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
