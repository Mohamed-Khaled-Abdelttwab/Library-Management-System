using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_System
{
    public class UserAuthenticator : Authentication
    {
        public List<LibraryUser> users = new List<LibraryUser>();
        public UserAuthenticator(string name , string password, string email)
        {
            this.Name = name;
            this.Password = password;
            this.Email = email;

        }
        public UserAuthenticator()
        {
           
        }
        public bool CheckEmailIsExist(string email)
        {
             foreach (var user in users)
                  {
                     if (string.Equals(user.Email,email, StringComparison.Ordinal))return true;
                  }
                
                return false;          
        }
        public void Signup(LibraryUser user)
        {
            
            users.Add (user);     
           
        }

        //public LibraryUser Login(string username, string password)
        //{
        //    if (!users.ContainsKey(username))
        //    {
        //        throw new ArgumentException("Invalid username.");
        //    }
        //    LibraryUser user = users[username];
        //    if (user.Password != password)
        //    {
        //        throw new ArgumentException("Invalid password.");
        //    }
        //    return user;
        //}

        public void SerializeToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        public void DeserializeFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if(JsonConvert.DeserializeObject <List<LibraryUser>>(json) != null)
                {
                    users = JsonConvert.DeserializeObject<List<LibraryUser>>(json);
                }
            }
        }
    }
}
