namespace TODOList.Services.Interfaces
{
    public interface ITaskService
    {
        public ICollection<DTO.Task> GetList();

        public DTO.Task GetById(int id);

        public void Update(DTO.Task taskToBeUpdated);

        public DTO.Task Create(DTO.Task taskToBeCreated);

        public void Delete(int id);
    }
}