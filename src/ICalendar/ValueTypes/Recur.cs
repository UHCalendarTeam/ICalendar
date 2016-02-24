﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalendar.ValueTypes
{

    public class Recur
    {
        public RecurValues.Frequencies? Frequency { get; set; }

        public DateTime? Until { get; set; }

        public int? Count { get; set; }

        public int? Interval { get; set; }

        public int[] BySeconds { get; set; }

        public int[] ByMinutes { get; set; }

        public int[] ByHours { get; set; }

        //this need a more complex type. skiping for now
        public string[] ByDays { get; set; }

        public int[] ByMonthDay { get; set; }

        public int[] ByYearDay { get; set; }

        public int[] ByWeekNo { get; set; }

        public int[] ByMonth { get; set; }

        public int[] BySetPos { get; set; }

        public RecurValues.Weekday? Wkst { get; set; }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            if (Frequency == null)
                return "Frequency is Required for this valueType";

            strBuilder.Append("FREQ=");
            strBuilder.Append(RecurValues.ToString(Frequency.Value));

            if (Until !=null)
            {
                strBuilder.Append(";UNTIL=");
                strBuilder.Append(Until.Value.ToString("yyyyMMddTHHmmss") +
                                  (Until.Value.Kind == DateTimeKind.Utc ? "Z" : ""));
            }
            if (Count != null)
            {
                strBuilder.Append(";COUNT=");
                strBuilder.Append(Count);
            }
            if (Interval!=null)
            {
                strBuilder.Append(";INTERVAL=");
                strBuilder.Append(Interval);
            }
            if (BySeconds!=null && BySeconds.Length>0)
            {
                strBuilder.Append(";BYSECOND=");
                AppendAllMembers(strBuilder, BySeconds);
            }
            if (ByMinutes != null && ByMinutes.Length > 0)
            {
                strBuilder.Append(";BYMINUTE=");
                AppendAllMembers(strBuilder, ByMinutes);
            }
            if (ByHours != null && ByHours.Length > 0)
            {
                strBuilder.Append(";BYHOUR=");
                AppendAllMembers(strBuilder, ByHours);
            }
            //this has to change in a future when the type changes
            if (ByDays != null && ByDays.Length > 0)
            {
                strBuilder.Append(";BYDAY=");
                AppendAllMembers(strBuilder, ByDays);
            }
            if (ByMonthDay != null && ByMonthDay.Length > 0)
            {
                strBuilder.Append(";BYMONTHDAY=");
                AppendAllMembers(strBuilder, ByMonthDay);
            }
            if (ByYearDay != null && ByYearDay.Length > 0)
            {
                strBuilder.Append(";BYYEARDAY=");
                AppendAllMembers(strBuilder, ByYearDay);
            }
            if (ByWeekNo != null && ByWeekNo.Length > 0)
            {
                strBuilder.Append(";BYWEEKNO=");
                AppendAllMembers(strBuilder, ByWeekNo);
            }
            if (ByMonth != null && ByMonth.Length > 0)
            {
                strBuilder.Append(";BYMONTH=");
                AppendAllMembers(strBuilder, ByMonth);
            }
            if (BySetPos != null && BySetPos.Length > 0)
            {
                strBuilder.Append(";BYSETPOS=");
                AppendAllMembers(strBuilder, BySetPos);
            }
            if (Wkst!=null)
            {
                strBuilder.Append(";WKST=");
                strBuilder.Append(RecurValues.ToString(Wkst.Value));
            }

            return strBuilder.ToString();

        }

        private static void AppendAllMembers<T>(StringBuilder stringBuilder, T [] array)
        {
                stringBuilder.Append(array[0]);
                for (var i = 1; i < array.Length; i++)
                {
                    stringBuilder.Append(",");
                    stringBuilder.Append(array[i]);
                }
        }
    }

    public class RecurValues
    {
        public enum Frequencies
        {
            MINUTELY, HOURLY, DAILY, WEEKLY, MONTHLY, YEARLY
        }

        public enum Weekday
        {
            MO, TU, WE, TH, FR, SA, SU
        }
        /// <summary>
        /// Convert an Frequency to its string representation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(Frequencies value)
        {
            switch (value)
            {
                case Frequencies.MINUTELY:
                    return "MINUTELY";
                case Frequencies.HOURLY:
                    return "HOURLY";
                case Frequencies.DAILY:
                    return "DAILY";
                case Frequencies.WEEKLY:
                    return "WEEKLY";
                case Frequencies.MONTHLY:
                    return "MONTHLY";
                case Frequencies.YEARLY:
                    return "YEARLY";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        /// <summary>
        /// Convert an WeekDay to its string representation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(Weekday value)
        {
            switch (value)
            {
                case Weekday.MO:
                    return "MO";
                case Weekday.TU:
                    return "TU";
                case Weekday.WE:
                    return "WE";
                case Weekday.TH:
                    return "TH";
                case Weekday.FR:
                    return "FR";
                case Weekday.SA:
                    return "SA";
                case Weekday.SU:
                    return "SU";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        /// <summary>
        /// Convert the string representation of
        /// a Frequency to a Frequency
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Frequencies? ParseValue(string value)
        {
            switch (value)
            {
                case "MINUTELY":
                    return Frequencies.MINUTELY;
                case "HOURLY":
                    return Frequencies.HOURLY;
                case "DAILY":
                    return Frequencies.DAILY;
                case "WEEKLY":
                    return Frequencies.WEEKLY;
                case "MONTHLY":
                    return Frequencies.MONTHLY;
                case "YEARLY":
                    return Frequencies.YEARLY;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert the string representation of
        /// a Weekday to a Weekday
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Weekday ParseValues(string value)
        {
            switch (value)
            {
                case "MO":
                    return Weekday.MO;
                case "TU":
                    return Weekday.TU;
                case "WE":
                    return Weekday.WE;
                case "TH":
                    return Weekday.TH;
                case "FR":
                    return Weekday.FR;
                case "SA":
                    return Weekday.SA;
                case "SU":
                    return Weekday.SU;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }
    }
}