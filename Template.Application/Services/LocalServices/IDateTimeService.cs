﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Services.Local_Services
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        string DateString { get; }
    }
}
