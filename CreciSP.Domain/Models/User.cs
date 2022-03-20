using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Models
{
    public class User
    {
        public User()
        {

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public UserTypeEnum Type { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
    }
}
