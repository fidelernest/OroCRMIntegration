using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OroClient.Models.User;
using OroClient.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OroClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {

            var result = await ApiConsumer.getEndPoint("http://orocrm.eastus.cloudapp.azure.com/api/users");

            var json = JsonConvert.DeserializeObject<UsersRoot>(result);

            UserRoot root = new UserRoot();
            UserAttributes attributes = new UserAttributes();
            root.data = json.data[2];

            await ApiConsumer.patchEndPoint("dsfsd", root);
        }
    }
}
