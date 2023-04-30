using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlmSystem.Models.Entities;

namespace PlmSystem.Models.Intarfaces.Repositories
{
	public interface ITaskStateRepo : IIdRepo<TaskState>
	{
		Task AddTaskAsync(TaskJira taskJira, int taskStateId);
		Task RemoveTaskAsync(int taskId, int taskStateId);
	}
}
