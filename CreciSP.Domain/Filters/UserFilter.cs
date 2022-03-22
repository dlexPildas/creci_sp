using CreciSP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Filters
{
    public class UserFilter
    {
        public UserFilter()
        {

        }
        public string Name { get; set; }
        public string Cpf { get;  set; }
        public string Email { get; set; }
        public UserType? Type { get; set; }
        public bool? Status { get; set; }
    }
}
