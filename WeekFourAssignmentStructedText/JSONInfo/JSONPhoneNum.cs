using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.JSONInfo
{
    internal class JSONPhoneNum
    {
        //Had help from Powerpoint Week 5 by Leo
        [JsonPropertyName("type")]
        public string? Type;

        [JsonPropertyName("number")]
        public string? Number;

        [JsonPropertyName("CanContact")]
        public bool CanContact;

        public override string ToString()
        {
            return $"{Number ?? @"N/A"} | {Type ?? @"N/A"} | Can Contact: {(CanContact ? "Yes" : "No")}\n";
        }
    }
}
