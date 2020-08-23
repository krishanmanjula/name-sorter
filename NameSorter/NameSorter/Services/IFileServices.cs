using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public interface IFileServices
    {
        List<string> ReadFile(string FilePath);
    }
}
