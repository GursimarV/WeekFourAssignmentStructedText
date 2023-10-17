using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.Parse
{
    internal sealed class TheFiles : IPassing
    {
        //Learned from assignment 4 
        public string Delimiter { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
    }
}
