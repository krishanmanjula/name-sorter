using Microsoft.Extensions.Logging;
using NameSorter.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NameSorter.Logic
{
    public class ReadFileContent : IFileServices
    {

        private readonly ILogger<ReadFileContent> _ILoggerFactory;
        public ReadFileContent(ILoggerFactory iLoggerFactory)
        {
            _ILoggerFactory = iLoggerFactory.CreateLogger<ReadFileContent>();
        }

        /// <summary>
        /// Reads the file and return string list.
        /// </summary>
        /// <param name="FilePath">The file path.</param>
        /// <returns></returns>
        public List<string> ReadFile(string FilePath)
        {
            var NameList = new List<string>();
            try
            {
                NameList = new List<string>(File.ReadAllLines(FilePath));
            }
            catch (Exception ex)
            {
                _ILoggerFactory.LogError("Error on readFile " + ex.Message);
            }
            return NameList;
        }
    }
}
