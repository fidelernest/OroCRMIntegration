using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OroClient.Models.User;
using OroClient.Utils;

namespace OroClient.Pages.User
{
    public class detailsModel : PageModel
    {
        private readonly IApiConsumer _api;
        private readonly ILogger<detailsModel> _logger;

        [BindProperty]
        public UsersRoot usuarios { get; set; }


        public detailsModel(ILogger<detailsModel> logger, IApiConsumer api)
        {
            _logger = logger;
            _api = api;
        }
        
        public OroClient.Models.User.User usuario { get; set; }
        public async Task OnGetAsync(string id)
        {
            var result = await _api.Get("/api/users?filter[id]=" + id);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                usuarios = JsonConvert.DeserializeObject<UsersRoot>(response);
            }
        }

        public async Task OnPost(string id)
        {
            UsersRoot _usuarios = new UsersRoot();
            var result = await _api.Get("/api/users?filter[id]=" + id);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                _usuarios = JsonConvert.DeserializeObject<UsersRoot>(response);
            }
            _usuarios.data[0].attributes.firstName = usuarios.data[0].attributes.firstName;
            _usuarios.data[0].attributes.username = usuarios.data[0].attributes.username;
            _usuarios.data[0].attributes.lastName = usuarios.data[0].attributes.lastName;
            _usuarios.data[0].attributes.email = usuarios.data[0].attributes.email;
            UserRoot UR = new UserRoot();
            UR.data = _usuarios.data[0];
            _ = await _api.Patch("/api/users/" + id, UR);
        }
    }
}
