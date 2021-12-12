using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.Api.Model.Product
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int FabricId { get; set; }
        public string FabricName { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}
