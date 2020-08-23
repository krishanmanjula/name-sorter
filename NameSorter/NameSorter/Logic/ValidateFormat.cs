using NameSorter.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Logic
{
    public class ValidateTxtFileFormat : IValidateFile
    {
        /// <summary>
        /// Validates the file format.
        /// </summary>
        /// <param name="Type">File type ex: .txt, .xml.</param>
        /// <returns>Return True if file type is .txt else return false</returns>
        public bool ValidateFileFormat(string Type)
        {
            if (Type == ".txt")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Validates the file format.
    /// </summary>
    /// <param name="Type">File type ex: .txt, .xml.</param>
    /// <returns>Return True if file type is .xml else return false</returns>
    public class ValidateXmlFileFormat : IValidateFile
    {
        public bool ValidateFileFormat(string Type)
        {
            if (Type == ".xml")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
