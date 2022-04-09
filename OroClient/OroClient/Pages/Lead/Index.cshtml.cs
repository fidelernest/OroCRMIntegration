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
    public class IndexModel : PageModel
    {
        private readonly IApiConsumer _api;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IApiConsumer api)
        {
            _logger = logger;
            _api = api;
        }

        [BindProperty]
        public LeadsRoot leads { get; set; }
        public async Task OnGetAsync()
        {
            var result = await _api.Get("/api/leads?page[size]=1000");

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                leads = JsonConvert.DeserializeObject<LeadsRoot>(response);
            }
        }
    }
}
