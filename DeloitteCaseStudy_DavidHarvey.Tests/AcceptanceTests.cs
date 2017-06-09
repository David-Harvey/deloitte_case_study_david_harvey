using System;
using System.Collections.Generic;
using Machine.Specifications;
using NSubstitute;
using System.Linq;

namespace DeloitteCaseStudy_DavidHarvey.Tests.AcceptanceTests
{
    [Subject("Acceptance tests")]
    class Context
    {
        public static IProvider provider = null;
        public static IOrganiser organiser = null;
        public static ISettings settings = null;
        public static IScheduler scheduler = null;
        public static IEnumerable<string> results = null;

        Establish context = () =>
        {
            provider = new FakeProvider();
            scheduler = new Scheduler();
            organiser = new ActivityOrganiser();
            settings = new Settings();
        };

        Because of = () => results = scheduler.Run(provider, organiser, settings);

        It should_contain_enough_information_for_activities_teams_and_presentations = () =>
        {
            // 20 activities
            // 2 Teams, 2 new lines for each time
            // 2 Staff presentations

            results.Count().ShouldEqual(28);
        };

        It should_two_counts_of_staff_presentations = () =>
        {
            results.Count(r => r.Contains("Staff Motivation Presentation")).ShouldEqual(2);
        };
    }

    #region Fakes

    public class FakeProvider : IProvider
    {
        public IEnumerable<string> Data()
        {
            return new List<string>()
            {
                "Duck Herding 60min",
                "Archery 45min",
                "Learning Magic Tricks 40min",
                "Laser Clay Shooting 60min",
                "Human Table Football 30min",
                "Buggy Driving 30min",
                "Salsa & Pickles sprint",
                "2-wheeled Segways 45min",
                "Viking Axe Throwing 60min",
                "Giant Puzzle Dinosaurs 30min",
                "Giant Digital Graffiti 60min",
                "Cricket 2020 60min",
                "Wine Tasting sprint",
                "Arduino Bonanza 30min",
                "Digital Tresure Hunt 60min",
                "Enigma Challenge 45min",
                "Monti Carlo or Bust 60min",
                "New Zealand Haka 30min",
                "Time Tracker sprint",
                "Indiano Drizzle 45min"
            };
        }
    }

    #endregion  
}
