using System.Collections.Generic;

namespace DeloitteCaseStudy_DavidHarvey
{
    public interface ISettings
    {
        /// <summary>
        /// The total amount of groups the data must be split amongst
        /// </summary>
        int Groups { get; set; }
        
        /// <summary>
        /// A comma seperated list, paired in twos to describe the schedule required
        /// e.g. 9,12,1,5 (First schedule is from 9 until 1, and the second is from 1 until 5
        /// </summary>
        string Schedule { get; set; }

        /// <summary>
        /// Reg ex used to parse data
        /// </summary>
        string RegEx { get; set; }

        /// <summary>
        /// Parses the Schedule set and returns a collection of ISchedules
        /// </summary>
        IEnumerable<ISchedule> ScheduleParsed { get; }
    }
}
