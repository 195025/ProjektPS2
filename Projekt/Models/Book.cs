using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int BookId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Author { get; set; }

        public int TypeId { get; set; }

        public Type Type { get; set; }
    }
}