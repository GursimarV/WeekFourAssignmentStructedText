using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.DifferentFileTypes;
using WeekFourAssignmentStructedText.Interfaces;
using WeekFourAssignmentStructedText.Parsers;

namespace WeekFourAssignmentStructedText
{
    //Help from Leo's InClassDemo with reminding to make this an abstract class since the abstract class can be used by other classes like JSONFileParse and XMLFileParse
    internal abstract class EngineParsing
    {
        
        // This begins parsing the files from the list from Program class and Parses each file
        public static void BeginParse(List<IPassing> fileCollection)
        {
            foreach (var file in fileCollection)
            {
                GoParsing(file);
            }
        }

        // This method checks the files if it is a TextFileObject and if so will do to the ReadFile to read the file
        private static void GoParsing(IPassing file)
        {
            if (file is TheFiles)
            {
                ReadFile((TheFiles)file);
            }
            else
            {
                // If it is not apart of the TextFileObject, it will ask for a different parser for the file 
                Console.WriteLine("You need a different parser for this file");
            }
        }
        
        // This method reads the text in the files and will make each line go through the delimiter and writeout the text without the things in the delimiter
        public static void ReadFile(TheFiles outputFile)
        {
            // Lines getting added to the list to be parsed
            List<string[]> LineAdd = new List<string[]>();
            string[] values;

            // Streamreader reads the file from the file path one line at a time, Credit to Assignment #3 that helped remember about streamreader
            using (StreamReader sourceRead = new StreamReader(outputFile.Path))
            {
                // Reads lines from the source file as a string
                string? outputline = sourceRead.ReadLine();

                while (outputline != null)
                {
                    values = outputline.Split(outputFile.Delimiter);
                    LineAdd.Add(values);
                    outputline = sourceRead.ReadLine();
                }
            }

            // The new lines from that were added after being delimited will go to the WriteFile method to be written into a new file
            WriteFile(outputFile.Path, LineAdd);
        }

        // This method writes the parsed data that is delimited into a new file
        public static void WriteFile(string path, List<string[]> items)
        {

            // Creates a new file to output the parsing results, Learned from: https://stackoverflow.com/questions/5127150/how-can-i-get-a-substring-from-a-file-path-in-c
            string results = path.Substring(path.LastIndexOf('\\') + 1);
            results = results.Insert(results.LastIndexOf('.'), "_out");
            results = results.Replace(results.Substring(results.LastIndexOf('.')), ".txt");

            // Creates a new File path for the result files, Learned from: https://stackoverflow.com/questions/24925152/taking-the-last-substring-of-a-string-in-c-sharp
            string newPath = path.Substring(0, path.LastIndexOf('\\') + 1) + "\\" + results;

            // Use FileStream to create a new File Path for the output files to go to, Credit to: https://learn.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-7.0 for helping me with the new file path
            using (FileStream filesource = File.Create(newPath))
            {
                // Use StreamWriter to write the information to the new files, Credit to Assignment #3 that helped remember about streamwriter
                using (StreamWriter sourceWrite = new StreamWriter(filesource))
                {
                    // Credit to Leo's In Class Demo which helped me with the for(int x = 0; x < items.Count; x++) and for (int i = 0; i < items[x].Length; i++)
                    for (int x = 0; x < items.Count; x++)
                    {
                        sourceWrite.Write($"Line #{x + 1} :");
                        for (int i = 0; i < items[x].Length; i++)
                        {
                            sourceWrite.Write($"Field #{i + 1}={items[x][i]} ");
                            if (i != items[x].Length - 1)
                            {
                                sourceWrite.Write("==> ");
                            }
                        }
                        sourceWrite.WriteLine("\n");
                    }
                    
                }
            }
        }
        
    }
}
