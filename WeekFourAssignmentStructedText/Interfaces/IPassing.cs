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
            Json,
            XML,
            None
        }
        public interface IPassing
        {
            public string Path { get; set; }

            public FileType Type { get; set; }
        }
}
