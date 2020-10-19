using System;
namespace WebAddressbookTests
{
    public class AccountData
    {
        private string username;
        private string password;

        public AccountData(string username, string passwors)
        {
            this.username = username;
            this.password = passwors;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
