using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Calculations
    {
        public static string[] AvailablePeriods(
            TimeSpan[] startTimes, 
            int[] durations, 
            TimeSpan beginWorkingTime, 
            TimeSpan endWorkingTime, 
            int consulationTime)
        {
            var currentTime = beginWorkingTime;
            var consulationTimeSpan = TimeSpan.FromMinutes(consulationTime);
            var results = new List<TimeRange>();
            var ranges = GenerateBusyRanges(startTimes, durations);

            int durationIndex = 0;

            while (currentTime < endWorkingTime)
            {
                var endTime = currentTime + consulationTimeSpan;
                TimeRange range = new TimeRange() { StartTime = currentTime, EndTime = endTime };
                var queryResult = GetCoveredRange(range, ranges);
                if (queryResult is null)
                {
                    if (endTime <= endWorkingTime)
                    {
                        results.Add(range);
                    }
                }
                else
                {
                    currentTime = queryResult.EndTime;
                    continue;
                }
                currentTime += consulationTimeSpan;
            }
            return results.Select(x => x.ToString()).ToArray();
        }

        public static TimeRange[] GenerateBusyRanges(TimeSpan[] startTimes, int[] durations)
        {
            return startTimes.Select((t,i) => new TimeRange
            {
                StartTime = t,
                EndTime = t.Add(TimeSpan.FromMinutes(durations[i]))
            }).ToArray();
        }
        public static TimeRange GetCoveredRange(TimeRange range, TimeRange[] ranges)
        {
            return ranges.FirstOrDefault(x => x.IsCoversRange(range));
        }   

    }
}
