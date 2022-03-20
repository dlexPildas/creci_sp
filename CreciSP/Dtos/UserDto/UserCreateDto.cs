using CreciSP.Domain.Enum;

namespace CreciSP.Mvc.Dtos.UserDto
{
    public class UserCreateDto
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public UserTypeEnum Type { get; private set; }
        public bool Status { get; private set; }
        public string Password { get; private set; }
    }
}
