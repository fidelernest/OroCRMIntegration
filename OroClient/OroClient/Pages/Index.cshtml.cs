using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OroClient.Models.User;
using OroClient.Utils;
using OroClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiConsumer _api;

        public IndexModel(ILogger<IndexModel> logger, IApiConsumer api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync()
        {

            //var result = await _api.Get("/api/users");

            //var json = JsonConvert.DeserializeObject<UsersRoot>(result.Content.ReadAsStringAsync());

            CreateUserViewModel root = new CreateUserViewModel
            {
                data = new UserData
                {
                    type = "users",
                    attributes = new Attributes
                    {
                        username = "felipe123",
                        email = "ronoen@nnomo.com",
                        firstName = "Ronel",
                        lastName = "Pantaleon",
                        password = "Password1."
                    },
                    relationships = new Relationships
                    {
                        owner = new Owner
                        {
                            data = new Data
                            {
                                type = "businessunits",
                                id = "1"
                            }
                        },

                        organization = new Organization
                        {
                            data = new Data
                            {
                                type = "organizations",
                                id = "1"
                            }
                        }
                    }
                }
            };

            await _api.Post("/api/users", root);
        }
    }
}
