using System;
using System.Data.SqlClient;

namespace JapaneseLearningApi.Shared
{
    public static class SafeSqlConverters
    {
        public static string ToSafeString(this object value)
        {
            return value == null ? string.Empty : value.ToString().Trim();
        }

        public static bool ToSafeBool(this object value)
        {
            return (value == null || value is DBNull) ? false : Convert.ToBoolean(value);
        }

        public static int ToSafeInt32(this object value)
        {
            if (value == null)
                return 0;

            int.TryParse(value.ToString(), out int num);
            return num;
        }

        public static double ToSafeDouble(this object value)
        {
            if (value == null)
                return 0;

            double.TryParse(value.ToString(), out double num);
            return num;
        }

        public static float ToSafeFloat(this object value)
        {
            if (value == null)
                return 0;

            float.TryParse(value.ToString(), out float num);
            return num;
        }

        public static decimal ToSafeDecimal(this object value)
        {
            if (value == null)
                return 0;

            decimal.TryParse(value.ToString(), out decimal num);
            return num;
        }

        public static byte ToSafeByte(this object value)
        {
            if (value == null)
                return 0;

            byte.TryParse(value.ToString(), out byte num);
            return num;
        }

        public static byte[] ToSafeByteArray(this object value)
        {
            return (value is DBNull || value == null || ((byte[])value).Length <= 0) ? null : (byte[])value;
        }

        public static TimeSpan ToSafeTimeSpan(this object value)
        {
            if (value == null)
                return new TimeSpan();

            TimeSpan.TryParse(value.ToString(), out TimeSpan time);
            return time;
        }

        public static DateTime ToSafeDateTime(this object value)
        {
            if (value == null)
                return DateTime.MinValue;

            DateTime.TryParse(value.ToString(), out DateTime date);
            return date;
        }

        public static DateTime ToCurrentFromUTCDateTime(this DateTime value)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(value);
        }

        //public static SoundPlayer ToSafeSoundPlayer(this object value)
        //{
        //    if (value == null)
        //        return DateTime.MinValue;

        //    DateTime.TryParse(value.ToString(), out DateTime date);
        //    return date;
        //}
    }
}
