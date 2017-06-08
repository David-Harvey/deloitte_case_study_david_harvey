using System;
using System.Collections.Generic;
using System.Text;

namespace DeloitteCaseStudy_DavidHarvey
{
    public interface IFileProvider : IProvider
    {
        /// <summary>
        /// Location of the file to provide data
        /// </summary>
        string FileLocation { get; set; }
        
        /// <summary>
        /// Validates file exists
        /// </summary>
        /// <param name="file"></param>
        void ValidateFile();
    }
}
