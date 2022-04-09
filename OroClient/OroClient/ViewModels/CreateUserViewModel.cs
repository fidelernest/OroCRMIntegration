using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.ViewModels
{
    public class Data
    {
        public string type { get; set; }
        public string id { get; set; }
    }
    public class Attributes
    {
        public string username { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
    }

    public class UserData
    {
        public string type { get; set; }

        public Attributes attributes { get; set; }
        public Relationships relationships { get; set; }
    }

    public class Owner
    {
        public Data data { get; set; }
    }

    public class Organization
    {
        public Data data { get; set; }
    }

    public class Relationships
    {
        public Owner owner { get; set; }
        public Organization organization { get; set; }
    }

    public class CreateUserViewModel
    {
        public UserData data { get; set; }
    }

}
