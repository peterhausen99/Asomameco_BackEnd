using System.Reflection;
using webapi.db.attributes;

namespace webapi.db
{

	public class QueryGen<T>
	{
		private static string TableName => typeof(T).GetCustomAttribute<TableNameAttribute>()?.TableName ?? typeof(T).Name;

		private static IEnumerable<string> Fields =>
									from field
									in typeof(T).GetFields()
									select field.Name;


		private static string PrimaryKey => (
				from field
				in typeof(T).GetFields()
				where field.GetCustomAttribute<PrimaryKeyAttribute>() is not null
				select field.Name).FirstOrDefault() ?? $"{TableName}Id";

		public static string SelectAll =>
					$@"select {string.Join(", ", Fields)} " +
					$"from {TableName}";

		public static string SelectById =>
				 	$@"select {string.Join(", ", Fields)} " +
					$"from {TableName} " +
					$"where {PrimaryKey}=@KeyValue";

		public static string Insert =>
					$"insert into ({string.Join(", ", Fields)}) " +
					$"values ({string.Join(", ", from field in Fields select $"@{field}")}); " +
					"select LAST_INSERT_ID();";

		public static string Update =>
					$"update {TableName} " +
					$"set {string.Join(", ", from field in Fields select $"{field} = @{field}")} " +
					$"where {PrimaryKey} = @KeyValue";

		public static string Delete =>
					$"delete from {TableName} " +
					$"where {PrimaryKey} = @KeyValue";
	}

}