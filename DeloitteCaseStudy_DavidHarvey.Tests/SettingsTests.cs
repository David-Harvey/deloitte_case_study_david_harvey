using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeloitteCaseStudy_DavidHarvey.Tests.SettingsTests
{
    [Subject("Settings")]

    class when_I_call_ScheduleParsed_with_a_null_schedule_settings
    {
        static ISettings settings = null;
        static Exception result = null;

        Establish context = () =>
        {
            settings = new Settings
            {
                Schedule = null
            };
        };

        Because of = () => result = Catch.Exception(() => settings.ScheduleParsed);

        It returns_an_error_message_stating_a_schedule_must_be_provided = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("A schedule must be provided.");
        };
    }

    class when_I_call_ScheduleParsed_with_an_empty_schedule_settings
    {
        static ISettings settings = null;
        static Exception result = null;

        Establish context = () =>
        {
            settings = new Settings
            {
                Schedule = ""
            };
        };

        Because of = () => result = Catch.Exception(() => settings.ScheduleParsed);

        It returns_an_error_message_stating_a_schedule_must_be_provided = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("A schedule must be provided.");
        };
    }

    class when_I_call_ScheduleParsed_with_a_valid_single_schedule
    {
        static ISettings settings = null;
        static IEnumerable<ISchedule> result = null;

        Establish context = () =>
        {
            settings = new Settings
            {
                Schedule = "9,12"
            };
        };

        Because of = () => result = settings.ScheduleParsed;

        It should_return_a_schedule_between_9am_and_12pm = () =>
        {
            result.Any(s => s.StartTime == 9 && s.EndTime == 12).ShouldBeTrue();
        };
    }

    class when_I_call_ScheduleParsed_with_valid_multiple_schedules
    {
        static ISettings settings = null;
        static IEnumerable<ISchedule> result = null;

        Establish context = () =>
        {
            settings = new Settings
            {
                Schedule = "9,12,13,17"
            };
        };

        Because of = () => result = settings.ScheduleParsed;

        It should_return_a_schedule_between_9am_and_12pm = () =>
        {
            result.Any(s => s.StartTime == 9 && s.EndTime == 12).ShouldBeTrue();
        };

        It should_return_a_schedule_between_1pm_and_5pm = () =>
        {
            result.Any(s => s.StartTime == 13 && s.EndTime == 17).ShouldBeTrue();
        };
    }
}