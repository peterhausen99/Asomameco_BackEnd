
namespace webapi.db.connection
{


	public interface IDbConnection
	{

		public Task<T?> GetItem<T>(object id) where T : class, new();

		public Task<List<T>> GetItems<T>() where T : new();

		public Task<T?> Insert<T>(T value) where T : class;

		public Task<bool> Update<T>(T value);

		public Task<bool> Delete<T>(object id);

	}
}