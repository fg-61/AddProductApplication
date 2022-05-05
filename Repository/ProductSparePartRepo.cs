using Microsoft.EntityFrameworkCore;
using ProductApplication.Data;
using ProductApplication.Models.Entities;
using ProductApplication.Repository.Abstracts;
using System;
using System.Linq;

namespace ProductApplication.Repository
{
    public class ProductSparePartRepo : BaseRepository<ProductSparePart, Guid>
    {
        public ProductSparePartRepo(MyContext context) : base(context)
        {

        }
    }
}
