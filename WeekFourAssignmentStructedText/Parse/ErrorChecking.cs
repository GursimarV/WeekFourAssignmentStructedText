using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.Parse
{
    //Learned from the in class demo in week 5 to put out error message and where the source is from
    public class ErrorChecking
    {
        public string ErrorMessage { get; set; }
        public string Source { get; set; }

        public ErrorChecking(string message, string source)
        {
            ErrorMessage = message;
            Source = source;
        }
    }
}
