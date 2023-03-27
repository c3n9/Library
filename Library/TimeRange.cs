using System;
using System.Collections.Generic;
using System.Text;


namespace Library
{
    public class TimeRange
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public bool IsCoversRange(TimeRange range)
        {
            return StartTime < range.EndTime && range.StartTime < EndTime;
        }

        public override string ToString()
        {
            return $"{StartTime:hh\\:mm}-{EndTime:hh\\:mm}";
        }
    }
}
