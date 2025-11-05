using TODOList.Services.Interfaces;

namespace TODOList.Services
{
    public class TaskService : ITaskService
    {
        private ICollection<DTO.Task> _tasks;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ILogger<TaskService> logger)
        {
            _logger = logger;

            _logger.LogInformation("Creating automatically generated tasks.");

            _tasks =
            [
                new DTO.Task { Id = 1, Date = DateTime.Today.AddDays(1), Name = "Generated Task #1", Description = "Automatically generated task for test purposes #1." },
                new DTO.Task { Id = 2, Date = DateTime.Today.AddDays(2), Name = "Generated Task #2", Description = "Automatically generated task for test purposes #2." },
            ];

            _logger.LogInformation("Tasks created.");
        }

        public DTO.Task GetById(int id)
        {
            _logger.LogInformation($"Request received - TaskService.GetById() with Id {id}.");

            var value = _tasks?.Where(p => p.Id == id).FirstOrDefault();

            if (value == null)
            {
                _logger.LogInformation($"Task with Id {id} not found.");
                throw new Exception($"Task with Id {id} not found.");
            }

            _logger.LogInformation($"Request completed - TaskService.GetById() with Id {id}.");

            return value;
        }

        public ICollection<DTO.Task> GetList()
        {
            _logger.LogInformation("Request received - TaskService.Get().");
            return _tasks?.OrderBy(p => p.Id).ToList() ?? [];
        }

        public void Update(DTO.Task taskToBeUpdated)
        {
            _logger.LogInformation($"Request received - TaskService.Update() with Id {taskToBeUpdated.Id}.");

            var value = _tasks?.Where(p => p.Id == taskToBeUpdated.Id).FirstOrDefault();

            if (value == null)
            {
                _logger.LogInformation($"Task with Id {taskToBeUpdated.Id} not found.");
                throw new Exception($"Task with Id {taskToBeUpdated.Id} not found.");
            }

            _tasks?.Remove(value);
            _tasks?.Add(taskToBeUpdated);

            _logger.LogInformation($"Request completed - TaskService.Update() with Id {taskToBeUpdated.Id}.");
        }

        public void Delete(int id)
        {
            _logger.LogInformation($"Request received - TaskService.Delete() with Id {id}.");

            var value = _tasks?.Where(p => p.Id == id).FirstOrDefault();

            if (value == null)
            {
                _logger.LogInformation($"Task with Id {id} not found.");
                throw new Exception($"Task with Id {id} not found.");
            }

            _tasks?.Remove(value);

            _logger.LogInformation($"Request completed - TaskService.Delete() with Id {id}.");
        }

        public DTO.Task Create(DTO.Task taskToBeCreated)
        {
            _logger.LogInformation($"Request received - TaskService.Create() with Name {taskToBeCreated.Name}.");

            taskToBeCreated.Id = _tasks.Count == 0 == false ? _tasks.OrderBy(p => p.Id).Last().Id + 1 : 1;

            _tasks?.Add(taskToBeCreated);

            _logger.LogInformation($"Request completed - TaskService.Create() with Name {taskToBeCreated.Name} and Id {taskToBeCreated.Id}.");

            return taskToBeCreated;
        }
    }
}