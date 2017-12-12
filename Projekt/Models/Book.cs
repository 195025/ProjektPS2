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
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Author { get; set; }
        [Required]
        public int TypeId { get; set; }

        public Type Type { get; set; }
    }
}