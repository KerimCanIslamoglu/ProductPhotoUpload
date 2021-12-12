using EcommercePhotoUpload.Business.Abstact;
using EcommercePhotoUpload.DataAccess.Abstract;
using EcommercePhotoUpload.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.Business.Concrete
{
    public class UploadService : IUploadService
    {
        private readonly IProductDetailDal _productDetailDal;

        public UploadService(IProductDetailDal productDetailDal)
        {
            _productDetailDal = productDetailDal;
        }

        public async Task<bool> UploadProductImage(IFormFile file, int colorId, int fabricId, int productId)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {
                var fileName = DateTime.Now.Ticks + "_" + file.FileName;

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\images");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\images",
                   fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var model = new ProductDetail()
                {
                    ColorId=colorId,
                    FabricId=fabricId,
                    ImageName = file.FileName,
                    ImageUrl = "/Resources/images/" + fileName,
                    ProductId = productId
                };
                _productDetailDal.Create(model);
               
                return true;
            }
            else
                return false;
        }
    
    }
}
