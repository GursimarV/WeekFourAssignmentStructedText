using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.DifferentFileTypes;
using WeekFourAssignmentStructedText.Engines;
using WeekFourAssignmentStructedText.Interfaces;

namespace WeekFourAssignmentStructedText
{
    internal class ParsesFiles
    {
        public static IPassing CreateFileType(string Path, FileType fileType)
        {
            string extension = Path.Substring(Path.LastIndexOf('.') + 1);
            switch (extension)
            {
                // The different files and returns the FileType, learned from Leo's InClassDemo
                case "csv":
                    return new TheFiles(Path);

                case "txt":
                    return new TheFiles(Path);

                case "json":
                    return new JSONFiles(Path);
                case "xml":
                    return new XMLFiles(Path);
                default:
                    ErrorChecking.Instance.ShowError($"The file type of {Path} doesn't work with the current parser engine.");
                    return null;
            }
        }
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
                EngineParsing engineParse = new EngineParsing();
                engineParse.ReadFile((TheFiles)file);
            }
            else if (file is JSONFiles)
            {
                JSONEngine jsonParse = new JSONEngine();
                jsonParse.ReadFile((JSONFiles)file); 
            }
            else if (file is XMLFiles)
            {
                XMLEngine xmlParse = new XMLEngine();
                xmlParse.ReadFile((XMLFiles)file);
            }
            else
            {
                ErrorChecking.Instance.ShowError("Parser is not working, try a different parser for the file!");
            }
        }
    }
}
