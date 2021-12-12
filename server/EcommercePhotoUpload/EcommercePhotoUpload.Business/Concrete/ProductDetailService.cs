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
    public class ProductDetailService:IProductDetailService
    {
        private readonly IProductDetailDal _productDetailDal;

        public ProductDetailService(IProductDetailDal productDetailDal)
        {
            _productDetailDal = productDetailDal;
        }

        public bool DeleteProductDetail(int productDetailId)
        {
            var model = _productDetailDal.GetById(productDetailId);
            if (model != null)
            {
                _productDetailDal.Delete(model);
                return true;
            }

            return false;
        }

        public List<ProductDetail> GetProductDetails(int productId)
        {
            return _productDetailDal.GetProductDetailsByProductCode(productId);
        }
    }
}
