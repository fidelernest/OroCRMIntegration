using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Models.Lead
{
    public class LeadsRoot
    {
        public Lead[] data { get; set; }
    }
    public class LeadRoot
    {
        public Lead data { get; set; }
    }

    public class Lead
    {
        public string type { get; set; }
        public string id { get; set; }
        public LeadAttributes attributes { get; set; }
        public LeadRelationships relationships { get; set; }
    }
}
