using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Models.Lead
{
    public class LeadRelationships
    {
        public Contact contact { get; set; }
        public Addresses addresses { get; set; }
        public Owner owner { get; set; }
        public Opportunities opportunities { get; set; }
        public Organization organization { get; set; }
        public Campaign campaign { get; set; }
        public Source source { get; set; }
        public Status status { get; set; }
        public Activitynotes activityNotes { get; set; }
        public Activitycalls activityCalls { get; set; }
        public Activitytasks activityTasks { get; set; }
        public Account account { get; set; }
        public Customer customer { get; set; }
    }

    public class Contact
    {
        public object data { get; set; }
    }

    public class Addresses
    {
        public Data[] data { get; set; }
    }

    public class Owner
    {
        public Data data { get; set; }
    }


    public class Opportunities
    {
        public object[] data { get; set; }
    }

    public class Organization
    {
        public Data data { get; set; }
    }


    public class Campaign
    {
        public object data { get; set; }
    }

    public class Source
    {
        public Data data { get; set; }
    }

    public class Status
    {
        public Data data { get; set; }
    }


    public class Activitynotes
    {
        public object[] data { get; set; }
    }

    public class Activitycalls
    {
        public object[] data { get; set; }
    }

    public class Activitytasks
    {
        public object[] data { get; set; }
    }

    public class Account
    {
        public object data { get; set; }
    }

    public class Customer
    {
        public object data { get; set; }
    }

}
