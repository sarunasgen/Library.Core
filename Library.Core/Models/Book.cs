using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models
{
    public class Book : LibraryItem
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
    }
}
