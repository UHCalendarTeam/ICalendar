﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICalendar.GeneralInterfaces
{
    public interface IAggregator
    {
        void AddItem(object obj);
    }
}
