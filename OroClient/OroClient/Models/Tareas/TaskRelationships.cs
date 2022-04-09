namespace OroClient.Models.Tareas
{
    public class TaskRelationships
    {
        public Prop taskPriority { get; set; }
        public Prop owner { get; set; }
        public Prop createdBy { get; set; }
        public Prop organization { get; set; }
        public Prop status { get; set; }
        public Props activityTargets { get; set; }
        public Comments comments { get; set; }
    }

    public class Comments
    {
        public object[] data { get; set; }
    }


}
