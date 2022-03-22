using CreciSP.Domain.Enum;

namespace CreciSP.Mvc.Dtos.UserDto
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
    }
}
