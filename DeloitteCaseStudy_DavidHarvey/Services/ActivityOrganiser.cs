using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DeloitteCaseStudy_DavidHarvey
{
    public class ActivityOrganiser : BaseActivityOrganiser, IActivityOrganiser
    {
        #region Constants

        private const int GROUP_FULL_INDEX = 0;
        private const int GROUP_NAME_INDEX = 2;
        private const int GROUP_TIME_INDEX = 3;

        #endregion

        public override IEnumerable<IBaseActivity> Parse(IEnumerable<string> data, ISettings settings)
        {
            if (data == null) throw new Exception("Data must be provided to be parsed");
            if (data.Count() == 0) throw new Exception("Data must be provided to be parsed");

            var activities = new List<IActivity>();

            foreach (var activity in data)
            {
                var match = Regex.Match(activity.Trim(), settings.RegEx);

                var isNamePresentInIndependantCaptureGroups = match.Groups.Count >= GROUP_NAME_INDEX && !string.IsNullOrEmpty(match.Groups[GROUP_NAME_INDEX].Value);
                var isTimePresent = match.Groups.Count >= GROUP_TIME_INDEX && !string.IsNullOrEmpty(match.Groups[GROUP_TIME_INDEX].Value);

                activities.Add(new Activity
                {
                    Name = isNamePresentInIndependantCaptureGroups ? match.Groups[GROUP_NAME_INDEX].Value.Trim() : match.Groups[GROUP_FULL_INDEX].Value.Trim(),
                    TimeAllocated = isTimePresent ? int.Parse(match.Groups[GROUP_TIME_INDEX].Value) : 15
                });
            }

            return activities;
        }
    }
}
