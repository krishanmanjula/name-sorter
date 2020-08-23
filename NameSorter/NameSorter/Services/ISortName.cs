using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public interface ISortName
    {
        string SortNamesByLastNameThenGivenName(string FilePath,string OutPutPath, string FileFormat);
    }
}
