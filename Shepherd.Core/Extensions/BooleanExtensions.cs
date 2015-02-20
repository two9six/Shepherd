namespace Shepherd.Core.Extensions
{
	public static class BooleanExtensions
	{
		public const string TrueDisplay = "Yes";
		public const string FalseDisplay = "No";
		public const string NullDisplay = "";
		public const string TrueValue = "true";
		public const string FalseValue = "false";
		public const string NullValue = "";

		public static string ToDisplayText(this bool @this)
		{
			return @this ? BooleanExtensions.TrueDisplay : BooleanExtensions.FalseDisplay;
		}

		public static string ToDisplayText(this bool? @this)
		{
			return @this == null ? NullDisplay : @this.Value.ToDisplayText();
		}

		public static string ToValueText(this bool @this)
		{
			return @this ? BooleanExtensions.TrueValue : BooleanExtensions.FalseValue;
		}

		public static string ToValueText(this bool? @this)
		{
			return @this == null ? NullValue : @this.Value.ToValueText();
		}
	}
}
