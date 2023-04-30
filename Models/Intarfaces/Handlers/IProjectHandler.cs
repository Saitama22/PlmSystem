using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlmSystem.Models.Entities;

namespace PlmSystem.Models.Intarfaces.Handlers
{
	public interface IProjectHandler
	{
		Task CreateOrUpdateAsync(Project project);
		Task AddTaskAsync(TaskJira taskJira, int taskStateId);
		IQueryable<Project> GetAllProjects();
		Task<Project> GetProjectAsync(int projectId);
		Task<int> GetProjectIdByTaskStateIdAsync(int taskStateId);
		//Task DeleteProject(int id);
		Task DeleteProject(Project project);
		Task AddTaskStateAsync(TaskState taskState, int projectId);
		Task RemoveTaskStateAsync(int taskStateId, int projectId);
		Task RemoveTaskAsync(int taskId, int taskStateId);
		Task UpdateProject(Project project);
		Task DeleteProject(int projectId);
	}
}
