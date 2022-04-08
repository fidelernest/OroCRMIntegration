using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Models.Lead
{
    public class LeadAttributes
    {
        public object lastContactedDate { get; set; }
        public object lastContactedDateIn { get; set; }
        public object lastContactedDateOut { get; set; }
        public int timesContacted { get; set; }
        public int timesContactedIn { get; set; }
        public int timesContactedOut { get; set; }
        public string name { get; set; }
        public object namePrefix { get; set; }
        public string firstName { get; set; }
        public object middleName { get; set; }
        public string lastName { get; set; }
        public object nameSuffix { get; set; }
        public object jobTitle { get; set; }
        public string companyName { get; set; }
        public object website { get; set; }
        public object numberOfEmployees { get; set; }
        public object industry { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public object notes { get; set; }
        public string twitter { get; set; }
        public object linkedIn { get; set; }
        public string primaryPhone { get; set; }
        public string primaryEmail { get; set; }
        public Phone[] phones { get; set; }
        public Email[] emails { get; set; }
    }

    public class Phone
    {
        public string phone { get; set; }
    }

    public class Email
    {
        public string email { get; set; }
    }
}
