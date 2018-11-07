using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTSession03.Models
{
    public class ClotherViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Price Reducer")]
        public decimal PriceReduce { get; set; }

        [Display(Name="Image Url")]
        [Required]
        public string ImageUrl { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        public int CategoryClotherId { get; set; }

        public List<CategoryClother> CategoryClother { get; set; }

        public List<CategoryElectronic> CategoryElectronics { get; set; }
    }
}