using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OroClient.Utils;
using OroClient.Models.User;
using Newtonsoft.Json;

namespace OroClient.Pages.User
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UsersRoot usuarios { get; set; }
        [BindProperty]
        public filtros filtro { get; set; }

        public class filtros
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public async Task OnGetAsync()
        {

            var result = await ApiConsumer.getEndPoint("http://orocrm.eastus.cloudapp.azure.com/api/users");

            usuarios = JsonConvert.DeserializeObject<UsersRoot>(result);
        }

        public async Task OnPost()
        {
            var result = "";
            if (filtro.id != null || filtro.name != null)
            {
                string _FiltroID = !String.IsNullOrEmpty(filtro.id) ? "filter[id]=" + filtro.id : null;
                string _FiltroName = !String.IsNullOrEmpty(filtro.name) ? "filter[firstName]=" + filtro.name : null;
                
                string URI = "http://orocrm.eastus.cloudapp.azure.com/api/users?";
                URI += _FiltroID != null ? _FiltroID : "";
                URI += _FiltroID != null && _FiltroName != null? "&"+_FiltroName : _FiltroName;
                result = await ApiConsumer.getEndPoint(URI);
            }
            else
            {
                result = await ApiConsumer.getEndPoint("http://orocrm.eastus.cloudapp.azure.com/api/users");
            }
            usuarios = JsonConvert.DeserializeObject<UsersRoot>(result);
        }

    }
}

