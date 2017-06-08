using System.Collections.Generic;


namespace DeloitteCaseStudy_DavidHarvey
{
    public interface IProvider
    {
        /// <summary>
        /// Provides data as an enumerable of string
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> Data();
    }
}
