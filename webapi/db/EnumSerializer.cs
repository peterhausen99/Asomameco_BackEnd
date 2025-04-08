using System.Reflection;
using webapi.db.attributes;

namespace webapi.db
{
	public class EnumSerializer
	{
		public static object Parse(Type enumType, string value)
		{
			foreach (var field in enumType.GetProperties())
			{
				var attr = field.GetCustomAttribute<StringValueAttribute>();
				if (attr != null && attr.value == value)
				{
					return Enum.Parse(enumType, field.Name);
				}
			}

			return Enum.Parse(enumType, value);
		}

		public static string ToString(Type enumType, object enumValue)
		{
			string enumName = Enum.GetName(enumType, enumValue) ?? throw new ArgumentException("Invalid enum value", nameof(enumValue));

			var field = enumType.GetProperty(enumName);
			var attr = field?.GetCustomAttribute<StringValueAttribute>();

			return attr?.value ?? enumName;
		}

	}
}