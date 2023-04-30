using PlmSystem.Models.Entities;

namespace PlmSystem.Models.Intarfaces.Handlers
{
	public interface ITaskHandler
	{
		Task AddTaskAsync(TaskJira taskJira, int taskStateId);
		Task AddTaskAsync(TaskJira taskJira);
		Task DeleteTask(int taskId);
		Task<List<TaskState>?> GetTasksAsync(int projectId);
	}
}
