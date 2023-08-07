namespace Blog_ASP.Net_Core_6.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public decimal PhoneNumber { get; set;}
        public IFormFile? File { get; set; }

        public string Gender { get; set; }
        public string? ImageUrl { get; set;}
         


    }
}
