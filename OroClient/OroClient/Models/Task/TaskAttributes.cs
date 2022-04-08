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
        public DateTime dueDate { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
