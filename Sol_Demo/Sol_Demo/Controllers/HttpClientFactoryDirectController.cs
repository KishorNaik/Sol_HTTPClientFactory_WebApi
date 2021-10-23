using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sol_Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientFactoryDirectController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory = null;

        public HttpClientFactoryDirectController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:9394");
            var httpResponseMessage = await client.GetAsync("/api/Values/get");

            UserModel userModel = null;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                userModel = JsonConvert.DeserializeObject<UserModel>(result);
            }

            return base.Ok(userModel);
        }
    }
}