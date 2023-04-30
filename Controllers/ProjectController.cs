using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlmSystem.Models.Entities;
using PlmSystem.Models.Intarfaces.Handlers;
using PlmSystem.Models.Intarfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PlmSystem.Controllers
{
	[Route("api/project")]
	public class ProjectController: Controller
	{
		private readonly IProjectHandler _projectHandler;
		public ProjectController(IProjectHandler projectHandler)
		{
			_projectHandler = projectHandler;
		}

		[HttpGet("projects")]
		public ActionResult<IQueryable<Project>> Projects()
		{
			var projects = _projectHandler.GetAllProjects();
			return Ok(projects);
			//return NoContent();
		}

		[HttpGet("project")]
		public async Task<Project> ProjectAsync(int projectId)	
		{
			var project = await _projectHandler.GetProjectAsync(projectId);
			return project;
		}

		[HttpPost("add")]
		public async Task CreateAsync([FromBody]Project project)
		{
			await _projectHandler.CreateOrUpdateAsync(project);
		}

		[HttpPut("update")]
		public async Task UpdateProject([FromBody]Project project)
		{
			await _projectHandler.UpdateProject(project);
		}

		[HttpDelete("delete")]
		public async Task DeleteProject(int projectId)
		{
			await _projectHandler.DeleteProject(projectId);
		}

	}
}
