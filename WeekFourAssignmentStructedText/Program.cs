/*
 Made by: Gursimar Virdi
 Date: 10/9/2023
 */
using System.IO;
using System.Runtime.CompilerServices;
using WeekFourAssignmentStructedText.DifferentFileTypes;
using WeekFourAssignmentStructedText.Engines;
using WeekFourAssignmentStructedText.Interfaces;

namespace WeekFourAssignmentStructedText
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Creates an array that holds the different file types and creates a list to store the objects of the file into IPassing
            string[] filePaths;
            List<IPassing> goParsing = new List<IPassing>();
            // The directory path to the files, learned from Assignment #3
            string directory = "Files";
            string path = Path.Combine(Directory.GetCurrentDirectory(), directory);

            // This is error check to make sure Folder exists and if it doesn't it will read this, learned from: https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.exists?view=net-7.0 for directory.exists
            if (!Directory.Exists(path))
            {
                ErrorChecking.Instance.ShowError("The folder in the specific path doesn't exist!");
            }
            // This when the file is there and will read the files
            else
            {
                // Creats a lists the different file paths that is in specific folder
                filePaths = Directory.GetFiles(path);

                // Goes through the files and creates instances of the files to be parsed in the EngineParsing class
                foreach (string filePath in filePaths)
                {
                    // Adds the file to the list that will be parsed
                    goParsing.Add(new TheFiles(filePath));
                }
                
                // Begins parsing the files in the EngineParsing class
                ParsesFiles.BeginParse(goParsing);

                ErrorChecking.Instance.StreamError(path);
            }
        }
    }
}