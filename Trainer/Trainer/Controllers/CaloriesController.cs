using Lookups.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Models;
using Shared.Core.Utilities.Models;
using test.core.Model;

namespace Trainer.Controllers
{
    [Route("api/calories")]
    [ApiController]
    public class CaloriesController : BaseController
    {
        protected ILookupService<CaloriesDto, Calories> _Manager;
        public CaloriesController(ILookupService<CaloriesDto, Calories> manager)
        {
            _Manager = manager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<ResultMessage> Get()
        {
           return GetStatusCodeResult(_Manager.GetAll());
        }
        [HttpPost]
        public ActionResult Post([FromBody] CaloriesDto calories)
        {            
            var success = _Manager.Insert(calories);
            return Ok(success);
            //if (success)
            //{
            //    return Ok();
            //}
            //else
            //{
            //    return NotFound();
            //}
        }

        // GET api/calories/5
        [HttpGet("{id}")]
        public ActionResult<ResultMessage> Get(byte id)
        {

            return GetStatusCodeResult(_Manager.GetById(id));
        }


        // PUT api/calories/5
        [HttpPut("{id}")]
        public ActionResult<ResultMessage> Put(int id, [FromBody] CaloriesDto value)
        {
            return GetStatusCodeResult(_Manager.Update(value, id));
        }

        // DELETE api/calories/5
        [HttpDelete("{id}")]
        public ActionResult Delete(byte id)
        {
            return GetStatusCodeResult(_Manager.Delete(id));
        }
       
    }
}
