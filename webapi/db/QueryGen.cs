using System.Reflection;
using webapi.db.attributes;

namespace webapi.db
{

	public class QueryGen
	{

		static string[] GetFieldNames(Type type)
		{
			List<string> values = [];

			foreach (var field in type.GetFields())
			{
				values.Add(field.Name);
			}

			return [.. values];
		}

		static string GetTableName(Type type)
		{
			return type.GetCustomAttribute<TableNameAttribute>()?.TableName ?? type.Name;
		}

		static string GetPrimaryKey(Type type)
		{
			foreach (var field in type.GetFields())
			{
				if (field.GetCustomAttribute<PrimaryKeyAttribute>() is not null)
				{
					return field.Name;
				}
			}
			return "Id";
		}

		public static string GetAll(Type type)
		{
			return $@"select {string.Join(", ", GetFieldNames(type))} from {GetTableName(type)}";
		}

		public static string GetById(Type type)
		{
			return $@"select {string.Join(", ", GetFieldNames(type))} from {GetTableName(type)} where {GetPrimaryKey(type)}=@KeyValue";
		}

		//void insert();

		//void update();

		//void remove();
	}

}