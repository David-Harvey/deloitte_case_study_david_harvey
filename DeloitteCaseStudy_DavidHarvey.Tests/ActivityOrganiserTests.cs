using Machine.Specifications;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeloitteCaseStudy_DavidHarvey.Tests.ActivityOrganiserTests
{
    [Subject("ActivityOrganiser")]

    class Context
    {
        public static IProvider provider = null;
        public static IOrganiser organiser = null;
        public static ISettings settings = null;

        Establish context = () =>
        {
            provider = Substitute.For<IProvider>();
            organiser = Substitute.For<IOrganiser>();
            settings = Substitute.For<ISettings>();
        };
    }

    #region .Organise() Tests

    class when_I_call_Organise_with_grouping_set_to_zero
    {
        private static ActivityOrganiser organiser = null;
        private static Exception result = null;

        Establish context = () =>
        {
            organiser = new ActivityOrganiser
            {
                Grouping = 0
            };
        };

        Because of = () => result = Catch.Exception(() => organiser.Organise());

        It should_return_an_exception_stating_atleast_one_group_must_be_specified = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("At least one group must be specified");
        };
    }

    class when_I_call_Organise_with_no_data
    {
        private static ActivityOrganiser organiser = null;
        private static Exception result = null;

        Establish context = () =>
        {
            organiser = new ActivityOrganiser
            {
                Grouping = 1,
                Activities = new List<IBaseActivity>()
            };
        };

        Because of = () => result = Catch.Exception(() => organiser.Organise());

        It should_return_an_exception_stating_no_data_has_been_provided = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("No data has been provided to organise");
        };
    }

    class when_I_call_Organise_with_no_schedule
    {
        private static ActivityOrganiser organiser = null;
        private static Exception result = null;

        Establish context = () =>
        {
            organiser = new ActivityOrganiser
            {
                Grouping = 1,
                Activities = new List<IBaseActivity>()
                {
                    new FakeActivity { Name = "A fake activity", TimeAllocated = 1 }
                },
                Schedules = new List<ISchedule>()
            };
        };

        Because of = () => result = Catch.Exception(() => organiser.Organise());

        It should_return_an_exception_stating_no_data_has_been_provided = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("No schedule has been provided");
        };
    }

    class when_I_call_Organise_with_one_group_and_one_schedule_and_some_activities
    {
        private static IEnumerable<string> results = null;
        private static IActivityOrganiser organiser = null;
        private static ISchedule schedule = null;
        private static int grouping = 1;

        Establish context = () =>
        {
            schedule = new FakeSchedule
            {
                StartTime = 9,
                EndTime = 12
            };

            organiser = new ActivityOrganiser
            {
                Activities = new List<IActivity>
                {
                    new FakeActivity { Name = "Fake activity 1", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 2", TimeAllocated = 30 },
                    new FakeActivity { Name = "Fake activity 3", TimeAllocated = 45 }
                },
                Grouping = grouping,
                Schedules = new List<ISchedule>
                {
                    schedule
                }
            };
        };

        Because of = () => results = organiser.Organise();

        It should_not_return_null = () => results.ShouldNotBeNull();

        It should_schedule_activties_by_setting_their_appropriate_start_times = () => results.ShouldContainOnly
        (
            "",
            "Team 1:",
            "",
            "09:00 - Fake activity 1 60min",
            "10:00 - Fake activity 2 30min",
            "10:30 - Fake activity 3 45min",
            "11:15 - Staff Motivation Presentation"
        );
    }

    class when_I_call_Organise_with_one_group_and_two_schedules_and_some_activities
    {
        private static IEnumerable<string> results = null;
        private static IActivityOrganiser organiser = null;
        private static IEnumerable<ISchedule> schedules = null;
        private static int grouping = 1;

        Establish context = () =>
        {
            schedules = new List<ISchedule>
            {
                new FakeSchedule
                {
                    StartTime = 9,
                    EndTime = 12
                },
                new FakeSchedule
                {
                    StartTime = 13,
                    EndTime = 17
                }
            };

            organiser = new ActivityOrganiser
            {
                Activities = new List<IActivity>
                {
                    new FakeActivity { Name = "Fake activity 1", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 2", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 3", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 4", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 5", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 6", TimeAllocated = 60 },
                },
                Grouping = grouping,
                Schedules = schedules
            };
        };

        Because of = () => results = organiser.Organise();

        It should_not_return_null = () => results.ShouldNotBeNull();

        It should_add_the_activities_splitting_by_schedules = () => results.ShouldContainOnly
        (
            "",
            "Team 1:",
            "",
            "09:00 - Fake activity 1 60min",
            "10:00 - Fake activity 2 60min",
            "11:00 - Fake activity 3 60min",
            "13:00 - Fake activity 4 60min",
            "14:00 - Fake activity 5 60min",
            "15:00 - Fake activity 6 60min",
            "16:00 - Staff Motivation Presentation"
        );
    }

    class when_I_call_Organise_with_two_groups_two_schedules_and_some_activities
    {
        private static IEnumerable<string> results = null;
        private static IActivityOrganiser organiser = null;
        private static IEnumerable<ISchedule> schedules = null;
        private static int grouping = 2;

        Establish context = () =>
        {
            schedules = new List<ISchedule>
            {
                new FakeSchedule
                {
                    StartTime = 9,
                    EndTime = 12
                },
                new FakeSchedule
                {
                    StartTime = 13,
                    EndTime = 17
                }
            };

            organiser = new ActivityOrganiser
            {
                Activities = new List<IActivity>
                {
                    new FakeActivity { Name = "Fake activity 1", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 2", TimeAllocated = 45 },
                    new FakeActivity { Name = "Fake activity 3", TimeAllocated = 30 },
                    new FakeActivity { Name = "Fake activity 4", TimeAllocated = 40 },
                    new FakeActivity { Name = "Fake activity 5", TimeAllocated = 50 },
                    new FakeActivity { Name = "Fake activity 6", TimeAllocated = 45 },
                    new FakeActivity { Name = "Fake activity 7", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 8", TimeAllocated = 60 },
                    new FakeActivity { Name = "Fake activity 9", TimeAllocated = 50 },
                    new FakeActivity { Name = "Fake activity 10", TimeAllocated = 55 },
                    new FakeActivity { Name = "Fake activity 11", TimeAllocated = 40 },
                    new FakeActivity { Name = "Fake activity 12", TimeAllocated = 45 },
                },
                Grouping = grouping,
                Schedules = schedules
            };
        };

        Because of = () => results = organiser.Organise();

        It should_not_return_null = () => results.ShouldNotBeNull();

        It should_add_multiple_teams = () => results.ShouldContainOnly
        (
            "",
            "Team 1:",
            "",
            "09:00 - Fake activity 1 60min",
            "10:00 - Fake activity 2 45min",
            "10:45 - Fake activity 3 30min",
            "11:15 - Fake activity 4 40min",
            "13:00 - Fake activity 5 50min",
            "13:50 - Fake activity 6 45min",
            "14:35 - Fake activity 7 60min",
            "15:35 - Fake activity 8 60min",
            "16:35 - Staff Motivation Presentation",
            "",
            "Team 2:",
            "",
            "09:00 - Fake activity 9 50min",
            "09:50 - Fake activity 10 55min",
            "10:45 - Fake activity 11 40min",
            "13:00 - Fake activity 12 45min",
            "13:45 - Staff Motivation Presentation"
        );
    }


    #endregion

    #region .Parse(IEnumerable<string> data) Tests

    class when_I_call_Parse_with_a_null_collection : Context
    {
        private static new ActivityOrganiser organiser = null;
        private static Exception result = null;

        Establish context = () =>
        {
            organiser = new ActivityOrganiser();
        };

        Because of = () => result = Catch.Exception(() => organiser.Parse(null, settings));

        It should_return_an_exception_stating_data_must_be_provided = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("Data must be provided to be parsed");
        };
    }

    class when_I_call_Parse_with_an_empty_collection : Context
    {
        private static new ActivityOrganiser organiser = null;
        private static Exception result = null;

        Establish context = () =>
        {
            organiser = new ActivityOrganiser();
        };

        Because of = () => result = Catch.Exception(() => organiser.Parse(null, settings));

        It should_return_an_exception_stating_data_must_be_provided = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("Data must be provided to be parsed");
        };
    }

    class when_I_call_Parse_with_a_valid_list_of_activities_which_matches_the_regex : Context
    {
        private static new ActivityOrganiser organiser = null;
        private static IEnumerable<IBaseActivity> results = null;

        Establish context = () =>
        {
            organiser = new ActivityOrganiser();
            settings = new Settings
            {
                RegEx = @"((.*)(\d.)(?=min))?.*"
            };
        };

        Because of = () => results = organiser.Parse
        (
            new[] { "Duck Herding 60min", "Buggy Driving 30min", "Salsa & Pickles sprint" },
            settings
        );

        It should_return_three_activities_and_the_time_allocated = () =>
        {
            results.Any(a => a.Name == "Duck Herding" && a.TimeAllocated == 60).ShouldBeTrue();
            results.Any(a => a.Name == "Buggy Driving" && a.TimeAllocated == 30).ShouldBeTrue();
            results.Any(a => a.Name == "Salsa & Pickles sprint").ShouldBeTrue();
        };

        It should_allocate_15_minutes_to_any_activity_which_does_not_have_a_time_specified = () =>
        {
            results.Any(a => a.Name == "Salsa & Pickles sprint" && a.TimeAllocated == 15).ShouldBeTrue();
        };
    }

    #endregion

    #region Fakes

    public class FakeSchedule : ISchedule
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }

    public class FakeActivity : IActivity
    {
        public string Name { get; set; }
        public int TimeAllocated { get; set; }
        public bool IsActivityAllocated { get; set; }
    }

    #endregion
}
