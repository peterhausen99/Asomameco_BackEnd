
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace webapi.db
{


	public class DbConnection(string connectionString)
	{
		private readonly string connectionString = new(connectionString);


		public async Task<T?> GetItem<T>(string id) where T : class, new()
		{
			List<T> items = [];
			string selectQuery = QueryGen.GetById(typeof(T));
			await using (MySqlConnection connection = new(connectionString))
			{
				await connection.OpenAsync();
				await using MySqlCommand command = new(selectQuery, connection);
				command.Parameters.AddWithValue("@KeyValue", id);
				await using var reader = command.ExecuteReader();
				while (await reader.ReadAsync())
				{
					T item = MapReaderToObject<T>(reader);
					items.Add(item);
				}
			}
			return items.Count > 0 ? items[0] : null;
		}
		
		public async Task<List<T>> GetItems<T>() where T : new()
		{
			List<T> items = [];
			string selectQuery = QueryGen.GetAll(typeof(T));
			await using (MySqlConnection connection = new(connectionString))
			{
				await connection.OpenAsync();
				await using MySqlCommand command = new(selectQuery, connection);
				await using var reader = command.ExecuteReader();
				while (await reader.ReadAsync())
				{
					T item = MapReaderToObject<T>(reader);
					items.Add(item);
				}
			}
			return items;
		}

		private static T MapReaderToObject<T>(MySqlDataReader reader) where T : new()
		{
			T item = new();
			var fields = typeof(T).GetFields();

			for (int i = 0; i < reader.FieldCount; i++)
			{
				string columnName = reader.GetName(i);
				var field = fields.FirstOrDefault(p =>
					p.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));

				if (field != null)
				{
					if (reader[i] != DBNull.Value)
					{
						object value = reader[i];
						if (field.FieldType == typeof(bool) && value is ulong longVal)
						{
							field.SetValue(item, longVal != 0);
						}
						else
						{
							field.SetValue(item, value);
						}
					}
				}
			}
			return item;
		}


	}
}