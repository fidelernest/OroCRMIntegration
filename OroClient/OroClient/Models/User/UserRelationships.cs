using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OroClient.Models;

namespace OroClient.Models.User
{
    public class UserRelationships
    {
        public props groups { get; set; }
        public prop owner { get; set; }
        public props businessUnits { get; set; }
        public props organizations { get; set; }
        public props userRoles { get; set; }
        public prop organization { get; set; }
        public prop avatar { get; set; }
        public prop auth_status { get; set; }
        public props activityCalls { get; set; }
    }

    public class props
    {
        public object[] data { get; set; }
    }

    public class prop
    {
        public detalle data { get; set; }
    }




}

