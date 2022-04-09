using System;
using System.Collections.Generic;

namespace OroClient.ViewModels
{
    public class TaskAttributes
    {
        public string subject { get; set; }
        public string description { get; set; }
        public string dueDate { get; set; }
    }

    public class TaskData
    {
        public string type { get; set; }
        public TaskAttributes attributes { get; set; }
        public TaskRelationship relationships { get; set; }
    }

    public class TaskPriority
    {
        public Data data { get; set; }
    }

    public class Status
    {
        public Data data { get; set; }
    }

    public class ActivityTargets
    {
        public List<Data> data { get; set; }
    }

    public class TaskRelationship
    {
        public TaskPriority taskPriority { get; set; }
        public Status status { get; set; }
        public ActivityTargets activityTargets { get; set; }
    }

    public class CreateTaskViewModel
    {
        public TaskData data { get; set; }
    }
}
