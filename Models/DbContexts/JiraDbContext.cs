using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlmSystem.Models.Entities;
using PlmSystem.Models.Intarfaces.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace PlmSystem.Models.DbContexts
{
	public class JiraDbContext: DbContext, IJiraDbContext
	{
		
		public DbSet<Project> Projects { get; set; }		
		public DbSet<TaskJira> Tasks { get; set; }
		public DbSet<TaskState> TaskStates { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Role> Roles { get; set; }
				
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=JiraDb;Trusted_Connection=True;");
		}
	}
}
