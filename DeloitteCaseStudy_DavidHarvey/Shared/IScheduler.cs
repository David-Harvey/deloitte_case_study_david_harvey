using System.Collections.Generic;

namespace DeloitteCaseStudy_DavidHarvey
{
    public interface IScheduler 
    {
        /// <summary>
        /// Creates a schedule
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> Run(IProvider provider, IOrganiser organiser, ISettings settings);
    }
}
