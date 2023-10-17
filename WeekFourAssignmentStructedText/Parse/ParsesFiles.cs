using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.Engines;
using static WeekFourAssignmentStructedText.FileExAndDe.FileExtendAndDeLimit;

namespace WeekFourAssignmentStructedText.Parse
{
    internal class ParsesFiles
    {
        //List for the files to process
        List<IPassing> FileToProcess = new List<IPassing>();
        //List to help check for errors, learned in week 5 in class demo
        List<ErrorChecking> errorCheck = new List<ErrorChecking>();
        
        //To check if the problem is true or false
        bool hasProblem => errorCheck.Any();

        public ParsesFiles()
        {
            //list of string names with their file type that the user wants to parse
            List<string> fileExtend = GetEveryFile();

            foreach (var type in fileExtend)
            {
                //Adds the list of strings to the list of FileToProcess
                FileToProcess.Add(MakesFile(type));
            }

            if (hasProblem)
            {
                Console.WriteLine("There is a problem with the code!");
                foreach (var error in errorCheck)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage} Source:{error.Source}");
                }
                return;
            }

            //Learned from week 5 In Class Demo for processing the different file type with different engines
            EngineParsing engineParse;

            engineParse = new DeLimitEngine(); 
            errorCheck.AddRange(engineParse.FileProcessing(FileToProcess.Where(x => x.Extension == FileDelimiters.Pipe || x.Extension == FileDelimiters.CSV).ToList()));

            engineParse = new JSONEngine();
            errorCheck.AddRange(engineParse.FileProcessing(FileToProcess.Where(x => x.Extension == FileExtensions.JSON).ToList()));

            engineParse = new XMLEngine();
            errorCheck.AddRange(engineParse.FileProcessing(FileToProcess.Where(x => x.Extension == FileExtensions.XML).ToList()));

            //if there is a problem with the engine, it will read out the error and the source before going to the engine
            if (hasProblem) 
            {
                Console.WriteLine("There is a problem with the code!");
                foreach (var error in errorCheck)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage} Source:{error.Source}");
                }
            }
            else
            {
                Console.WriteLine("The files have completed the process!");
            }
        }
        //Creates a result file after going through the parsing method and engines
        List<string> GetEveryFile()
        {
            return Directory.GetFiles(directPath).Where(x => !x.EndsWith("_out.txt")).ToList();
        }
        //This handles the different files and their types that are valid through the TheFiles object
        //fileExtends is the string name for the files
        TheFiles MakesFile(string fileExtends)
        {
            TheFiles file = new TheFiles();

            if(fileExtends.EndsWith(FileExtensions.Pipe)) 
            {
                file.Delimiter = FileDelimiters.Pipe;
                file.Extension = FileExtensions.Pipe;
            }
            else if (fileExtends.EndsWith(FileExtensions.CSV))
            {
                file.Delimiter = FileDelimiters.CSV;
                file.Extension = FileExtensions.CSV;
            }
            else if (fileExtends.EndsWith(FileExtensions.JSON))
            {
                file.Delimiter = FileDelimiters.JSON;
                file.Extension = FileExtensions.JSON;
            }
            else if (fileExtends.EndsWith(FileExtensions.XML))
            {
                file.Delimiter = FileDelimiters.XML;
                file.Extension = FileExtensions.XML;
            }
            else
            {
                //Checks if the files is supported for the parsing 
                errorCheck.Add(new ErrorChecking($"Invalid File Extension, {fileExtends.Substring(fileExtends.LastIndexOf("."))} is not supported", $"{file}"));
            }
            //Creating and directing the output files to the folder 
            file.FilePath = Path.Combine(directPath, fileExtends);

            return file;
        }
    }
}
