using System;

namespace Common.Persistence.Helpers
{
    public static class DateUtils
    {
		public static DateTime GetCurrentDateTime()
		{
			return DateTime.Now;
		}

		public static DateTime GetCurrentDate()
		{
			return GetCurrentDateTime().Date;
		}

		public static Int32 GetNowInt()
        {
            var now = DateTime.UtcNow;
            var monthString = now.Month.ToString();
            var month = now.Month < 10 ? string.Concat("0", monthString) : monthString;
            var day = now.Day < 10 ? string.Concat("0", now.Day.ToString()) : now.Day.ToString();
            return Convert.ToInt32($"{now.Year}{month}{day}");
        }

        public static Int32 GetMonthInt()
        {
            var now = DateTime.UtcNow;
            var monthString = now.Month.ToString();
            var month = now.Month < 10 ? string.Concat("0", monthString) : monthString;
            return Convert.ToInt32($"{now.Year}{month}");
        }
     
        public static Int32 GetDateInt(DateTime now)
        {
            var monthString = now.Month.ToString();
            var month = now.Month < 10 ? string.Concat("0", monthString) : monthString;
            var day = now.Day < 10 ? string.Concat("0", now.Day.ToString()) : now.Day.ToString();
            return Convert.ToInt32($"{now.Year}{month}{day}");
        }

        /// <summary>
        /// Convert existing int value to dd/MM/yyyy format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string IntToDate(this int input)
        {
            int date = input % 100;
            int month = (input / 100) % 100;
            int year = input / 10000;

            return $"{year}/{month}/{date}";
        }

        public static int ConvertDateTimeToInt(this DateTime dateTime)
        {
            string date = dateTime.Day.ToString("D2");
            string month = dateTime.Month.ToString("D2");
            string year = dateTime.Year.ToString();

            return Convert.ToInt32($"{year}{month}{date}");
        }

        public static int? ConvertDateTimeToInt(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return null;

            return ConvertDateTimeToInt(dateTime.Value);
        }

        public static DateTime ConvertIntToDateTime(this int input)
        {
            int day = input % 100;
            int month = (input / 100) % 100;
            int year = input / 10000;

            return new DateTime(year, month, day).Date;
        }

        public static DateTime? ConvertIntToDateTime(this int? input)
        {
            if (!input.HasValue)
                return null;

            return ConvertIntToDateTime(input.Value);
        }

        /// <summary>
		/// Gets the 12:00:00 instance of a DateTime
		/// </summary>
		public static DateTime AbsoluteStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Gets the 11:59:59 instance of a DateTime
        /// </summary>
        public static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return AbsoluteStart(dateTime).AddDays(1).AddTicks(-1);
        }

        public static int CalculateAge(DateTime dateOfBirth)
        {
            var age = 0;
            age = GetCurrentDateTime().Year - dateOfBirth.Year;
            if (GetCurrentDateTime().DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        public static string CalculateandDisplay(DateTime dateOfBirth)
        {
            var age = 0;
            age = GetCurrentDateTime().Year - dateOfBirth.Year;
            if (GetCurrentDateTime().DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return Convert.ToString(age) + " Years";
        }

        public static bool IsCorrectAge(DateTime dob)
        {
            var age = CalculateAge(dob);
            if (age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

		
    }
}
