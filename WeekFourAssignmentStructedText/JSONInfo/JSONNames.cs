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
        [JsonPropertyName("firstName")]
        public string FirstName;

        [JsonPropertyName("lastName")]
        public string LastName;

        [JsonPropertyName("isEnrolled")]
        public bool IsEnrolled;

        [JsonPropertyName("yearsEnrolled")]
        public int YearsEnrolled;

        [JsonPropertyName("address1")]
        public JSONAddress Address1;

        [JsonPropertyName("address2")]
        public string? Address2;

        [JsonPropertyName("phoneNumbers")]
        public List<JSONPhoneNum> PhoneNumbers = new List<JSONPhoneNum>();  

        private StringBuilder stringBuild = new StringBuilder();

        public List<string> GetValues()
        {
            List<string> values = new List<string>();
            var properties = this.GetType().GetFields();

            foreach (var prop in properties)
            {

                var value = prop.GetValue(this);

                if (value is string)
                {
                    var addProperties = value.GetType().GetFields();

                    foreach (var addProp in addProperties)
                    {
                        var addValue = addProp.GetValue(value);
                        values.Add(addValue.ToString());
                    }
                }
                else if (value is List<JSONPhoneNum>)
                {
                    foreach (var phone in (List<JSONPhoneNum>)value)
                    {
                        var phoneProperties = phone.GetType().GetFields();

                        foreach (var phoneProp in phoneProperties)
                        {
                            var phoneValue = phoneProp.GetValue(phone);
                            values.Add(phoneValue.ToString());
                        }
                    }

                }
                else
                {
                    if (value != null)
                    {
                        values.Add(value.ToString());
                    }
                    else
                    {
                        values.Add("");
                    }
                }
            }

            return values;
        }
    }
}
