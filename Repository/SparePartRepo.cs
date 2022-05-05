using Microsoft.EntityFrameworkCore;
using ProductApplication.Data;
using ProductApplication.Models.Entities;
using ProductApplication.Repository.Abstracts;
using System;
using System.Linq;

namespace ProductApplication.Repository
{
    public class SparePartRepo : BaseRepository<SparePart, Guid>
    {
        public SparePartRepo(MyContext context) : base(context)
        {

        }

        public IQueryable<SparePart> GetSparePartsOfProduct(Guid id)
        {
            return Table
                .Include(x => x.ProductSpareParts
                    .Where(y => y.ProductId == id));
        }
    }
}
