using ProductApplication.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApplication.Models.Entities
{
    public class ProductSparePart : BaseEntity<Guid>
    {
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public Guid SparePartId { get; set; }
        [ForeignKey(nameof(SparePartId))]
        public virtual SparePart SparePart { get; set; }

    }
}