using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Models.User
{
    public class UserAttributes
    {
        public object phone { get; set; }
        public object title { get; set; }
        public object googleId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public object namePrefix { get; set; }
        public string firstName { get; set; }
        public object middleName { get; set; }
        public string lastName { get; set; }
        public object nameSuffix { get; set; }
        public object birthday { get; set; }
        public bool enabled { get; set; }
        public string lastLogin { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public int loginCount { get; set; }
        public object passwordRequestedAt { get; set; }
        public object passwordChangedAt { get; set; }
        public object[] emails { get; set; }
    }
}
