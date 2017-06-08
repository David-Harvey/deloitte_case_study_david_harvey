namespace DeloitteCaseStudy_DavidHarvey
{
    public abstract class BaseActivity : IBaseActivity
    {
        #region Properties

        /// <summary>
        /// Name of the activity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The time allocated for the activity in minutes
        /// </summary>
        public int TimeAllocated { get; set; }

        /// <summary>
        /// A flag to determine if the activity has been allocated to a schedule
        /// </summary>
        public bool IsActivityAllocated { get; set; }

        #endregion
    }
}
