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
    public class ProductDetailDal : GenericRepository<ProductDetail, ApplicationDbContext>, IProductDetailDal
    {
        private ApplicationDbContext _db;

        public ProductDetailDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ProductDetail> GetProductDetailsByProductCode(int productId)
        {
            return _db.ProductDetails
                .Include(x => x.Color)
                .Include(x => x.Fabric)
                .Include(x => x.Product)
                .Where(x => x.ProductId == productId)
                .ToList();
        }
    }
}
