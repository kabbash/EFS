using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Models;
using test.core.Interfaces;
using test.core.Model;

namespace Trainer.Controllers
{
    [Route("api/calories")]
    [ApiController]
    public class CaloriesController : ControllerBase
    {
        protected ICaloriesManager _Manager;
        public CaloriesController(ICaloriesManager manager)
        {
            _Manager = manager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CaloriesDto>> Get()
        {
            return _Manager.GetAll().ToList();
        }
        [HttpPost]
        public ActionResult post([FromBody] CaloriesDto article)
        {
            Boolean success = _Manager.Insert(article);
            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/calories/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(short id)
        {

            var result = _Manager.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        // PUT api/calories/5
        [HttpPut("{id}")]
        public ActionResult Put(short id, [FromBody] CaloriesDto value)
        {
            var result = _Manager.Update(value, id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/calories/5
        [HttpDelete("{id}")]
        public ActionResult Delete(short id)
        {
            var result = _Manager.Delete(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPatch("{id}")]
        public ActionResult Patch(short id, [FromBody]JsonPatchDocument<CaloriesDto> personPatch)
        {
            var result = _Manager.Patch(id, personPatch);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
