using Library;

namespace UnitTestLibrary
{
    public class CalculationsTests
    {
        [Fact]
        public void GetAvailablePeriods_WorkingTImeFrom8To18With30MinutesConsulationTime_ShouldReturn14Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(10), TimeSpan.FromHours(11), TimeSpan.FromHours(15), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = { 60, 30, 10, 10, 40 };
            var test = Calculations.AvailablePeriods(startTimes, durations,TimeSpan.FromHours(8), TimeSpan.FromHours(18),30);
            Assert.Equal(14, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTImeFrom8TO18With20MinutesConsulationTime_ShouldReturn21Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(10), TimeSpan.FromHours(11), TimeSpan.FromHours(15), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = { 60, 30, 10, 10, 40 };
            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 20);
            Assert.Equal(21, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTImeFrom8TO18With40MinutesConsulationTime_ShouldReturn7Periods()
        {
            TimeSpan[] startTimes = { TimeSpan.FromHours(9), TimeSpan.FromHours(10.5), TimeSpan.FromHours(12), new TimeSpan(15, 30, 0), new TimeSpan(17, 0, 0) };
            int[] durations = { 60, 60, 20, 10, 30 };
            var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 40);
            Assert.Equal(7, test.Length);
        }

        [Fact]
        public void GetAvailablePeriods_WorkingTImeFrom8TO9With90MinutesConsulationTime_ShouldReturn0Periods()
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
    }
}