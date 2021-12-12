using EcommercePhotoUpload.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.Business.Abstact
{
    public interface IProductDetailService
    {
        List<ProductDetail> GetProductDetails(int productId);
        bool DeleteProductDetail(int productDetailId);
    }
}
