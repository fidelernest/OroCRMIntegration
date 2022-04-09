using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OroClient.Models.User;
using OroClient.Utils;
using OroClient.ViewModels;

namespace OroClient.Pages.User
{
    public class createModel : PageModel
    {

        private readonly IApiConsumer _api;
        private readonly ILogger<createModel> _logger;
        public createModel(ILogger<createModel> logger, IApiConsumer api)
        {
            _logger = logger;
            _api = api;
        }

        [BindProperty]
        public CreateUserViewModel usuario { get; set; }
        public async Task OnGetAsync()
        {

        }

        public async Task OnPost()
        {
            CreateUserViewModel root = new CreateUserViewModel
            {
                data = new UserData
                {
                    type = "users",
                    attributes = new Attributes
                    {
                        username = usuario.data.attributes.username,
                        email = usuario.data.attributes.email,
                        firstName = usuario.data.attributes.firstName,
                        lastName = usuario.data.attributes.lastName,
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

            _ = await _api.Post("/api/users", root);
        }
    }
}
