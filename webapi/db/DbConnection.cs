
using System.Reflection;
using MySql.Data.MySqlClient;
using webapi.db.attributes;

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

		public async Task<T?> Insert<T>(T value) where T : class
		{
			try
			{
				await using MySqlConnection connection = new(connectionString);
				await connection.OpenAsync();
				await using MySqlCommand command = new(QueryGen<T>.Insert, connection);
				foreach (var field in QueryGen<T>.InsertFields)
				{
					var fieldInfo = typeof(T).GetField(field);
					var fieldValue = typeof(T).GetField(field)?.GetValue(value);

					if (fieldInfo?.FieldType.IsEnum == true && fieldValue != null)
					{
						fieldValue = EnumSerializer.ToString(fieldInfo.FieldType, fieldValue);
					}

					command.Parameters.AddWithValue($"@{field}", fieldValue ?? DBNull.Value);
				}

				var result = await command.ExecuteScalarAsync();
				var IdField = typeof(T).GetField(QueryGen<T>.PrimaryKey);
				if (IdField?.GetCustomAttribute<IdentityFieldAttribute>() is not null)
				{
					IdField?.SetValue(value, result);
				}
				return value;
			}
			catch (MySqlException ex) when (ex.Number == 1062) // ER_DUP_ENTRY
			{
				return null;
			}
		}

		public async Task<bool> Update<T>(T value)
		{
			try
			{
				await using MySqlConnection connection = new(connectionString);
				await connection.OpenAsync();
				var ins = QueryGen<T>.Insert;
				await using MySqlCommand command = new(QueryGen<T>.Update, connection);
				foreach (var field in QueryGen<T>.Fields)
				{
					var fieldInfo = typeof(T).GetField(field);
					var fieldValue = typeof(T).GetField(field)?.GetValue(value);

					if (fieldInfo?.FieldType.IsEnum == true && fieldValue != null)
					{
						fieldValue = EnumSerializer.ToString(fieldInfo.FieldType, fieldValue);
					}
					command.Parameters.AddWithValue($"@{field}", fieldValue ?? DBNull.Value);
				}
				var pkValue = typeof(T).GetField(QueryGen<T>.PrimaryKey)?.GetValue(value);
				command.Parameters.AddWithValue("@KeyValue", pkValue);

				return await command.ExecuteNonQueryAsync() > 0;
			}
			catch (MySqlException ex) when (ex.Number == 1062) // ER_DUP_ENTRY
			{
				return false;
			}
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
							(Type enumType, string strVal) when enumType.IsEnum => EnumSerializer.Parse(enumType, strVal),
							(Type enumType, _) when enumType.IsEnum => EnumSerializer.ToString(enumType, value),
							_ => Convert.ChangeType(value, field.FieldType)
						});
					}
				}
			}
			return item;
		}


	}
}