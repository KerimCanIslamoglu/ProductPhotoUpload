using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.Api.Model.Product
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ColorCount { get; set; }
        public int FabricCount { get; set; }
        public int ImageCount { get; set; }
    }
}
