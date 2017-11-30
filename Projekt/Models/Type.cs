using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Type
    {
        public int TypeId { get; set; }
        public String TypeName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}