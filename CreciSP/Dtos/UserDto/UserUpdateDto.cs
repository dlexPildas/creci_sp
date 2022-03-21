using CreciSP.Domain.Enum;
using System;

namespace CreciSP.Mvc.Dtos.UserDto
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
