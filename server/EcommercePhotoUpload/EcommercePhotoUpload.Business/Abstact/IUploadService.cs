using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.Business.Abstact
{
    public interface IUploadService
    {
        Task<bool> UploadProductImage(IFormFile file,int colorId,int fabricId,int productId);
    }
}
