using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WebStore.Clients.Base
{
    public abstract class BaseClient
    {
        protected string _address;
        protected HttpClient _http { get; }

        protected BaseClient(HttpClient client, string serviceAddress)
        {
            
            
            _http = client;
            _address = serviceAddress;
        }

    }
}
