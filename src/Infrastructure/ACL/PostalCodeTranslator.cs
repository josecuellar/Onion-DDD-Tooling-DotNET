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
    public class PostalCodeTranslator : Domain.Core.Services.IPostalCodeTranslator
    {
        public PostalCode ToPostalCode(object postalCodeData)
        {
            return new Domain.Core.Model.PostalCode(
                postalCodeData.GetType().GetProperty("postalcode").GetValue(postalCodeData).ToString(),
                postalCodeData.GetType().GetProperty("adminName1").GetValue(postalCodeData).ToString());
        }
    }
}
