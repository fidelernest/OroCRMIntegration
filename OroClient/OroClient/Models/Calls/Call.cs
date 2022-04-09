namespace OroClient.Models.Calls
{
    public class CallRoot
    {
        public Call data { get; set; }
    }

    public class CallsRoot
    {
        public Call[] data { get; set; }
    }
    public class Call
    {
        public string type => "calls";
        public string id { get; set; }
        public CallAttributes attributes { get; set; }
        public CallRelationships relationships { get; set; }
    }
}
