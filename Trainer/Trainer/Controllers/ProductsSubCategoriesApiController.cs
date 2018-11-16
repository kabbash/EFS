using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/ProductsSubCategories")]
    [ApiController]
    public class ProductsSubCategoriesApiController : BaseController
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
            return GetStatusCodeResult(_subCategoriesManager.GetAll());
        }

        // GET: api/ProductsSubCategories/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_subCategoriesManager.GetById(id));
        }

        // POST: api/ProductsSubCategories
        [HttpPost]
        public ActionResult Post([FromBody] ProductsSubCategoryDto categoryDto)
        {
            return GetStatusCodeResult(_subCategoriesManager.Insert(categoryDto));
        }

        // PUT: api/ProductsSubCategories/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductsSubCategoryDto categoryDto)
        {
            return GetStatusCodeResult(_subCategoriesManager.Update(categoryDto, id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_subCategoriesManager.Delete(id));
        }
    }
}