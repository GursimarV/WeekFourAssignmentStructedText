﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekFourAssignmentStructedText.Interfaces;

namespace WeekFourAssignmentStructedText.DifferentFileTypes
{
    internal class XMLFile : IPassing
    {
        public XMLFile(string path)
        {
            Path = path;
            Type = FileType.XML;
        }

        public string Path { get; set; }

        public FileType Type { get; set; }

        public override string ToString()
        {
            return Path;
        }
    }
}
