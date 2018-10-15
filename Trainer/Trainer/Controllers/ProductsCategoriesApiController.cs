using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Categories.Core.Interfaces;
using Products.Categories.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/ProductsCategories")]
    [ApiController]
    public class ProductsCategoriesApiController : ControllerBase
    {
        private readonly IProductsCategoriesManager _categoriesManager;
        public ProductsCategoriesApiController(IProductsCategoriesManager categoriesManager)
        {
            _categoriesManager = categoriesManager;
        }

        // GET: api/ProductsCategories
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_categoriesManager.GetAll());
        }

        // GET: api/ProductsCategories/5
        [HttpGet("{id}")]
        public ActionResult Get(byte id)
        {
            return Ok(_categoriesManager.GetById(id));
        }

        // POST: api/ProductsCategories
        [HttpPost]
        public ActionResult Post([FromBody] ProductsCategoryDto categoryDto)
        {
            return Ok(_categoriesManager.Insert(categoryDto));
        }

        // PUT: api/ProductsCategories/5
        [HttpPut("{id}")]
        public ActionResult Put(byte id, [FromBody] ProductsCategoryDto categoryDto)
        {
            return Ok(_categoriesManager.Update(categoryDto, id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(byte id)
        {
            return Ok(_categoriesManager.Delete(id));
        }
    }
}
