namespace webapi.db.attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ColumnLengthAttribute : Attribute
	{
		public ColumnLengthAttribute(int v)
		{
			V = v;
		}

		public int V { get; }
	}
}