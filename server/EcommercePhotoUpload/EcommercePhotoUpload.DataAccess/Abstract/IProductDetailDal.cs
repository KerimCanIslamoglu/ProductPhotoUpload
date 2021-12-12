using EcommercePhotoUpload.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.DataAccess.Abstract
{
    public interface IProductDetailDal : IRepositoryBase<ProductDetail>
    {
        List<ProductDetail> GetProductDetailsByProductCode(int productId);
    }
}
