using Microsoft.Extensions.Logging;
using NameSorter.Model;
using NameSorter.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NameSorter.Logic
{
    public class SortName : ISortName
    {
        private IFileServices _IfileServices;
        private IValidateFile _IValidateFile;
        private readonly ILogger <SortName> _ILoggerFactory;
        public SortName(IFileServices iFileServices, IValidateFile iValidateFile, ILoggerFactory iLoggerFactory)
        {
            this._IfileServices = iFileServices;
            this._IValidateFile = iValidateFile;
            _ILoggerFactory = iLoggerFactory.CreateLogger<SortName>();
        }

        /// <summary>
        /// Sorts the name of the names by last name then given.
        /// </summary>
        /// <param name="FilePath">The file path.</param>
        /// <param name="OutPutPath">The out put path.</param>
        /// <param name="FileFormat">The file format.</param>
        /// <returns></returns>
        public string SortNamesByLastNameThenGivenName(string FilePath, string OutPutPath, string FileFormat)
        {
            string Results = string.Empty;
            try
            {
                var IsValidate = _IValidateFile.ValidateFileFormat(FileFormat);
                if (IsValidate)
                {
                    var List = _IfileServices.ReadFile(FilePath);
                    var _NameModel = new List<NameModel>();
                    foreach (var item in List)
                    {
                        var FullName = item.Trim().Split(' ');
                        var LastName = FullName.LastOrDefault();
                        var FirstName = string.Join(" ", FullName.Take(FullName.Length - 1));
                        _NameModel.Add(new NameModel(FirstName, LastName));
                    }

                    var SortedName = _NameModel.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();
                    foreach (var item in SortedName)
                    {
                        Results = Results + item.FirstName.ToString() + " " + item.LastName.ToString() + Environment.NewLine;
                    }
                }
                else
                {
                    _ILoggerFactory.LogError("Invalid input format. Allow .txt files only!");
                }

                var bytes = Encoding.UTF8.GetBytes(Results);
                using (var f = File.Open(OutPutPath, FileMode.Create))
                {
                    f.Write(bytes, 0, bytes.Length);
                }
                return Results;
            }
            catch (Exception)
            {
                _ILoggerFactory.LogError("Error occured!");
                return Results = "Error occured!";

            }
        }
    }
}
