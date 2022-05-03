using ProductApplication.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Models.Entities
{
    public class Product : BaseEntity<Guid>
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(10)]
        public string Code { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public virtual List<SparePart> SpareParts { get; set; }
    }
}