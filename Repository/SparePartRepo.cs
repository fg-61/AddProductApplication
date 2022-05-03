using ProductApplication.Data;
using ProductApplication.Models.Entities;
using ProductApplication.Repository.Abstracts;
using System;

namespace ProductApplication.Repository
{
    public class SparePartRepo : BaseRepository<SparePart, Guid>
    {
        public SparePartRepo(MyContext context) : base(context)
        {

        }
    }
}
