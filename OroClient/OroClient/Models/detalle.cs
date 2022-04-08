using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Models
{
    public class detalle
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class prop
    {
        public object data { get; set; }
    }

    public class props
    {
        public detalle[] data { get; set; }
    }
}
