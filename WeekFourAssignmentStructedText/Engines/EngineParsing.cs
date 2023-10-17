using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.FileExAndDe;
using WeekFourAssignmentStructedText.Parse;

namespace WeekFourAssignmentStructedText.Engines
{
    //Help from Leo's InClassDemo with reminding to make this an abstract class since the abstract class can be used by other classes like JSONFileParse and XMLFileParse
    internal abstract class EngineParsing
    {
        //The File Processing takes the csv and pipe(txt) files in the list of files that goes through the interface and will process them individually 
        public virtual List<ErrorChecking> FileProcessing(List<IPassing> FileToProcess)
        {
            //List for checking errors w
            List<ErrorChecking> errors = new List<ErrorChecking>();

            try
            {
                for (int i = 0; i < FileToProcess.Count; i++)
                {
                    Dictionary<int, string[]> lines = new Dictionary<int, string[]>();
                    string writeFile = FileToProcess[i].FilePath.Replace(FileToProcess[i].Extension, $"_out{FileExtendAndDeLimit.FileExtensions.Text}");

                    if (File.Exists(writeFile))
                    {
                        File.Delete(writeFile);
                    }

                    //Uses StreamReader to read the file, used from assignment 3 and 4
                    using (StreamReader sourceRead = new StreamReader(FileToProcess[i].FilePath))
                    {
                        int lineIndex = 1;
                        while (!sourceRead.EndOfStream)
                        {
                            var lineItems = sourceRead.ReadLine()?.Split(FileToProcess[i].Delimiter) ?? new string[0];
                            lines.Add(lineIndex++, lineItems);
                        }
                    }

                    //Uses StreamWriter to write out the processed files into a new file, used from assignment 3 and 4
                    using (StreamWriter sourceWrite = new StreamWriter(writeFile, true))
                    {
                        sourceWrite.WriteLine($"Processed at: {DateTime.Now}");
                        sourceWrite.WriteLine();
                        foreach (var item in lines)
                        {
                            sourceWrite.Write($"Line#{item.Key}: ");

                            for (int j = 0; j < item.Value.Length; j++)
                            {
                                sourceWrite.Write($"Field#{j + 1}={item.Value[j]}");
                                if (!(j + 1 == item.Value.Length)) sourceWrite.Write(" ==> ");
                            }
                            sourceWrite.WriteLine();
                            sourceWrite.WriteLine();
                        }
                    }
                }
            }
            //To catch errors that are in the code, learned from in class demo 
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
