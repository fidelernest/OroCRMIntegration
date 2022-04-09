using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OroClient.Models.Tareas;
using OroClient.Utils;
using OroClient.ViewModels;

namespace OroClient.Pages.Tareas
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
        public TaskRoot tarea { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var root = new CreateTaskViewModel
            {
                data = new TaskData
                {
                    type = "tasks",
                    attributes = new TaskAttributes 
                    { 
                        subject = tarea.data.attributes.subject,
                        description = tarea.data.attributes.description,
                        dueDate = tarea.data.attributes.dueDate
                    },
                    relationships = new TaskRelationship
                    {
                        taskPriority = new TaskPriority
                        {
                            data = new Data
                            {
                                type = "taskpriorities",
                                id = tarea.data.relationships.taskPriority.data.id
                            }
                        },
                        activityTargets = new ActivityTargets
                        {
                            data = new List<Data>
                            {
                                new Data { type = "contacts", id = "61" },
                                new Data { type = "accounts", id = "45" }
                            }
                        },
                        status = new Status
                        {
                            data = new Data
                            {
                                type = "taskstatuses",
                                id = "open"
                            }
                        }
                    }
                }
            };

            var response = await _api.Post("/api/tasks", root);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Tareas");
            }

            var stringResponse = await response.Content.ReadAsStringAsync();
            return Page();
        }
    }
}
