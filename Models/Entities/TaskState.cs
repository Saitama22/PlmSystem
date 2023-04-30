using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using PlmSystem.Models.Intarfaces.Entities;

namespace PlmSystem.Models.Entities
{
	public class TaskState : IIdEntity
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public List<TaskJira>? TasksJira { get; set; }

		public Project? Project { get; set; }
	}
}
