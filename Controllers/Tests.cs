using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"DATABASE_NAME:{Environment.GetEnvironmentVariable("DATABASE_NAME")}";
        }
    }
}
