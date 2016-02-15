﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ICalendar.ComponentProperties.DateTime.TimeTransparency.TransparencyValue;

namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Calendar Components: VEVENT;
    /// Value Type: TEXT;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class TimeTransparency : IComponentProperty
    {

        public enum TransparencyValue
        {
            TRANSPARENT, OPAQUE
        }

        public string Name => "TRANSP";
        public IEnumerable<IPropertyParameter> PropertyParameters { get; set; }

        public void Serialize(TextWriter writer)
        {
            StringBuilder str = new StringBuilder("TRANSP:");
            str.Append(Value);
            writer.WriteLine("{0}", str);
        }

        public IComponentProperty Deserialize(string value)
        {
            var valueStartIndex = value.IndexOf(':') + 1;
            var strValue = value.Substring(valueStartIndex);
            switch (strValue)
            {
                case "TRANSPARENT":
                    Value = TRANSPARENT;
                    break;
                case "OPAQUE":
                    Value = OPAQUE;
                    break;
                default:
                    Value = OPAQUE;
                    break;
            }
            return this;
        }

        public TransparencyValue Value { get; set; }
    }
}