using System;

namespace OroClient.Models.Calls
{
    public class CallAttributes
    {
        public string subject { get; set; }
        public string phoneNumber { get; set; }
        public object notes { get; set; }
        public DateTime callDateTime { get; set; }
        public string duration { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
