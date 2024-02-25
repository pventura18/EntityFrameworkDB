﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFrameworkDB.MODEL
{
    public partial class ActorInfo
    {
        public ushort? ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FilmInfo { get; set; }
    }
}
