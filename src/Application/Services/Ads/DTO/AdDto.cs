using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;

namespace Application.Services.Ads.DTO
{
    public class AdDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Amount { get; set; }

        public string IsoCode { get; set; }

        public string PostalCode { get; set; }

        public string PostalCodeName { get; set; }
    }
}
