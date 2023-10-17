using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.JSONInfo;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using WeekFourAssignmentStructedText.Parse;
using WeekFourAssignmentStructedText.FileExAndDe;

namespace WeekFourAssignmentStructedText.Engines
{
    internal class JSONEngine : EngineParsing
    {
        //The File Processing takes the json file in the list of files that goes through the interface and will process the lines in the file individually
        public override List<ErrorChecking> FileProcessing(List<IPassing> filesToProcess)
        {
            //List for checking errors while it is being processed
            List<ErrorChecking> errors = new List<ErrorChecking>();
            try
            {
                foreach (var file in filesToProcess)
                {
                    string writePath = file.FilePath.Replace(file.Extension, $"_out{FileExtendAndDeLimit.FileExtensions.Text}");

                    if (File.Exists(writePath))
                    {
                        File.Delete(writePath);
                    }
                    //Uses StreamReader to read the file, used from assignment 3 and 4
                    using (StreamReader sourceRead = new StreamReader(file.FilePath))
                    {
                        //This part learned from the presentation in week 5
                        //This process the strings we get from the files that are read from StreamReader and I'm telling the JSONNames class they are the root
                        JSONNames newStudent = JsonConvert.DeserializeObject<JSONNames>(sourceRead.ReadToEnd()) ?? new JSONNames();

                        //Uses StreamWriter to write out the processed files into a new file, used from assignment 3 and 4
                        using (StreamWriter sourceWrite = new StreamWriter(writePath, true))
                        {
                            sourceWrite.WriteLine();
                            sourceWrite.Write(newStudent.ToString());
                        }
                    }
                }
            }
            //To catch errors that are in the code, learned from in class demo in week 5
            catch (IOException ioe)
            {
                errors.Add(new ErrorChecking(ioe.Message, ioe.Source ?? "Unknown"));
            }
            catch (Exception e)
            {
                errors.Add(new ErrorChecking(e.Message, e.Source ?? "Unknown"));
            }

            return errors;
        }
    }
}
