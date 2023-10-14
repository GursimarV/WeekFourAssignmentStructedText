using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WeekFourAssignmentStructedText.Interfaces;
using WeekFourAssignmentStructedText.XMLInfo;
using WeekFourAssignmentStructedText.DifferentFileTypes;

namespace WeekFourAssignmentStructedText.Engines
{
    internal class XMLEngine : EngineParsing
    {
        //Had help from Powerpoint Week 5 by Leo
        
        public override void ReadFile(IPassing currentFile)
        {
            List<List<string>> Items = new List<List<string>>();
            List<string[]> arrayOfLists = Items.Select(innerList => innerList.ToArray()).ToList();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(currentFile.Path);


            XmlNodeList itemNodes = xmlDoc.DocumentElement.SelectNodes("item");

            foreach (XmlNode node in itemNodes)
            {
                List<string> Values = new List<string>();
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    Values.Add(childNode.InnerText);

                }
                Items.Add(Values);
            }

            // Call WriteFile to write the parsed data to a new file.
            WriteFile(currentFile.Path, arrayOfLists);
        }

    }
}
