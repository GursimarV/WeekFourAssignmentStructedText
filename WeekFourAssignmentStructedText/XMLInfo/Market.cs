using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeekFourAssignmentStructedText.XMLInfo
{
    //Had help from Powerpoint Week 5 by Leo
    [XmlRoot(ElementName = "menu")]
    public sealed class Market
    {
        [XmlElement(ElementName ="item")]
        public List<Item>? Items { get; set; }

        private StringBuilder stringBuild = new StringBuilder();

        public override string ToString()
        {
            for (int i = 0; i < Items?.Count; i++)
            {
                stringBuild.Append($"Item#{i + 1}: {Items[i].Name} ==> {Items[i].Price}/{Items[i].Measurement}\n");
            }
            return stringBuild.ToString();
        }
    }
}
