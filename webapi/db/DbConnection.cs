
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
			await using (MySqlConnection connection = new(connectionString))
			{
				await connection.OpenAsync();
				await using MySqlCommand command = new(QueryGen<T>.SelectById, connection);
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
			await using (MySqlConnection connection = new(connectionString))
			{
				await connection.OpenAsync();
				await using MySqlCommand command = new(QueryGen<T>.SelectAll, connection);
				await using var reader = command.ExecuteReader();
				while (await reader.ReadAsync())
				{
					T item = MapReaderToObject<T>(reader);
					items.Add(item);
				}
			}
			return items;
		}

		public async Task<T> Insert<T>(T value)
		{
			await using MySqlConnection connection = new(connectionString);
			await connection.OpenAsync();
			var ins = QueryGen<T>.Insert;
			await using MySqlCommand command = new(QueryGen<T>.Insert, connection);
			foreach (var field in QueryGen<T>.InsertFields)
			{
				if (field != QueryGen<T>.PrimaryKey)
				{
					var fieldValue = typeof(T).GetField(field)?.GetValue(value);
					command.Parameters.AddWithValue($"@{field}", fieldValue ?? DBNull.Value);
				}
			}

			var result = await command.ExecuteScalarAsync();
			typeof(T).GetField(QueryGen<T>.PrimaryKey)?.SetValue(value, result);
			return value;
		}

		public async Task<bool> Update<T>(T value)
		{
			await using MySqlConnection connection = new(connectionString);
			await connection.OpenAsync();
			var ins = QueryGen<T>.Insert;
			await using MySqlCommand command = new(QueryGen<T>.Update, connection);
			foreach (var field in QueryGen<T>.Fields)
			{
				var fieldValue = typeof(T).GetField(field)?.GetValue(value);
				command.Parameters.AddWithValue($"@{field}", fieldValue ?? DBNull.Value);
			}
			var pkValue = typeof(T).GetField(QueryGen<T>.PrimaryKey)?.GetValue(value);
			command.Parameters.AddWithValue("@KeyValue", pkValue);

			return await command.ExecuteNonQueryAsync() > 0;
		}

		public async Task<bool> Delete<T>(T value)
		{
			await using MySqlConnection connection = new(connectionString);
			await connection.OpenAsync();
			var ins = QueryGen<T>.Delete;
			await using MySqlCommand command = new(QueryGen<T>.Delete, connection);
			var pkValue = typeof(T).GetField(QueryGen<T>.PrimaryKey)?.GetValue(value);
			command.Parameters.AddWithValue("@KeyValue", pkValue);

			return await command.ExecuteNonQueryAsync() > 0;
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
						field.SetValue(item, (field.FieldType, value) switch
						{
							(Type boolType, ulong longVal) when boolType == typeof(bool) => longVal != 0,
							(Type ulongType, int intVal) when ulongType == typeof(ulong) => (ulong)intVal,
							_ => Convert.ChangeType(value, field.FieldType)
						});
					}
				}
			}
			return item;
		}


	}
}