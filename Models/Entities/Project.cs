using System.Collections.Generic;
using PlmSystem.Models.Intarfaces.Entities;

namespace PlmSystem.Models.Entities
{
	public class Project: IIdEntity
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public List<TaskState>? TaskStates { get; set; }
	}
}
