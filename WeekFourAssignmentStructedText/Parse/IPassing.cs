using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.Parse
{
    internal interface IPassing
    {
        //interface with the delimiter mainly for csv and pipe files, the file path, and extension of the file, learned from assignment 4
        public string Delimiter { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
    }
}
