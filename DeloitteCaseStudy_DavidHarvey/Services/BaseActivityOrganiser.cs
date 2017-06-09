using System;
using System.Collections.Generic;
using System.Linq;

namespace DeloitteCaseStudy_DavidHarvey
{
    public abstract class BaseActivityOrganiser : IOrganiser
    {
        #region Constants
        private const string STAFF_MOTIVATION_NAME = "Staff Motivation Presentation";
        private const int TIME_ALLOCATED_FOR_STAFF_MOTIVATION_PRESENTATION = 15;
        #endregion

        #region Properties

        /// <summary>
        /// Grouping default to two groups
        /// </summary>
        public int Grouping { get; set; } = 0;

        /// <summary>
        /// Activities to be organised
        /// </summary>
        public IEnumerable<IBaseActivity> Activities { get; set; } = null;

        /// <summary>
        /// Schedules used to organise activities
        /// </summary>
        public IEnumerable<ISchedule> Schedules { get; set; } = null;

        #endregion

        #region Methods

        /// <summary>
        /// Organises activities and return them as a enumerable of strings
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> Organise()
        {
            if (Grouping == 0) throw new Exception("At least one group must be specified");
            if (!Activities.Any()) throw new Exception("No data has been provided to organise");
            if (!Schedules.Any()) throw new Exception("No schedule has been provided");

            var results = new List<string>();

            for (int i = 1; i <= Grouping; i++)
            {
                results.Add("");
                results.Add($"Team {i}:");
                results.Add("");

                foreach (var schedule in Schedules)
                {
                    var start = DateTime.Today.AddHours(schedule.StartTime);
                    var end = DateTime.Today.AddHours(schedule.EndTime);

                    var activityTime = start;
                    var availableMinutes = end.Subtract(start).TotalMinutes;
                    var minutesUsed = 0;
                    var isLastSchedule = Schedules.Last().Equals(schedule);

                    while (Activities.Any(a => !a.IsActivityAllocated))
                    {
                        var minutesLeft = availableMinutes - minutesUsed;
                        var activity = Activities.FirstOrDefault(a => !a.IsActivityAllocated && a.TimeAllocated <= minutesLeft);

                        if (activity != null)
                        {
                            results.Add($"{activityTime.ToString("HH:mm")} - {activity.Name} {activity.TimeAllocated}min");
                            minutesUsed += activity.TimeAllocated;
                            activityTime = activityTime.AddMinutes(activity.TimeAllocated);

                            activity.IsActivityAllocated = true;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (isLastSchedule)
                    {
                        results.Add($"{activityTime.ToString("HH:mm")} - {STAFF_MOTIVATION_NAME}");
                    }
                }
            }

            return results;
        }

        public abstract IEnumerable<IBaseActivity> Parse(IEnumerable<string> data, ISettings settings);

        #endregion
    }
}
