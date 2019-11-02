using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimus.Models;
using RestSharp;


namespace Minimus.Services.Proxy
{
    public class ProxyCountry : IProxyCountry
    {
        private RestClient _client;

        public ProxyCountry()
        {
            _client = new RestClient("https://restcountries.eu/rest/v2/all");
        }

        public List<CountryObject> country()
        {
            var request = new RestRequest();
            var response = _client.Get<List<CountryObject>>(request);
            return response.Data;
        }

    }
}
