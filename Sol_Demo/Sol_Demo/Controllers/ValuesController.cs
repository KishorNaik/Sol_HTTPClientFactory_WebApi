using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("get")]
        public Task<IActionResult> GetData()
        {
            return Task.Run<IActionResult>(() =>
            {
                return base.Ok(new UserModel()
                {
                    FirstName = "Kishor",
                    LastName = "Naik"
                });
            });
        }
    }
}