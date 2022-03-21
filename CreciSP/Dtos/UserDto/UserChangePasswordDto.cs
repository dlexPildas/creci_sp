using CreciSP.Domain.Enum;
using System;

namespace CreciSP.Mvc.Dtos.UserDto
{
    public class UserChangePasswordDto
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
