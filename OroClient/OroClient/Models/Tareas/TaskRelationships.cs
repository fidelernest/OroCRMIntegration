namespace OroClient.Models.Tareas
{
    public class TaskRelationships
    {
        public prop taskPriority { get; set; }
        public prop owner { get; set; }
        public prop createdBy { get; set; }
        public prop organization { get; set; }
        public prop status { get; set; }
        public props activityTargets { get; set; }
        public Comments comments { get; set; }
    }

    public class Comments
    {
        public object[] data { get; set; }
    }


}
