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
    [Route("api/Products")]
    [ApiController]
    public class ProductsApiController : BaseController
    {
        private readonly IProductsManager _productsManager;
        private readonly IProductsRatingManager _productsRatingManager;
        public ProductsApiController(IProductsManager productsManager, IProductsRatingManager productsRatingManager)
        {
            _productsManager = productsManager;
            _productsRatingManager = productsRatingManager;
        }

        // GET: api/ProductsCategories
        [HttpGet]
        public ActionResult Get()
        {
            return GetStatusCodeResult(_productsManager.GetAll());
        }

        // GET: api/ProductsCategories/5
        [HttpGet("{id}")]
        public ActionResult Get(byte id)
        {
            return GetStatusCodeResult(_productsManager.GetById(id));
        }

        // POST: api/ProductsCategories
        [HttpPost]
        public ActionResult Post([FromBody] ProductsDto productsDto)
        {
            return GetStatusCodeResult(_productsManager.Insert(productsDto));
        }

        // PUT: api/ProductsCategories/5
        [HttpPut("{id}")]
        public ActionResult Put(byte id, [FromBody] ProductsDto productsDto)
        {
            return GetStatusCodeResult(_productsManager.Update(productsDto, id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(byte id)
        {
            return GetStatusCodeResult(_productsManager.Delete(id));
        }

        [HttpPost("AddRate")]
        public ActionResult AddRate(ProductsRatingDto newRate)
        {
            return GetStatusCodeResult(_productsRatingManager.AddOrUpdate(newRate));
        }
    }
}