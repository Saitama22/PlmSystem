using PlmSystem.Models.Entities;

namespace PlmSystem.Models.Intarfaces.Handlers
{
	public interface ITaskStateHandler
	{
		Task AddTaskState(TaskState taskState);
		Task DeleteTaskState(int taskStateId);
		Task<List<TaskState>?> GetTaskStates(int projectId);
		Task UpdateTaskState(TaskState taskState);
	}
}
