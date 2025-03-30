namespace webapi.db.attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class TableNameAttribute(string v) : Attribute
	{
		public string TableName { get; } = v;
	}

}