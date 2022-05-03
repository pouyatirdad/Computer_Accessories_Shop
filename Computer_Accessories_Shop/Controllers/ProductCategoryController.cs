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
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IEnumerable<ProductCategory> Get()
        {
            return productCategoryService.GetAll();
        }
        [HttpGet("Get/{id:int}")]
        public ProductCategory Get(int id)
        {
            var findedReslut = productCategoryService.GetById(id);
            return findedReslut;
        }
        [HttpPost("Create")]
        public bool Create(ProductCategory model)
        {
            return productCategoryService.Create(model);
        }
        [HttpPost("Edit")]
        public bool Edit(ProductCategory model)
        {
            return productCategoryService.Edit(model);
        }
        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            return productCategoryService.Delete(id);
        }
    }
}
