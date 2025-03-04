namespace OnionSample.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public string Roles { get; set; }

        // Optional fields
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
    }
}
