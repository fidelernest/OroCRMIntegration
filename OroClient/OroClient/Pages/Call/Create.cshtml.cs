using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OroClient.Models.Calls;
using OroClient.Utils;
using OroClient.ViewModels;

namespace OroClient.Pages.Call
{
    public class CreateModel : PageModel
    {
        private readonly IApiConsumer _api;
        private readonly ILogger<CreateModel> _logger;
        public CreateModel(ILogger<CreateModel> logger, IApiConsumer api)
        {
            _logger = logger;
            _api = api;
        }

        [BindProperty]
        public CallRoot call { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var root = new CreateCallViewModel
            {
                data = new CallData
                {
                    attributes = new CallAttribute
                    {
                        subject = call.data.attributes.subject,
                        duration = TimeSpan.Parse(call.data.attributes.duration).TotalSeconds.ToString(),
                        phoneNumber = call.data.attributes.phoneNumber,
                        callDateTime = call.data.attributes.callDateTime.ToString("yyyy-MM-dd")
                    },
                    relationships = new CallRelationship
                    {
                        callStatus = new CallStatus
                        {
                            data = new Data { id = "completed", type = "callstatuses" }
                        },
                        direction = new Direction
                        {
                            data = new Data { type = "calldirections", id = "outgoing" }
                        },
                        owner = new Owner
                        {
                            data = new Data
                            {
                                type = "users",
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

            var response = await _api.Post("/api/calls", root);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Call");
            }

            var stringResponse = await response.Content.ReadAsStringAsync();
            return Page();
        }
    }
}
