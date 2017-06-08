namespace DeloitteCaseStudy_DavidHarvey
{
    public class Activity: BaseActivity, IActivity
    {
        #region Methods

        public override string ToString()
        {
            return $"Activity name: {Name} - Mins: {TimeAllocated}";
        }

        #endregion
    }
}
