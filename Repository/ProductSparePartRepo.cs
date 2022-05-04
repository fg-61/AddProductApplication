using ProductApplication.Data;
using ProductApplication.Models.Entities;
using ProductApplication.Repository.Abstracts;
using System;

namespace ProductApplication.Repository
{
    public class ProductSparePartRepo : BaseRepository<ProductSparePart, Guid>
    {
        public ProductSparePartRepo(MyContext context) : base(context)
        {

        }
    }
}
