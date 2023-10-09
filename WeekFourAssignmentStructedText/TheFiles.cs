using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.Interfaces;

namespace WeekFourAssignmentStructedText
{
    public class TheFiles : IPassing
    {
        public TheFiles(string path)
        {
            Path = path;
            Type = CheckType();
        }

        public string Path { get; set; }

        public FileType Type { get; set; }

        public char DeLimiter { get; private set; }
        public char Delimiter { get; internal set; }

        private FileType CheckType()
        {
                string extension = Path.Substring(Path.LastIndexOf('.') + 1);
                switch (extension)
                {
                    case "csv":
                        DeLimiter = ',';
                        return FileType.CSV;

                    case "txt":
                        DeLimiter = '|';
                        return FileType.Pipe;
                    
                    default:
                        return Type = FileType.None;
                }
        }

        public override string ToString()
        {
            return Path;
        }
    }
}