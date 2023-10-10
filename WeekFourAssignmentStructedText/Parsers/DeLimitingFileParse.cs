using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.DifferentFileTypes;

namespace WeekFourAssignmentStructedText.Parsers
{
    internal class DeLimitingFileParse: EngineParsing
    {
        /*
        public override void ReadFile(TheFiles outputFile)
        {
            // Lines getting added to the list to be parsed
            List<string[]> LineAdd = new List<string[]>();
            string[] values;

            // Streamreader reads the file from the file path one line at a time, Credit to Assignment #3 that helped remember about streamreader
            using (StreamReader sourceRead = new StreamReader(outputFile.Path))
            {
                // Reads lines from the source file as a string
                string? outputLine = sourceRead.ReadLine();

                while (outputLine != null)
                {
                    values = outputLine.Split(outputFile.Delimiters);
                    LineAdd.Add(values);
                    outputLine = sourceRead.ReadLine();
                }
            }

            // The new lines from that were added after being delimited will go to the WriteFile method to be written into a new file
            WriteFile(outputFile.Path, LineAdd);
        }
        */
    }
}
