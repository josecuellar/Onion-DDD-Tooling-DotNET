using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Services.Ads;
using Domain.Core.Model.Ads;

namespace Application.Services.Ads
{
    public class AdDto
    {
        public string Id { get; set; }

        public int Amount { get; set; }

        public string IsoCode { get; set; }
    }
}
