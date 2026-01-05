using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GasStationMobile
{
    public abstract class HttpClientBase
    {
        protected readonly HttpClient HttpClient;

        protected HttpClientBase()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (send, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient = new HttpClient(clientHandler);

        }

        protected async Task<HttpResponseMessage> SendRequest(HttpRequestMessage request)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("jwt_token"));
            var response = await HttpClient.SendAsync(request);
            return response;
        }
    }
}
