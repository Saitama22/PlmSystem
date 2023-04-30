namespace PlmSystem.Models.Entities
{
	public class Comment
	{
		public int Id { get; set; }
		public User Commenter { get; set; }
		public string Content { get; set; }

	}
}