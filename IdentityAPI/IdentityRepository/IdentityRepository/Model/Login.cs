

namespace IdentityRepository.Model
{
    public class Login
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string Token { get; set; }
    }
}
