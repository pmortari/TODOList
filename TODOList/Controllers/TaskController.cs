using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TODOList.Services.Interfaces;

namespace TODOList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        /// <summary>
        /// Allows the user to request the entire list of tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            _logger.LogInformation("Request received - TaskController.Get().");

            var value = _taskService.GetList();
            _logger.LogInformation($"Request complete with {value.Count} values - TaskController.Get().");
            return Ok(value);
        }

        /// <summary>
        /// Allow the user to request a specific task and its details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation($"Request received - TaskController.GetById() using Id {id}.");

            var value = _taskService.GetById(id);

            _logger.LogInformation($"Request complete - TaskController.GetById() using Id {id}.");
            _logger.LogInformation($"Task with Id {id}: {JsonSerializer.Serialize(value)}");

            return Ok(value);
        }

        /// <summary>
        /// Creates a new task
        /// </summary>
        /// <param name="taskToBeCreated"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(DTO.Task taskToBeCreated)
        {
            _logger.LogInformation($"Request received - TaskController.Create() with Name {taskToBeCreated.Name}.");

            _taskService.Create(taskToBeCreated);

            _logger.LogInformation($"Request complete - TaskController.Create() with Name {taskToBeCreated.Name} and Id {taskToBeCreated.Id}.");
            _logger.LogInformation($"Task with Id {taskToBeCreated.Id}: {JsonSerializer.Serialize(taskToBeCreated)}");

            return Created();
        }

        /// <summary>
        /// Allows the user to update a specific task
        /// </summary>
        /// <param name="taskToBeUpdated"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(DTO.Task taskToBeUpdated)
        {
            _logger.LogInformation($"Request received - TaskController.Update() using Id {taskToBeUpdated.Id}.");

            _taskService.Update(taskToBeUpdated);

            _logger.LogInformation($"Request complete - TaskController.Update() using Id {taskToBeUpdated.Id}.");

            return NoContent();
        }

        /// <summary>
        /// Allows the user to delete a specific task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Request received - TaskController.Delete() using Id {id}.");

            _taskService.Delete(id);

            _logger.LogInformation($"Request complete - TaskController.Delete() using Id {id}.");

            return NoContent();
        }
    }
}