using System;
using System.Collections.Generic;
using System.Text;

namespace DeloitteCaseStudy_DavidHarvey
{
    public interface IBaseActivity
    {
        /// <summary>
        /// Name of base activity
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Time allocated to activity in minutes
        /// </summary>
        int TimeAllocated { get; set; }

        /// <summary>
        /// A flag to determine if the activity has been allocated to a schedule
        /// </summary>
        bool IsActivityAllocated { get; set; }
    }
}
