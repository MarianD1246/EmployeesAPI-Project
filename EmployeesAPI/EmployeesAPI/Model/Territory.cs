﻿using System;
using System.Collections.Generic;

namespace EmployeesAPI
{
    public partial class Territory
    {
        public string TerritoryId { get; set; } = null!;
        public string TerritoryDescription { get; set; } = null!;
        public int RegionId { get; set; }
    }
}
