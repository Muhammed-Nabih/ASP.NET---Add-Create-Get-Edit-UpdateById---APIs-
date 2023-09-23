namespace Sallaty.API.Models.DTO
{
    public class RegisterRequestDto
    {
        public string Fname { get; set; }

        public string Lname { get; set; }

        public string UserName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
