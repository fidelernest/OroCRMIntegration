using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.ViewModels
{
    public class CreateLeadViewModel
    {

        public class Rootobject
        {
            public leadData data { get; set; }
        }

        public class leadData
        {
            public string type { get; set; }
            public Attributes attributes { get; set; }
            public Relationships relationships { get; set; }
        }

        public class LeadAttributes
        {
            public string name { get; set; }
        }

        public class Relationships
        {
            public Owner owner { get; set; }
            public Organization organization { get; set; }
            public Customer customer { get; set; }
            public Account account { get; set; }
            public Status status { get; set; }
        }

        public class Owner
        {
            public Data data { get; set; }
        }

        public class Data
        {
            public string type { get; set; }
            public string id { get; set; }
        }

        public class Organization
        {
            public Data data { get; set; }
        }


        public class Customer
        {
            public Data data { get; set; }
        }

        public class Account
        {
            public object data { get; set; }
        }

        public class Status
        {
            public Data data { get; set; }
        }


    }
}
