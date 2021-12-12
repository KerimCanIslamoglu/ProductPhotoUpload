using EcommercePhotoUpload.Business.Abstact;
using EcommercePhotoUpload.DataAccess.Abstract;
using EcommercePhotoUpload.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetProductsWithDetail()
        {
            return _productDal.GetProductsWithDetail();
        }
    }
}
