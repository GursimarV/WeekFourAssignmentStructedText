﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.Interfaces
{
    internal interface IPassing
    {
        // The different types of files
        public enum FileType
        {
            CSV,
            Pipe,
            Json,
            XML,
            None
        }
        // The interface for the engine
        public interface IPassing
        {
            string Path { get; set; }
            public FileType Type { get; set; }
        }
    }
}
