using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OroClient.Models.Lead;
using OroClient.Utils;

namespace OroClient.Pages.Lead
{
    public class detailsModel : PageModel
    {
        private readonly IApiConsumer _api;
        private readonly ILogger<detailsModel> _logger;

        [BindProperty]
        public LeadsRoot leads { get; set; }


        public detailsModel(ILogger<detailsModel> logger, IApiConsumer api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync(string id)
        {
            var result = await _api.Get("/api/leads?filter[id]=" + id);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                leads = JsonConvert.DeserializeObject<LeadsRoot>(response);
            }
        }

        public async Task OnPost(string id)
        {
            LeadsRoot _leads = new LeadsRoot();
            var result = await _api.Get("/api/leads?filter[id]=" + id);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                _leads = JsonConvert.DeserializeObject<LeadsRoot>(response);
            }
            _leads.data[0].attributes.firstName = leads.data[0].attributes.firstName;
            _leads.data[0].attributes.name = leads.data[0].attributes.name;
            _leads.data[0].attributes.lastName = leads.data[0].attributes.lastName;
            _leads.data[0].attributes.primaryEmail = leads.data[0].attributes.primaryEmail;

            LeadRoot LRoot = new LeadRoot();
            LRoot.data = _leads.data[0];
            _ = await _api.Patch("/api/leads/" + id, LRoot);
        }
    }
}
