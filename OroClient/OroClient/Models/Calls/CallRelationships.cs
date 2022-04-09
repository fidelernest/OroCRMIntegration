namespace OroClient.Models.Calls
{
    public class CallRelationships
    {
        public Prop owner { get; set; }
        public Prop callStatus { get; set; }
        public Prop direction { get; set; }
        public Prop organization { get; set; }
        public Props activityTargets { get; set; }
        public Props comments { get; set; }
    }
}
