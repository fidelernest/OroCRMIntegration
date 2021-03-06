using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OroClient.Utils;
using OroClient.Models.User;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace OroClient.Pages.User
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
        public UsersRoot usuarios { get; set; }
       
        
        public async Task OnGetAsync()
        {
            var result = await _api.Get("/api/users?page[size]=1000");

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                usuarios = JsonConvert.DeserializeObject<UsersRoot>(response);
            }
        }

    }
}

