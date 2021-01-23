using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Clients.TestApi;

namespace WebStore.Clients.Values
{
    public class ValuesClient : BaseClient, IValuesService
    {
        public ValuesClient(HttpClient client) : base(client, "api/values")
        {
            
        }

        
        public IEnumerable<string> Get()
        {
            var response = _http.GetAsync(_address).Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<string>>().Result;
            else
                return Enumerable.Empty<string>();
        }

        public string Get(int id)
        {
            var response = _http.GetAsync($"{_address}/{id}").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<string>().Result;
            else
                return string.Empty;
        }

        public Uri Post(string value)
        {
            var response = _http.PostAsJsonAsync(_address, value).Result;
            return response.EnsureSuccessStatusCode().Headers.Location;
        }

        public HttpStatusCode Update(int id, string value)
        {
            var response = _http.PutAsJsonAsync($"{_address}/{id}", value).Result;
            return response.EnsureSuccessStatusCode().StatusCode;
        }

        public HttpStatusCode Delete(int id)
        {
            var response = _http.DeleteAsync($"{_address}/{id}").Result;
            return response.EnsureSuccessStatusCode().StatusCode;
        }

    }
}
