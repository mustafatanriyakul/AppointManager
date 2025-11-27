namespace AppointManager.Backend.Domain.Entities.Users
{
    public class CompanyAdmin
    {
        public string UserId { get; set; }
        public Guid CompanyId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Company Company {  get; set; }
    }
}
