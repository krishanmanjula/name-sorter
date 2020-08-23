using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Model
{
    public class NameModel
    {
        public NameModel(string _FirstName, string _LastName)
        {
            this.FirstName = _FirstName; this.LastName = _LastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
