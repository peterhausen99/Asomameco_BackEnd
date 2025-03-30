namespace webapi.db.attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ColumnLengthAttribute : Attribute
	{
		public ColumnLengthAttribute(int v)
		{
			V = v;
		}

		public int V { get; }
	}
}