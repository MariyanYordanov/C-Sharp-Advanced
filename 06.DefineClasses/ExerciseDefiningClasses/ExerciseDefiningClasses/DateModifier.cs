using System;
using System.Globalization;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static string[] StartDate { get; set; }
        public static string[] EndDate { get; set; }

        public static DateTime FromStringToInteger(string[] data)
        {
            int years = int.Parse(data[0]);
            int months = int.Parse(data[1]);
            int days = int.Parse(data[2]);
            DateTime date = new DateTime(years, months, days, new GregorianCalendar());
            return date;
        }

        public static double DateCalculator(string[] StartDate, string[] EndDate)
        {
            DateTime dataEnd = FromStringToInteger(EndDate);
            DateTime dataStart = FromStringToInteger(StartDate);
            double counter = Math.Abs((dataEnd - dataStart).TotalDays);
            return counter;
        }
    }
}
