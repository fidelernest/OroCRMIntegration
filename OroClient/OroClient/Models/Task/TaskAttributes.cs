using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Models.Task
{
    public class taskAttributes
    {
        public string subject { get; set; }
        public string description { get; set; }
        public string dueDate { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}
