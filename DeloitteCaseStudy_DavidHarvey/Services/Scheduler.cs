using System;
using System.Collections.Generic;

namespace DeloitteCaseStudy_DavidHarvey
{
    public class Scheduler : IScheduler
    {
        public IEnumerable<string> Run(IProvider provider, IOrganiser organiser, ISettings settings)
        {
            if (provider == null) throw new Exception("A provider must be provided.");
            if (organiser == null) throw new Exception("A organiser must be provided.");
            if (settings == null) throw new Exception("The settings must be provided.");

            var data = provider.Data();
            
            organiser.Grouping = settings.Groups;
            organiser.Schedules = settings.ScheduleParsed;
            organiser.Activities = organiser.Parse(data, settings);

            var results = organiser.Organise();

            return results;
        }
    }
}
