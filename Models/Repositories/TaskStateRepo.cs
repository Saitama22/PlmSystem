using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlmSystem.Models.DbContexts;
using PlmSystem.Models.Entities;
using PlmSystem.Models.Intarfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PlmSystem.Models.Repositories
{
	public class TaskStateRepo : BaseIdRepo<TaskState>, ITaskStateRepo
	{
		public TaskStateRepo(JiraDbContext context) : base(context)
		{
		}

		protected override DbSet<TaskState> MainDbSet => Context.TaskStates;

		public async Task AddTaskAsync(TaskJira taskJira, int taskStateId)
		{
			var taskState = await GetByIdAsync(taskStateId);
			taskState.TasksJira ??= new();
			taskState.TasksJira.Add(taskJira);
			await Context.SaveChangesAsync(); 
		}

		public async override Task<TaskState> GetByIdAsync(int id)
		{
			return await MainDbSet.Include(r => r.TasksJira).FirstOrDefaultAsync(r => r.Id == id);
		}

		public async Task RemoveTaskAsync(int taskId, int taskStateId)
		{
			var taskState = await GetByIdAsync(taskStateId);
			if (taskState == null)
				throw new Exception("Нет задачи в бд");
			var taskJira = taskState.TasksJira.FirstOrDefault(r => r.Id == taskId);
			if (taskJira == null)
				throw new Exception("Нет задачи в бд");
			taskState.TasksJira.Remove(taskJira);
		}

		protected override bool WithIncludeEntity(TaskState entity)
		{
			if (entity.TasksJira == null)
				return false;
			return true;
		}
	}
}
