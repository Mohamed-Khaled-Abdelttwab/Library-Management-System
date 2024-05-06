using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library_System
{
    public class Authentication
    {
        protected string Name;
        protected string Password;
        protected string Email;

        public Authentication(string name, string email , string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
        public Authentication()
        {
            
        }

        public bool CheckEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        public bool SetEmail(string email)
        {
            if (CheckEmail(email))
            {
                Email = email;
                return true;
            }
            return false;
        }
        public void UpdateName(string newName)
        {
            Name = newName;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Name Updated Successfuly !!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Password Updated Successfuly !!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void UpdateEmail(string newEmail)
        {
            if (SetEmail(newEmail))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Email Updated Successfuly !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Email Formatt !!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
