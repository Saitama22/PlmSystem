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
	public class TaskJiraRepo : BaseIdRepo<TaskJira>, ITaskJiraRepo
	{
		public TaskJiraRepo(JiraDbContext context) : base(context)
		{
		}

		protected override DbSet<TaskJira> MainDbSet => Context.Tasks;
	}
}
