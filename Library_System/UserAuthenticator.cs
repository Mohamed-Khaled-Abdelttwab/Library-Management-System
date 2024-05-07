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
        public static List<LibraryUser> users = new List<LibraryUser>();
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

        public LibraryUser Login(string email, string password)
        {
            LibraryUser libraryUser = null;
            foreach(var user in users)
            {
                if(string.Equals(user.Email , email, StringComparison.Ordinal) && string.Equals(user.Password, password, StringComparison.Ordinal))
                {
                    libraryUser = user;
                    break;
                }
            }
            return libraryUser;
        }

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
