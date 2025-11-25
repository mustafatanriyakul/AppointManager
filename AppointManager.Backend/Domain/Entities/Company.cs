using System.Collections.ObjectModel;
using AppointManager.Backend.Domain.Entities.Users;

namespace AppointManager.Backend.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public CompanyAdmin CompanyAdmin { get; set; }
    
    }
}
