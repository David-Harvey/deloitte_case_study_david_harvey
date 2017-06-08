using System;
using System.Collections.Generic;

namespace DeloitteCaseStudy_DavidHarvey
{
    public class Settings : ISettings
    {
        public Settings()
        {
            // Default settings, this could be extended to read from a config file.
            Groups = 2;
            Schedule = "9,12,1,5";
            RegEx = @"((.*)(\d.)(?=min))?.*";
        }

        #region Properties

        public int Groups { get; set; }
        public string Schedule { get; set; }
        public string RegEx { get; set; }
        public IEnumerable<ISchedule> ScheduleParsed
        {
            get
            {
                if (string.IsNullOrEmpty(Schedule)) throw new Exception("A schedule must be provided.");

                var times = Schedule.Trim().Split(',');

                IList<ISchedule> schedule = new List<ISchedule>();

                int? start = null;
                int? end = null;

                foreach (var time in times)
                {
                    if (start == null) { start = int.Parse(time); continue; }
                    if (end == null) { end = int.Parse(time); }

                    schedule.Add(new Schedule { StartTime = start.Value, EndTime = end.Value });

                    start = null;
                    end = null;
                }

                return schedule;
            }
        }

        #endregion

    }
}
