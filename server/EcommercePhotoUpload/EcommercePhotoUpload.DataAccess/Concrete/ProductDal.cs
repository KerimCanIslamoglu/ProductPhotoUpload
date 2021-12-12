using EcommercePhotoUpload.DataAccess.Abstract;
using EcommercePhotoUpload.DataAccess.Context;
using EcommercePhotoUpload.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.DataAccess.Concrete
{
    public class ProductDal : GenericRepository<Product, ApplicationDbContext>, IProductDal
    {
        private ApplicationDbContext _db;

        public ProductDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Product> GetProductsWithDetail()
        {
            return _db.Products.Include(x => x.ProductDetails).ToList();
        }
    }
}
