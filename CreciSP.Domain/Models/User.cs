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

        public Guid Id { get;  private set; }
        public string Name { get;  private set; }
        public string Cpf { get;  private set; }
        public string Email { get;  private set; }
        public UserTypeEnum Type { get;  private set; }
        public bool Status { get;  private set; }
        public string Password { get;  private set; }
        public virtual ICollection<Booking> Bookings { get;  private set; }
        public virtual ICollection<LogNotify> LogNotifies { get;  private set; }

        public User() {}

        public User(Guid id, string name, string cpf, string email, UserTypeEnum type, bool status, string password)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
            Type = type;
            Status = status;
            Password = password;
        }

        public void ChangePassword(string newPassord)
        {
            Password = newPassord;
        }

        public void UpdateUser(User user)
        {            
            Name = user.Name;
            Email = user.Email;
        }

        public void ActiveUser()
        {
            Status = true;
        }

        public void InactiveUser()
        {
            Status = false;
        }
    }
}
