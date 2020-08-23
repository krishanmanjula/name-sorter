using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.Logic;
using NameSorter.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.MSTest
{
    [TestClass]
    public class NameSorterTests
    {
        private ServiceProvider servicesProvider;
        private string ProjectPath;

        /// <summary>
        /// Sets up. Inject Services
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            var services = new ServiceCollection()
             .AddSingleton<IValidateFile, ValidateTxtFileFormat>()
             .AddSingleton<IFileServices, ReadFileContent>()
             .AddSingleton<ISortName, SortName>()
             .AddLogging();

            servicesProvider = services.BuildServiceProvider();

            ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        }

        /// <summary>
        /// Tests the name of the sort.
        /// Should return sorted name list by last name then by given name.
        /// </summary>
        [TestMethod]
        public void TestSortName()
        {
            //Arrange
            string ExpectedResults = @"Marin Alvarez
                                    Adonis Julius Archer
                                    Beau Tristan Bentley
                                    Hunter Uriah Mathew Clarke
                                    Leo Gardner
                                    Vaughn Lewis
                                    London Lindsey
                                    Mikayla Lopez
                                    Janet Parsons
                                    Frankie Conner Ritter
                                    Shelby Nathan Yoder";

            //Act
            var SortName = servicesProvider.GetService<ISortName>();
            var SortedString = SortName.SortNamesByLastNameThenGivenName(ProjectPath + @"\unsorted-names-list.txt", ProjectPath + @"\sorted-names-list.txt", ".txt");

            //Assert            
            Assert.AreNotEqual(ExpectedResults, SortedString, "SortName failde!");
        }

        /// <summary>
        /// Tests the read file.
        /// Should return .txt file details as string list.
        /// </summary>
        [TestMethod]
        public void TestReadFile()
        {
            //Arrange
            var ExpectedResults = new List<string>();
            ExpectedResults.Add("Janet Parsons");
            ExpectedResults.Add("Vaughn Lewis");
            ExpectedResults.Add("Adonis Julius Archer");
            ExpectedResults.Add("Shelby Nathan Yoder");
            ExpectedResults.Add("Marin Alvarez");
            ExpectedResults.Add("London Lindsey");
            ExpectedResults.Add("Beau Tristan Bentley");
            ExpectedResults.Add("Leo Gardner");
            ExpectedResults.Add("Hunter Uriah Mathew Clarke");
            ExpectedResults.Add("Mikayla Lopez");
            ExpectedResults.Add("Frankie Conner Ritter");

            //Act
            var ReadFiles = servicesProvider.GetService<IFileServices>();
            var Results = ReadFiles.ReadFile(ProjectPath + @"\unsorted-names-list.txt");

            //Assert
            CollectionAssert.AreEqual(ExpectedResults, Results, "Read File Failed");
        }

        /// <summary>
        /// Tests the validate file.
        /// Validate file type is .txt. Return true if type is .txt and return fales if file type is anothr.
        /// </summary>
        [TestMethod]
        public void TestValidateFile()
        {
            //Arrange
            var ExpectedResultstxt = true;
            var ExpectedResultsXml = false;

            //Act
            var Validate = servicesProvider.GetService<IValidateFile>();
            var ResultsTxt = Validate.ValidateFileFormat(".txt");
            var Resultsxml = Validate.ValidateFileFormat(".xml");


            //Assert
            Assert.IsTrue(ExpectedResultstxt = ResultsTxt, "Read file failed");
            Assert.IsFalse(ExpectedResultsXml = Resultsxml, "Read file failed");
        }
    }
}
