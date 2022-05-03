using ProductApplication.Data;
using ProductApplication.Models.Entities;
using ProductApplication.Repository.Abstracts;
using System;

namespace ProductApplication.Repository
{
    public class ProductRepo : BaseRepository<Product, Guid>
    {
        public ProductRepo(MyContext context) : base(context)
        {

        }
    }
}
