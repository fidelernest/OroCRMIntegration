using System;

namespace OroClient.ViewModels
{
    public class CallAttribute
    {
        public string subject { get; set; }
        public string phoneNumber { get; set; }
        public string callDateTime { get; set; }
        public string duration { get; set; }
    }

    public class CallStatus
    {
        public Data data { get; set; }
    }

    public class Direction
    {
        public Data data { get; set; }
    }

    public class CallRelationship
    {
        public Owner owner { get; set; }
        public CallStatus callStatus { get; set; }
        public Direction direction { get; set; }
        public Organization organization { get; set; }
    }

    public class CallData
    {
        public string type => "calls";
        public CallAttribute attributes { get; set; }
        public CallRelationship relationships { get; set; }
    }

    public class CreateCallViewModel
    {
        public CallData data { get; set; }
    }

}
