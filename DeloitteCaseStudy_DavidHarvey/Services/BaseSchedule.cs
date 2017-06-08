namespace DeloitteCaseStudy_DavidHarvey
{
    public abstract class BaseSchedule : ISchedule
    {
        #region Properties

        /// <summary>
        /// The start time of the schedule
        /// </summary>
        public int StartTime { get; set; }

        /// <summary>
        /// The end time of the schedule
        /// </summary>
        public int EndTime { get; set; }

        #endregion
    }
}
