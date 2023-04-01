using Library;

namespace UnitTestLibrary
{
    public class CalculationsTests
    {
        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To18With30MinutesConsultationTime_ShouldReturn14Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(10), TimeSpan.FromHours(11), TimeSpan.FromHours(15), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = { 60, 30, 10, 10, 40 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 30);

            Assert.Equal(14, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To18With20MinutesConsultationTime_ShouldReturn21Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(10), TimeSpan.FromHours(11), TimeSpan.FromHours(15), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = { 60, 30, 10, 10, 40 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 20);

            Assert.Equal(21, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To18With40MinutesConsultationTime_ShouldReturn7Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(9), TimeSpan.FromHours(10.5), TimeSpan.FromHours(12), new TimeSpan(15, 30, 0), new TimeSpan(17, 0, 0) };
            int[] durations = { 60, 60, 20, 10, 30 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 40);

            Assert.Equal(7, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To9With60MinutesConsultationTime_ShouldReturn0Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(8) };
            int[] durations = { 60 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(9), 60);

            Assert.Empty(test);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To9AndAHalfWith90MinutesConsultationTime_ShouldReturn0Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(8) };
            int[] durations = { 60 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(9.5), 90);

            Assert.Empty(test);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To18With35MinutesConsultationTime_ShouldReturn8Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(8), TimeSpan.FromHours(10), TimeSpan.FromHours(12), new TimeSpan(13, 30, 0), TimeSpan.FromHours(14),
                new TimeSpan(16, 50, 0), new TimeSpan(17, 20, 0) };
            int[] durations = { 60, 25, 15, 50, 40, 15, 30 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 35);

            Assert.Equal(8, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To14AndAHalfWith15MinutesConsultationTime_ShouldReturn20Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(8), TimeSpan.FromHours(9), TimeSpan.FromHours(10), new TimeSpan(13, 30, 0), TimeSpan.FromHours(14),
                new TimeSpan(16, 50, 0), new TimeSpan(17, 20, 0) };
            int[] durations = { 5, 10, 10, 7, 40, 50, 5 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(14.5), 15);

            string[] expected = new string[] {"08:05-08:20", "08:20-08:35", "08:35-08:50", "09:10-09:25",
                "09:25-09:40", "09:40-09:55", "10:10-10:25", "10:25-10:40",
                "10:40-10:55", "10:55-11:10", "11:10-11:25", "11:25-11:40",
                "11:40-11:55", "11:55-12:10", "12:10-12:25", "12:25-12:40",
                "12:40-12:55", "12:55-13:10", "13:10-13:25", "13:37-13:52"};

            Assert.Equal(expected, test);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To18With90MinutesConsultationTime_ShouldReturn2Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(8), TimeSpan.FromHours(10), TimeSpan.FromHours(12), new TimeSpan(13, 30, 0), TimeSpan.FromHours(14),
                new TimeSpan(16, 50, 0), new TimeSpan(17, 20, 0) };
            int[] durations = { 60, 25, 15, 50, 40, 15, 30 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 90);

            Assert.Equal(2, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTimeFrom8To20With41MinutesConsultationTime_ShouldReturn7Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(8), TimeSpan.FromHours(10), TimeSpan.FromHours(12), new TimeSpan(13, 30, 0), TimeSpan.FromHours(14),
                new TimeSpan(16, 50, 0), new TimeSpan(17, 20, 0) };
            int[] durations = { 60, 25, 15, 50, 40, 15, 30 };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 41);

            Assert.Equal(7, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_NoBusyRanges_ShouldReturnAllWorkingTimePeriods()
        {
            TimeSpan[] startTimes = { };
            int[] durations = { };

            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 30);

            var expected = new[]
            {
            "08:00-08:30",
            "08:30-09:00",
            "09:00-09:30",
            "09:30-10:00",
            "10:00-10:30",
            "10:30-11:00",
            "11:00-11:30",
            "11:30-12:00",
            "12:00-12:30",
            "12:30-13:00",
            "13:00-13:30",
            "13:30-14:00",
            "14:00-14:30",
            "14:30-15:00",
            "15:00-15:30",
            "15:30-16:00",
            "16:00-16:30",
            "16:30-17:00",
            "17:00-17:30",
            "17:30-18:00"
            };

            Assert.Equal(expected, test);
        }
    }
}