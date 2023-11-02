using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    internal class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;




        public User() { }

        public User(string login, string email, string pass)
        {
            this.Login = login;
            this.Password = pass;
            this.Email = email;
        }


    }
}
