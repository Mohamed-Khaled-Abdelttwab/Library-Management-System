using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library_System
{
  
    public abstract class User
    {
        
        public string Name;
        public string Email;
        public string Password;

    }
}
