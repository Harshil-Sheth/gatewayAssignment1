using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PMS.Models;

namespace PMS.ViewModels
{
    public class ProductFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [Required]
        public byte? CategoryId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 100)]
        [Required]
        public byte? NumberInStock { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Product" : "New Product";
            }
        }
        public ProductFormViewModel()
        {
            Id = 0;
        }

        public ProductFormViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            ReleaseDate = product.ReleaseDate;
            NumberInStock = product.NumberInStock;
            CategoryId = product.CategoryId;
        }
    }
}