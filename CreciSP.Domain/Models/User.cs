using CreciSP.Domain.Enum;
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

        public Guid Id { get;  private set; }
        public string Name { get;  private set; }
        public string Cpf { get;  private set; }
        public string Email { get;  private set; }
        public UserTypeEnum Type { get;  private set; }
        public bool Status { get;  private set; }
        public string Password { get;  private set; }
        public virtual ICollection<Booking> Bookings { get;  private set; }
    }
}
