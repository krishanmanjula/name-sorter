using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NameSorter.Test
{
    [TestClass]
    public class UnitTest1
    {
        private ISortName _ISortName;

        public void SetUp()
        {
            _ISortName = new ISortName();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var Result = _ISortName.SortNamesByLastNameThenGivenName(@"C:\File\unsorted-names-list.txt", @"C:\File\sorted-names-list.txt", ".txt");
        }
    }
}
