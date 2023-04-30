using Microsoft.AspNetCore.Mvc;
using PlmSystem.Models.Entities;
using PlmSystem.Models.Intarfaces.Handlers;

namespace PlmSystem.Controllers
{
	[Route("api/task")]
	public class TaskController
	{
		private readonly ITaskHandler _taskHandler;

		public TaskController(ITaskHandler taskHandler)
		{
			_taskHandler = taskHandler;
		}

		[HttpGet("tasks")]
		public async Task<List<TaskState>?> Tasks(int projectId)
		{
			var tasks = await _taskHandler.GetTasksAsync(projectId);
			return tasks;
		}

		[HttpPost("add")]
		public async Task CreateTaskAsync([FromBody] TaskJira taskJira, int taskStateId)
		{
			await _taskHandler.AddTaskAsync(taskJira, taskStateId);
		}

		[HttpPut("update")]
		public async Task UpdateTask([FromBody] TaskJira taskJira)
		{
			await _taskHandler.AddTaskAsync(taskJira);
		}

		[HttpDelete("delete")]
		public async Task DeleteTask(int taskId)
		{
			await _taskHandler.DeleteTask(taskId);
		}
	}
}
