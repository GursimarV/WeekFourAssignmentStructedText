using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeekFourAssignmentStructedText.XMLInfo
{
    //Had help from Powerpoint Week 5 by Leo
    [XmlRoot(ElementName ="item")]
    public sealed class Item
    {
        [XmlElement(ElementName = "name")]
        public string? Name { get; set; }
        
        [XmlElement(ElementName = "price")]
        public string? Price { get; set; }

        [XmlElement(ElementName = "uom")]
        public string? Measurement { get; set; }
    }
}
