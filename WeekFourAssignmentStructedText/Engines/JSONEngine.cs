using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.Interfaces;
using WeekFourAssignmentStructedText.DifferentFileTypes;
using WeekFourAssignmentStructedText.JSONInfo;
using Newtonsoft.Json;

namespace WeekFourAssignmentStructedText.Engines
{
    internal class JSONEngine : EngineParsing
    {
        //Had help from Powerpoint Week 5 by Leo
        public override void ReadFile(IPassing outputFile)
        {
            //List<List<string>> Lines = new List<List<string>>();
            List<string[]> Lines = new List<string[]>();
            List<string> Result = new List<string>();

            JSONNames currentNames;
            using (StreamReader sourceRead = new StreamReader(outputFile.Path))
            {
                currentNames = JsonConvert.DeserializeObject<JSONNames>(sourceRead.ReadToEnd());
            }

            Result = currentNames.GetValues();

            string[] ResultArray = Result.ToArray();

            Lines.Add(ResultArray);

            // Call WriteFile to write the parsed data to a new file.

            WriteFile(outputFile.Path, Lines);
        }
    }
}
