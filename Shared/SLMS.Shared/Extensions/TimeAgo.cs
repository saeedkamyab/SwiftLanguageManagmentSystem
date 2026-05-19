namespace SLMS.Shared.Extensions
{
    public static class TimeAgo
    {
        public static string ToTimeAgo(this DateTime datetime)
        {
            var diff = DateTime.UtcNow - datetime;
            if (diff.TotalSeconds < 60)
                return $"{(int)diff.TotalSeconds} ثانیه قبل";

            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} دقیقه قبل";

            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} ساعت قبل";

            if (diff.TotalDays < 30)
                return $"{(int)diff.TotalDays} روز قبل";

            if (diff.TotalDays < 365)
                return $"{(int)(diff.TotalDays / 30)} ماه قبل";

            return $"{(int)(diff.TotalDays / 365)} سال قبل";
        }
    }
}
