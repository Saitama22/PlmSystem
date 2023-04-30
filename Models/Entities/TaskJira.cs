using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PlmSystem.Models.Intarfaces.Entities;

namespace PlmSystem.Models.Entities
{
	public class TaskJira : IIdEntity
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public TaskState? State { get; set; }
	}
}
