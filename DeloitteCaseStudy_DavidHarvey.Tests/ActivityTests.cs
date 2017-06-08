using Machine.Specifications;

namespace DeloitteCaseStudy_DavidHarvey.Tests.ActivityTests
{
    [Subject("Activity")]

    #region .ToString Tests

    class when_I_call_ToString
    {
        private static Activity activity = null;
        private static string result = null;

        Establish context = () => 
        {
            activity = new Activity
            {
                Name = "Activity name",
                TimeAllocated = 60
            };
        };

        Because of = () => result = activity.ToString();

        It should_return_the_activity_name_and_time_allocated = () => result.ShouldEqual("Activity name: Activity name - Mins: 60");       
    }

    #endregion
}
