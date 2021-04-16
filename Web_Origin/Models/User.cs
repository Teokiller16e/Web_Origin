using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Origin.Models
{
    class User
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Boolean Administrator { get; set; }

        // Default
        public User() { }

        // Parameters based off:
        public User(int ID, string Firstname, string Lastname, string Username, string Password, Boolean Administrator)
        {
            this.ID = ID;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Username = Username;
            this.Password = Password;
            this.Administrator = Administrator;
        }



    }
}
