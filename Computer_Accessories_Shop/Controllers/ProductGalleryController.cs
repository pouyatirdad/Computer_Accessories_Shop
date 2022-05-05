using Computer_Accessories_Shop.Api.ViewModel.Products;
using Computer_Accessories_Shop.Data.Model;
using Computer_Accessories_Shop.Service.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Computer_Accessories_Shop.Api.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class ProductGalleryController : Controller
    {
        private readonly IProductGalleryService ProductGalleryService;
        public ProductGalleryController(IProductGalleryService ProductGalleryService)
        {
            this.ProductGalleryService = ProductGalleryService;
        }

        [HttpGet]
        public IEnumerable<ProductGallery> Get()
        {
            return ProductGalleryService.GetAll();
        }
        [HttpGet("Get/{id:int}")]
        public ProductGallery Get(int id)
        {
            var findedReslut = ProductGalleryService.GetById(id);
            return findedReslut;
        }
        [HttpPost("Create")]
        public bool Create(ProductGalleryViewModel model)
        {

            var newModel=new ProductGallery()
            {
                Title = model.Title,
                Image=model.Image,
                ProductID=model.ProductID,
            };

            return ProductGalleryService.Create(newModel);
        }
        [HttpPost("Edit")]
        public bool Edit(ProductGalleryViewModel model)
        {

            var newModel = new ProductGallery()
            {
                ID = model.ID,
                Title = model.Title,
                Image = model.Image,
                ProductID = model.ProductID,
            };

            return ProductGalleryService.Edit(newModel);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return ProductGalleryService.Delete(id);
        }
    }
}
