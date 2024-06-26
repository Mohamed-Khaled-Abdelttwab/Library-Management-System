﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library_System
{
    public class Authentication
    {
        private string Name;
        private string Password;
        private string Email;
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

    }
}
