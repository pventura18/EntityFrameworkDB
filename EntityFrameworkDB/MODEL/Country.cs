﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFrameworkDB.MODEL
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public ushort CountryId { get; set; }
        public string Country1 { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
