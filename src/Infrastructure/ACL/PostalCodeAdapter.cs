using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model;
using Domain.Core.Services;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;

namespace ACL
{
    public class PostalCodeAdapter : HttpClient, Domain.Core.Services.IPostalCodeAdapter
    {

        private readonly IPostalCodeTranslator postalCodeTranslator;

        public PostalCodeAdapter(IPostalCodeTranslator postalCodeTranslator)
        {
            this.postalCodeTranslator = postalCodeTranslator;
        }

        public PostalCode GetByCode(string code)
        {
            object tokenResponse = OpenClientAndResponseGet("http://api.geonames.org/", "postalCodeSearch?postalcode=9011&maxRows=10&username=demo");
            return this.postalCodeTranslator.ToPostalCode(tokenResponse);
        }

        private async Task<object> OpenClientAndResponseGet(string baseUrl, string querystring)
        {

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://api.geonames.org/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("postalCodeSearch?postalcode=9011&maxRows=10&username=demo");
                if (response.IsSuccessStatusCode)
                {
                    string jsonMessage = string.Empty;
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }
                    return JsonConvert.DeserializeObject(jsonMessage);
                }
            }
            return null;
        }

    }
}
