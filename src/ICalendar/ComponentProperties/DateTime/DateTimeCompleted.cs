﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ICalendar.ComponentProperties.DateTime
{
    /// <summary>
    /// Calendar Components: VTODO;
    /// Value Type: UTC;
    /// Properties Parameters: iana, non-standard
    /// </summary>
    public class DateTimeCompleted : DateTimeProperty
    {

        public override string Name => "COMPLETED";
        public override void Serialize()
        {

            throw new NotImplementedException();
        }

        public override IComponentProperty Deserialize()
        {
            throw new NotImplementedException();
        }

        public override System.DateTime Value { get; }
    }
}
