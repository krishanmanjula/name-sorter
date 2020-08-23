using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public interface IValidateFile
    {
        bool ValidateFileFormat(string Type);
    }
}
