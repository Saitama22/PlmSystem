using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlmSystem.Models.Entities;
using PlmSystem.Models.Intarfaces.Handlers;

namespace PlmSystem.Controllers
{
	[Route("api/taskstate")]
	public class TaskStateController
	{
		private readonly ITaskStateHandler _taskStateHandler;

		public TaskStateController(ITaskStateHandler taskStateHandler)
		{
			_taskStateHandler = taskStateHandler;
		}

		[HttpGet("taskstates")]
		public async Task<List<TaskState>?> TaskStates(int projectId)
		{
			var taskStates = await _taskStateHandler.GetTaskStates(projectId);
			return taskStates;
		}

		[HttpPost("add")]
		public async Task AddTaskState(TaskState taskState)
		{
			await _taskStateHandler.AddTaskState(taskState);
		}

		[HttpPut("update")]
		public async Task UpdateTaskState(TaskState taskState)
		{
			await _taskStateHandler.UpdateTaskState(taskState);
		}

		[HttpDelete("delete")]
		public async Task DeleteTaskState(int taskStateId)
		{
			await _taskStateHandler.DeleteTaskState(taskStateId);
		}
	}
}
