using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OroClient.Models.Tareas;
using OroClient.Utils;
using System.Threading.Tasks;

namespace OroClient.Pages.Tareas
{
    public class IndexModel : PageModel
    {
        private readonly IApiConsumer _api;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public TasksRoot Tareas { get; set; }
        [BindProperty]
        public object filtro { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IApiConsumer api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync()
        {
            var result = await _api.Get("/api/tasks?sort=dueDate&page[number]=1&page[size]=1000");

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                Tareas = JsonConvert.DeserializeObject<TasksRoot>(response);
            }
        }
    }
}
