using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeekFourAssignmentStructedText.JSONInfo
{
    internal class JSONNames
    {
        //Had help from Powerpoint Week 5 by Leo
        //This is the root of the Json file
        [JsonPropertyName("firstName")]
        public string? FirstName;

        [JsonPropertyName("lastName")]
        public string? LastName;

        [JsonPropertyName("isEnrolled")]
        public bool IsEnrolled;

        [JsonPropertyName("yearsEnrolled")]
        public int YearsEnrolled;

        [JsonPropertyName("address1")]
        public JSONAddress? Address1;

        [JsonPropertyName("address2")]
        public JSONAddress? Address2;

        [JsonPropertyName("phoneNumbers")]
        public List<JSONPhoneNum> PhoneNumbers = new List<JSONPhoneNum>();  

        private StringBuilder stringBuild = new StringBuilder();

        public override string ToString()
        {
            //Lays out the text and the information from the processed file
            stringBuild.Append($"Name: {LastName ?? "Not available"}, {FirstName ?? "Not available"}\n");
            stringBuild.Append(IsEnrolled ? "Student is currently enrolled.\n" : "Student is not enrolled.\n");
            stringBuild.Append($"Student enrolled for {YearsEnrolled} years\n");
            stringBuild.Append($"Primary Address: {Address1?.ToString() ?? "No primary address"}\n");
            stringBuild.Append($"Secondary Address: {Address2?.ToString() ?? "No secondary address"}\n");
            for (int i = 0; i < PhoneNumbers?.Count; i++)
            {
                stringBuild.Append($"Phone Number {i + 1}: {PhoneNumbers[i].ToString()}");
            }
            return stringBuild.ToString();
        }
    }
}
