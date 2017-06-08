using System;
using System.Collections.Generic;
using System.Text;

namespace DeloitteCaseStudy_DavidHarvey
{
    /// <summary>
    /// Organgises IBaseActivities based on total groups, and times
    /// </summary>
    public interface IOrganiser
    {
        /// <summary>
        /// The total amount of groups the activities are to be split among
        /// </summary>
        int Grouping { get; set; }

        /// <summary>
        /// Activities to be organised
        /// </summary>
        IEnumerable<IBaseActivity> Activities { get; set; }

        /// <summary>
        /// Organises the the activities based on the schedule, grouping and activities provided
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> Organise();

        /// <summary>
        /// Defines how the activities should be organised
        /// </summary>
        IEnumerable<ISchedule> Schedules { get; set; }

        /// <summary>
        /// Parses the data and returns IBaseActivity
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IEnumerable<IBaseActivity> Parse(IEnumerable<string> data, ISettings settings);
    }
}
