using System.IO;
using System.Runtime.CompilerServices;
using WeekFourAssignmentStructedText.Engines;
using WeekFourAssignmentStructedText.Interfaces;

namespace WeekFourAssignmentStructedText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define an array to store file paths and a list to store IParsable objects.
            string[] filePaths;
            List<IPassing> toParse = new List<IPassing>();

            string path = Environment.CurrentDirectory + @"\Files";

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Folder does not exist.");
            }
            else
            {
                // Get an array of file paths in the specified folder.
                filePaths = Directory.GetFiles(path);

                // Iterate through the file paths and create TextFileObject instances for parsing.
                foreach (string filePath in filePaths)
                {
                    toParse.Add(new TheFiles(filePath));
                }

                // Start the parsing process using the ParserEngine class.
                EngineParsing.BeginParse(toParse);
            }
        }
    }
}