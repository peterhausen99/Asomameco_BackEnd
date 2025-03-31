namespace webapi.db.attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class StringValueAttribute(string value) : Attribute
	{
		public string value = value;
	}

}