using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TrueNorth.Core.EF.Repositories;
using TrueNorth.Core.Hipsum;
using TrueNorth.Core.Tasks;

namespace TrueNorth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private ITaskItemRepository _repository;
        private HttpClient _client;
        private IHipsum _hipsum;

        public TaskController(ILogger<TaskController> logger, ITaskItemRepository repository, IHttpClientFactory factory, IHipsum hipsum)
        {
            _repository = repository;
            _logger = logger;
            _client = factory.CreateClient("hipsum");
            _hipsum = hipsum;
        }

        [HttpGet]
        public IEnumerable<TaskItem> Get()
        {
            var a = _repository.List(); 
            return a.Result;
        }

        [HttpPut]
        public ActionResult<bool> Put(string taskId)
        {
            _logger.LogInformation($"You close this task" + taskId);
            return true;
        } 

        [HttpPost]
        public ActionResult<bool> CreateBulk(int count)
        {
            if (count == 0)
                count = 3;

            var a = _hipsum.GetMany(_client, count);

            foreach (var item in a)
            {
                _repository.Create(item);
            }
            return true;
        }
    }
}
