using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neutrints.Core.Interfaces;
using Neutrints.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/FoodItems")]
    [ApiController]
    public class FoodItemsController : BaseController
    {
        private readonly INeutrintsManager _neutrintsManager;

        public FoodItemsController(INeutrintsManager neutrintsManager)
        {
            _neutrintsManager = neutrintsManager;
        }
        [HttpGet]
        public ActionResult Get([FromQuery]FoodIemFilter filter)
        {
            return GetStatusCodeResult(_neutrintsManager.GetAll(filter));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_neutrintsManager.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Post([FromForm] FoodItemDto foodItemDto)
        {
            foodItemDto.CreatedBy = GetCurrentUser().Id;
            return GetStatusCodeResult(_neutrintsManager.Insert(foodItemDto));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Put(int id, [FromForm] FoodItemDto foodItemDto)
        {
            foodItemDto.UpdatedBy = GetCurrentUser().Id;
            return GetStatusCodeResult(_neutrintsManager.Update(foodItemDto, id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_neutrintsManager.Delete(id));
        }
    }
}