using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatternsInAsp.Models.ViewModels
{
    public class FormProductViewModel
    {
        [Required]
        [Display(Name = "Id único")]
        public string ProductId { get; set; }
        
        [Required]
        [Display(Name = "Nombre")]
        public string ProductName { get; set; }
        
        [Required]
        [Display(Name="Descripción")]
        public string ProductDescription { get; set; }

        [Required]
        [Display(Name = "Id Categoría")]
        public string CategoryId { get; set; }
    }
}
