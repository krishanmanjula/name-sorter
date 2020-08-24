# Name Sorter
Sort the person name by last name the given name.

## Getting Started
Download the project and open with supported visual studio version (ex: 2015/2017/2019). Then debug the project. You will see the out put results on console log

In the project, reading file is inside the RootFolder\Files\unsorted-names-list.txt.
If you need to replace the file, please change the file under RootFolder\Files\unsorted-names-list.txt and rebuild the solution and run the project. 
After you rebuild, it will generate the unsorted-names-list.txt file under 
~\NameSorter\bin\Debug\netcoreapp2.1\Files\unsorted-names-list.txt

after successfully run the output sorted-names-list.txt file will be generate under 
~\NameSorter\bin\Debug\netcoreapp2.1\Files\sorted-names-list.txt

### or 

you can have your own folder and change the path inside the Program.cs
  #### string UnsortedNamesPath = <Your own path>\unsorted-names-list.txt";
  #### string SortedNamesPath = <Your own path>\sorted-names-list.txt";
            
## Description
This solution will read .txt file and order that set first by last name, then by any given names the 
person may have. A name must have at least 1 given name and may have up to 3 given names.


### Input 
Janet Parsons
Vaughn Lewis
Adonis Julius Archer
Shelby Nathan Yoder
Marin Alvarez
London Lindsey
Beau Tristan Bentley
Hunter Uriah Mathew Clarke
Mikayla Lopez
Frankie Conner Ritter

### Output
Marin Alvarez
Adonis Julius Archer
Beau Tristan Bentley
Hunter Uriah Mathew Clarke
Vaughn Lewis
London Lindsey
Mikayla Lopez
Janet Parsons
Frankie Conner Ritter 
Shelby Nathan Yoder

## Running the tests
You will download the test project with this solution. There are three unit test cases that you can verify the methods.
EX: 
1.TestValidateFile
In this test it will validate input type is .txt

2.TestReadFile
In this test will make sure file can be read.

3.TestSortName
In this test case make sure given names are sorted by last name and then by given name




