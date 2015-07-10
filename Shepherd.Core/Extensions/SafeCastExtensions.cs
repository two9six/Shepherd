
namespace Shepherd.Core.Extensions
{
	public static class SafeCastExtensions
	{
		public static int ToSafeInt(this string value)
		{
			int result = 0;
			int.TryParse(value, out result);
			return result;
		}
	}
}