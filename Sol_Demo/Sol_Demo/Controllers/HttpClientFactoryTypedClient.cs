using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.Model;
using Sol_Demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientFactoryTypedClient : ControllerBase
    {
        private readonly ValueHttpClient httpClient = null;

        public HttpClientFactoryTypedClient(ValueHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            UserModel userModel = await this.httpClient.GetUserModelData();

            return base.Ok(userModel);
        }
    }
}