using System;
using System.Collections.Generic;
using System.IO;

namespace DeloitteCaseStudy_DavidHarvey
{
    /// <summary>
    /// File provider used to return data from text files
    /// </summary>
    public class FileProvider : IFileProvider
    {
        #region Properties
        public string FileLocation { get; set; }

        #endregion

        #region Methods


        public IEnumerable<string> Data()
        {
            ValidateFile();

            return File.ReadAllLines(FileLocation);
        }

        /// <summary>
        /// Validates file exists
        /// </summary>
        /// <param name="file"></param>
        public void ValidateFile()
        {
            if (string.IsNullOrEmpty(FileLocation)) { throw new Exception("Full path to file must be provided."); }
            if (!File.Exists(FileLocation)) { throw new Exception("File does not exist, please verify file exists"); }            
        }

        #endregion
    }
}
