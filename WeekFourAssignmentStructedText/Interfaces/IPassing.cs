using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.Interfaces
{
    public enum FileType
    {
        CSV,
        Pipe,
        None
    }
    public interface IPassing
    {
        string Path { get; set; }
        public FileType Type { get; set; }
    }
}
