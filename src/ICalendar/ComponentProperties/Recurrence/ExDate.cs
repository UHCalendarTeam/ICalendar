﻿using System;
using System.Collections.Generic;

namespace ICalendar.ComponentProperties
{
    /// <summary>
    /// Calendar Components: VEVENT, VTODO, VJOURNAL -- STANDARD, DAYLIGHT subcomponents;
    /// Value Type: DATETIME/DATE;
    /// Properties Parameters: iana, non-standard, value data type, time zone identifier
    /// </summary>
    public class Exdate : ComponentProperty<IList<DateTime>>
    {
        public override string Name => "EXDATE";
    }
}