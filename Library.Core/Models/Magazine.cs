﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models
{
    public class Magazine : LibraryItem
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int ReleaseYear { get; set; }
        public int SerialNumber { get; set; }
    }
}
