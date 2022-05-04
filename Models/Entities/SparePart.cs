using ProductApplication.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApplication.Models.Entities
{
    public class SparePart : BaseEntity<Guid>
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(10)]
        public string Code { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public ICollection<ProductSparePart> ProductSpareParts { get; set; }

    }
}