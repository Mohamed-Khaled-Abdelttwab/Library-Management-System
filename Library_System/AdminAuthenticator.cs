using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    internal class AdminAuthenticator:Authentication
    {
        public List<Admin> Admins = new List<Admin>();
        public bool CheckEmailIsExist(string email)
        {
            foreach (var user in Admins)
            {
                if (string.Equals(user.Email, email, StringComparison.Ordinal)) return true;
            }

            return false;
        }
        public void Signup(Admin admin)
        {

            Admins.Add(admin);

        }

        public Admin Login(string email, string password)
        {
            Admin admin = null;
            foreach (var _admin in Admins)
            {
                if (string.Equals(_admin.Email, email, StringComparison.Ordinal) && string.Equals(_admin.Password, password, StringComparison.Ordinal))
                {
                    admin = _admin;
                    break;
                }
            }
            return admin;
        }

        public void SerializeToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(Admins, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public void DeserializeFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (JsonConvert.DeserializeObject<List<Admin>>(json) != null)
                {
                    Admins = JsonConvert.DeserializeObject<List<Admin>>(json);
                }
            }
        }
    }
}
