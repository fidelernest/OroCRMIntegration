    using OroClient.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Models.User
{
    public class UsersRoot
    {
        public User[] data { get; set; }
    }

    public class UserRoot
    {
        public dynamic data { get; set; }
    }

    public class User
    {
        public string type => "users";
        public string id { get; set; }
        public UserAttributes attributes { get; set; }
        public UserRelationships relationships { get; set; }
    }

    public class UserCreate
    {
        public string type => "users";
        //public string id { get; set; }
        public UserAttributes attributes { get; set; }
        public UserRelationships relationships { get; set; }
    }
}
