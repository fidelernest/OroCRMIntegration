using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OroClient.Models.Tareas;
using OroClient.Utils;

namespace OroClient.Pages.Tareas
{
    public class DetailsModel : PageModel
    {
        private readonly IApiConsumer _api;
        private readonly ILogger<DetailsModel> _logger;
        public DetailsModel(ILogger<DetailsModel> logger, IApiConsumer api)
        {
            _logger = logger;
            _api = api;
        }

        [BindProperty]
        public TaskRoot tarea { get; set; }
        private TaskRoot _tarea;

        [FromQuery(Name = "id")]
        public string Id { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _api.Get($"/api/tasks/{Id}");

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                tarea = JsonConvert.DeserializeObject<TaskRoot>(response);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _api.Get($"/api/tasks/{Id}");

            var stringResponse = await result.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<TaskRoot>(stringResponse);

            model.data.attributes = tarea.data.attributes;
            model.data.relationships.taskPriority.data.id = tarea.data.relationships.taskPriority.data.id;

            var response = await _api.Patch($"/api/tasks/{Id}", model);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Tareas");
            }

            var errorResponse = await response.Content.ReadAsStringAsync();
            return Page();
        }
    }
}
