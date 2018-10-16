using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.SubCategories.Core.Interfaces;
using Products.SubCategories.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/ProductsSubCategories")]
    [ApiController]
    public class ProductsSubCategoriesApiController : ControllerBase
    {
        private readonly IProductsSubCategoriesManager _subCategoriesManager;
        public ProductsSubCategoriesApiController(IProductsSubCategoriesManager subCategoriesManager)
        {
            _subCategoriesManager = subCategoriesManager;
        }

        // GET: api/ProductsSubCategories
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_subCategoriesManager.GetAll());
        }

        // GET: api/ProductsSubCategories/5
        [HttpGet("{id}")]
        public ActionResult Get(byte id)
        {
            return Ok(_subCategoriesManager.GetById(id));
        }

        // POST: api/ProductsSubCategories
        [HttpPost]
        public ActionResult Post([FromBody] ProductsSubCategoryDto categoryDto)
        {
            return Ok(_subCategoriesManager.Insert(categoryDto));
        }

        // PUT: api/ProductsSubCategories/5
        [HttpPut("{id}")]
        public ActionResult Put(byte id, [FromBody] ProductsSubCategoryDto categoryDto)
        {
            return Ok(_subCategoriesManager.Update(categoryDto, id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(byte id)
        {
            return Ok(_subCategoriesManager.Delete(id));
        }
    }
}