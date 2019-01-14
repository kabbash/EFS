using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lookups.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trainer.Controllers
{
    [Route("api/common")]
    public class CommonApiController : Controller
    {
        private readonly ICommonService _commonService;
        public CommonApiController(ICommonService service)
        {
            _commonService = service;
        }
        [HttpGet]
        [Route("getEntityDDL")]
        public ActionResult GetEntityDDL(int entityDDLId)
        {
            return Ok(_commonService.GetEntityDDL(entityDDLId));
        }
    }
}
