using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.FileExAndDe
{
    public sealed class FileExtendAndDeLimit
    {
        //The folder name string and The directory path, remember in assignment 3 and 4, also in class demo
        private const string folderName = "Files";

        public static string directPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //The extensions of the files in the files folder
        public sealed class FileExtensions
        {
            public static string JSON => ".json";
            public static string XML => ".xml";
            public static string CSV => ".csv";
            public static string Pipe => ".txt";
            public static string Text => ".txt";
        }

        //The delimiters that mainly affect the csv file and pipe file used in assignment 4
        public sealed class FileDelimiters
        {
            public static string JSON => "";
            public static string XML => "";
            public static string CSV => ",";
            public static string Pipe => "|";
            public static string Text => " ";
        }
    }
}
