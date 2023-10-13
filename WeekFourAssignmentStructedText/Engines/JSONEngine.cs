using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.Interfaces;
using WeekFourAssignmentStructedText.JSONInfo;

namespace WeekFourAssignmentStructedText.Engines
{
    internal class JSONEngine : EngineParsing
    {
        //Had help from Powerpoint Week 5 by Leo
        public override void ReadFile(IPassing currentFile) 
        {
            List<List<string>> Items = new List<List<string>>();
            List<string> Values = new List<string>();
            Student currentStudent;
            using (StreamReader sourceRead = new StreamReader(currentFile.Path))
            {
                currentStudent = JsonConvert.DeserializeObject<JSONNames>(sourceRead.ReadToEnd());

                using (StreamWriter sourceWrite =  new StreamWriter(currentFile.Path))
                {
                    sourceWrite.WriteLine($"Line#1 : {currentStudent.ToString()}");
                }
            }

            Values = currentStudent.GetValues();

            Items.Add(Values);

            // Call WriteFile to write the parsed data to a new file.
            WriteFile(currentFile.Path, Items);
        }
    }
}
