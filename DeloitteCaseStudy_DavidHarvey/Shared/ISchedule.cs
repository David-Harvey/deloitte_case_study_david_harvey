namespace DeloitteCaseStudy_DavidHarvey
{
    public interface ISchedule
    {
        /// <summary>
        /// The start time of the schedule
        /// </summary>
        int StartTime { get; set; }

        /// <summary>
        /// The end time of the schedule
        /// </summary>
        int EndTime { get; set; }
    }
}