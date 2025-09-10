using eCommerce.Core.DTO;

namespace eCommerce.Core.Entities
{
    public class ApplicationUser
    {
        public Guid userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Gender { get; set; }
    }
}
