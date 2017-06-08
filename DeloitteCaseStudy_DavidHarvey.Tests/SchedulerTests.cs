using Machine.Specifications;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace DeloitteCaseStudy_DavidHarvey.Tests.SchedulerTests
{
    [Subject("Scheduler")]

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

    #region .Run Tests

    class when_I_call_Run_with_a_null_provider : Context
    {
        private static IScheduler scheduler = null;
        private static Exception result = null;

        Establish context = () =>
        {
            scheduler = new Scheduler();
        };

        Because of = () => result = Catch.Exception(() => scheduler.Run(null, organiser, settings));

        It returns_an_error_message_stating_a_provider_must_be_passed_in = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("A provider must be provided.");
        };
    }

    class when_I_call_Run_with_a_null_organiser : Context
    {
        private static IScheduler scheduler = null;
        private static Exception result = null;

        Establish context = () =>
        {
            scheduler = new Scheduler();
        };

        Because of = () => result = Catch.Exception(() => scheduler.Run(provider, null, settings));

        It returns_an_error_message_stating_a_organiser_must_be_passed_in = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("A organiser must be provided.");
        };
    }

    class when_I_call_Run_with_a_null_settings : Context
    {
        private static IScheduler scheduler = null;
        private static Exception result = null;

        Establish context = () =>
        {
            scheduler = new Scheduler();
        };

        Because of = () => result = Catch.Exception(() => scheduler.Run(provider, organiser, null));

        It returns_an_error_message_stating_the_settings_must_be_passed_in = () =>
        {
            result.ShouldNotBeNull();
            result.Message.ShouldEqual("The settings must be provided.");
        };
    }

    class when_I_call_Run : Context
    {
        private static IScheduler scheduler = null;
        private static IEnumerable<string> result = null;

        Establish context = () =>
        {
            scheduler = new Scheduler();
            organiser.Organise().Returns(new List<string>
            {
                "Something organised 1",
                "Something organised 2",
                "Something organised 3",
            });
        };

        Because of = () => result = scheduler.Run(provider, organiser, settings);

        It calls_the_provider_to_provider_data = () => provider.Received().Received().Data();
        It calls_the_organiser_to_organise_the_data = () => organiser.Received().Received().Organise();
        It returns_the_result_of_organisation = () => result.ShouldContain
        (
            "Something organised 1",
            "Something organised 2",
            "Something organised 3"
        );
    }

    #endregion
}

