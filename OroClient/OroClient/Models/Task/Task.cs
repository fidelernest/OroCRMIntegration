using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Models.Task
{
    public class TasksRoot
    {
        public Task[] data { get; set; }
    }

    public class Task
    {
        public string type { get; set; }
        public string id { get; set; }
        public taskAttributes attributes { get; set; }
        public TaskRelationships relationships { get; set; }
    }
}
