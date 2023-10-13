using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.JSONInfo
{
    internal class JSONAddress
    {
        //Had help from Powerpoint Week 5 by Leo
        [JsonPropertyName("streetAddress")]
        public string? StreetAddress;

        [JsonPropertyName("city")]
        public string? City;

        [JsonPropertyName("state")]
        public string? State;

        [JsonPropertyName("postalCode")]
        public string? PostalCode;

        public override string ToString()
        {
            return $"{StreetAddress}, {City}, {State}, {PostalCode}";
        }
    }
}
