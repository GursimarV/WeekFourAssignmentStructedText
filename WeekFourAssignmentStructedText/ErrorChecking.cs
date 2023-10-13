using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText
{
    public class ErrorChecking
    {
        private static ErrorChecking instance = null;

        public static ErrorChecking Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ErrorChecking();
                }
                return instance;
            }
        }

        List<string> errorProblem = new List<string>();

        public void ShowError(string message)
        {
            errorProblem.Add(message);
            Console.WriteLine(message);
        }


        public void StreamError(string path)
        {
            using (FileStream fs = File.Create(path + "\\Errors.txt"))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    if (errorProblem.Count > 0)
                    {
                        foreach (var error in errorProblem)
                        {
                            sw.WriteLine($"Error: {error}");
                        }
                    }
                    else
                    {
                        sw.WriteLine("Program executed succesfully with no errors.");
                    }
                }
            }

        }
    }
}
