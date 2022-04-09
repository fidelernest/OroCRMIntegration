namespace OroClient.Models.Tareas
{
    public class TasksRoot
    {
        public Tarea[] data { get; set; }
    }
    public class TaskRoot
    {
        public Tarea data { get; set; }
    }

    public class Tarea
    {
        public string type => "tasks";
        public string id { get; set; }
        public taskAttributes attributes { get; set; }
        public TaskRelationships relationships { get; set; }
    }
}
