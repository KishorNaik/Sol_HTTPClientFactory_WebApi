using Newtonsoft.Json;
using Sol_Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sol_Demo.Services
{
    public class ValueHttpClient
    {
        private readonly HttpClient httpClient = null;

        public ValueHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserModel> GetUserModelData()
        {
            var httpResponseMessage = await this.httpClient.GetAsync("/api/Values/get");

            UserModel userModel = null;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                userModel = JsonConvert.DeserializeObject<UserModel>(result);
            }

            return userModel;
        }
    }
}