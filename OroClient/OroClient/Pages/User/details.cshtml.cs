using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OroClient.Models.User;
using OroClient.Utils;

namespace OroClient.Pages.User
{
    public class detailsModel : PageModel
    {
        
        

        [BindProperty]
        public OroClient.Models.User.User usuario { get; set; }
        public async Task OnGetAsync(string id)
        {
            var result = await ApiConsumer.getEndPoint("http://orocrm.eastus.cloudapp.azure.com/api/users?filter[id]="+ id);
            usuario = JsonConvert.DeserializeObject<UsersRoot>(result).data[0];
        }

        public async Task OnPost(string id)
        {
            var result = await ApiConsumer.getEndPoint("http://orocrm.eastus.cloudapp.azure.com/api/users?filter[id]=" + id);
            usuario = JsonConvert.DeserializeObject<UsersRoot>(result).data[0];
        }
    }
}
