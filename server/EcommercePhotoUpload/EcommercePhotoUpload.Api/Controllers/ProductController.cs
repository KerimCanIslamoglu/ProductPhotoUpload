using EcommercePhotoUpload.Api.Model;
using EcommercePhotoUpload.Api.Model.Product;
using EcommercePhotoUpload.Business.Abstact;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePhotoUpload.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IUploadService _uploadService;
        private IProductDetailService _productDetailService;
        private IProductService _productService;

        public ProductController(IUploadService uploadService, IProductDetailService productDetailService, IProductService productService)
        {
            _uploadService = uploadService;
            _productDetailService = productDetailService;
            _productService = productService;
        }

        [HttpGet]
        [Route("api/[controller]/GetProductList")]
        public IActionResult GetProductList()
        {
            var productList = _productService
                  .GetProductsWithDetail()
                  .Select(x => new ProductListDto
                  {
                      ProductId=x.Id,
                      ProductName=x.ProductName,
                      ColorCount=x.ProductDetails.GroupBy(x => x.ColorId).Count(),
                      FabricCount = x.ProductDetails.GroupBy(x=>x.FabricId).Count(),
                      ImageCount = x.ProductDetails.Where(x=>x.ImageName!=null).Count(),
                  })
                  .ToList();

            return Ok(new ResponseModel<List<ProductListDto>>
            {
                Success = true,
                StatusCode = 200,
                Message = "Success",
                Response = productList
            });
        }

        [HttpGet]
        [Route("api/[controller]/GetProductDetail/{productId}")]
        public IActionResult GetProductDetail(int productId)
        {
            var productDetail = _productDetailService
                .GetProductDetails(productId)
                .Select(x => new ProductDetailDto
                {
                    ColorId = x.ColorId,
                    ColorName = x.Color.ColorName,
                    FabricId = x.FabricId,
                    FabricName = x.Fabric.FabricName,
                    Id = x.Id,
                    ImageName = x.ImageName,
                    ImageUrl = x.ImageUrl,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName
                }).ToList();

            return Ok(new ResponseModel<List<ProductDetailDto>>
            {
                Success = true,
                StatusCode = 200,
                Message = "Success",
                Response = productDetail
            });
        }


        [HttpPost("api/[controller]/UploadProductImage")]
        public async Task<IActionResult> UploadProductImage(IFormFile formFile)
        {
            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            var colorId = Convert.ToInt32(dict["colorId"]);
            var fabricId = Convert.ToInt32(dict["fabricId"]);
            var productId = Convert.ToInt32(dict["productId"]);

            var isSuccess = await _uploadService.UploadProductImage(formFile, colorId, fabricId, productId);
            if (isSuccess)
            {
                return Ok(new ResponseModel<List<string>>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = "Success",
                    Response = null
                });

            }
            return BadRequest(new ResponseModel<string>
            {
                Success = true,
                StatusCode = 200,
                Message = "The file extension must be jpg, jpeg or png.",
                Response = null
            });

        }

        [HttpDelete]
        [Route("api/[controller]/DeleteProductDetail/{productDetailId}")]
        public IActionResult DeleteProductDetail(int productDetailId)
        {
            var isDeleted = _productDetailService
                .DeleteProductDetail(productDetailId);

            if (isDeleted)
            {
                return Ok(new ResponseModel<List<ProductDetailDto>>
                {
                    Success = true,
                    StatusCode = 200,
                    Message = "Success",
                    Response = null
                });
            }
            return BadRequest(new ResponseModel<string>
            {
                Success = true,
                StatusCode = 200,
                Message = "Failed",
                Response = null
            });
        }
    }
}
