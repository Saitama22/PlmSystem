using System.Linq;
using System.Threading.Tasks;
using PlmSystem.Models.Intarfaces.Entities;

namespace PlmSystem.Models.Intarfaces.Repositories
{
	public interface IIdRepo<T> : IRepo<T> where T: IIdEntity 
	{
		IQueryable<T> Records { get; }

		Task<T> GetByIdAsync(int id);

		Task DeleteByIdAsync(int id);
	}
}
