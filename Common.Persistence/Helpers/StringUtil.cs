using System.Text.RegularExpressions;

namespace Common.Persistence.Helpers
{
    public static class StringUtil
	{
		public static bool IsEmailAddressStr(string str)
		{
			bool isEmail = Regex.IsMatch(str, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
			return isEmail;
		}

		public static bool IsNumericStr(string str, out int number)
		{
			bool isNumeric = int.TryParse(str, out number);
			return isNumeric;
		}

		public static bool IsNHSNumberStr(string str)
		{
			if (string.IsNullOrEmpty(str))
				return false;
			int number = 0;
			bool isNHSNumberStr = IsNumericStr(str, out number) && str.Length == 10;
			return isNHSNumberStr;
		}
	}
}
