﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFrameworkDB.MODEL
{
    public partial class VNicerButSlowerFilmList
    {
        public ushort? Fid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public ushort? Length { get; set; }
        public string Rating { get; set; }
        public string Actors { get; set; }
    }
}
