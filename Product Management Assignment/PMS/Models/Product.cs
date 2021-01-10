using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Category")]
        [Required]
        public byte CategoryId { get; set; }

        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Number in Stock")]
        [Range(1, 100)]
        public byte NumberInStock { get; set; }
    }
}