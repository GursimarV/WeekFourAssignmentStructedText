using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WeekFourAssignmentStructedText.FileExAndDe;
using WeekFourAssignmentStructedText.Parse;
using WeekFourAssignmentStructedText.XMLInfo;

namespace WeekFourAssignmentStructedText.Engines
{
    internal class XMLEngine : EngineParsing
    {
        //The File Processing takes the xml file in the list of files that goes through the interface and will process the lines in the file individually
        public override List<ErrorChecking> FileProcessing(List<IPassing> FileToProcess)
        {
            //List for checking errors while it is being processed
            List<ErrorChecking> errors = new List<ErrorChecking>();
            try
            {
                foreach (var file in FileToProcess)
                {
                    string writePath = file.FilePath.Replace(file.Extension, $"_out{FileExtendAndDeLimit.FileExtensions.Text}");

                    if (File.Exists(writePath))
                    {
                        File.Delete(writePath);
                    }

                    //This part learned from week 5 presentation
                    //Reading the XML file with FileStream and the data is being return from File.Open
                    using (var fs = File.Open(file.FilePath, FileMode.Open))
                    {
                        //This will process the file and I'm saying the Market class is the root class
                        XmlSerializer serializer = new XmlSerializer(typeof(Market));
                        var marketInventory = (Market?)serializer.Deserialize(fs) ?? new Market();

                        using (StreamWriter sourceWrite = new StreamWriter(writePath, true))
                        {
                            sourceWrite.WriteLine();
                            sourceWrite.Write(marketInventory.ToString());
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
