﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlmSystem.Models.Entities;
using PlmSystem.Models.Intarfaces.Handlers;
using PlmSystem.Models.Intarfaces.Repositories;

namespace PlmSystem.Models.Handlers
{
	public class ProjectHandler : IProjectHandler
	{
		private readonly IProjectRepo _projectRepo;
		private readonly ITaskStateRepo _taskStateRepo;

		public ProjectHandler(IProjectRepo projectRepo, ITaskStateRepo taskStateRepo)
		{
			_projectRepo = projectRepo;
			_taskStateRepo = taskStateRepo;
		}

		public async Task CreateOrUpdateAsync(Project project)
		{
			if (project.Id == 0)
				project.TaskStates = new List<TaskState>()
				{
					new TaskState() { Name = "Надо сделать" },
					new TaskState() { Name = "В работе" },
					new TaskState() { Name = "Сделано" },
				};
			await _projectRepo.CreateOrUpdateAsync(project);
		}

		public IQueryable<Project> GetAllProjects()
		{
			return _projectRepo.Records.ToList().AsQueryable() ?? new List<Project>().AsQueryable();
		}

		public async Task<Project> GetProjectAsync(int projectId)
		{
			var project = await _projectRepo.GetByIdAsync(projectId);
			project.TaskStates ??= new();
			foreach (var taskStates in project.TaskStates)
			{
				taskStates.TasksJira ??= new();
			}
			return project;
		}

		public async Task AddTaskAsync(TaskJira taskJira, int taskStateId)
		{
			await _taskStateRepo.AddTaskAsync(taskJira, taskStateId);
		}

		public async Task<int> GetProjectIdByTaskStateIdAsync(int taskStateId)
		{
			var taskState = await _taskStateRepo.GetByIdAsync(taskStateId);
			return (await _projectRepo.GetByIdAsync(taskState.Project.Id)).Id;
		}

		public async Task DeleteProject(int id)
		{
			await _projectRepo.DeleteByIdAsync(id);
		}

		public async Task DeleteProject(Project project)
		{
			await _projectRepo.DeleteAsync(project);
		}

		public async Task AddTaskStateAsync(TaskState taskState, int projectId)
		{
			var project = await GetProjectAsync(projectId);
			project.TaskStates.Add(taskState);
			await _projectRepo.CreateOrUpdateAsync(project);
		
		}

		public async Task RemoveTaskStateAsync(int taskStateId, int projectId)
		{
			var project = await GetProjectAsync(projectId);
			var taskState = project.TaskStates.FirstOrDefault(r => r.Id == taskStateId);
			project.TaskStates.Remove(taskState);
		}

		public async Task RemoveTaskAsync(int taskId, int taskStateId)
		{
			await _taskStateRepo.RemoveTaskAsync(taskId, taskStateId);
		}

		public Task UpdateProject(Project project)
		{
			throw new NotImplementedException();
		}
	}
}
