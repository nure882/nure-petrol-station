using GasStationMobile.Interfaces;
using GasStationMobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GasStationMobile.Services
{
    public class ApiService : IApiService
    {
        public Query Get(string endpoint)
        {
            return new Query(endpoint, HttpMethod.Get);
        }

        public Query Put<D>(string endpoint, D model)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            return new Query(endpoint, HttpMethod.Put, content);
        }

        public Query Delete<D>(string endpoint, D model)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            return new Query(endpoint, HttpMethod.Delete, content);
        }

        public Query Post<D>(string endpoint, D model)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            return new Query(endpoint, HttpMethod.Post, content);
        }

        public Query Post(string endpoint)
        {
            return new Query(endpoint, HttpMethod.Post);
        }
    }
}
