using API.Models.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Application.Services.Ads;

namespace API.Models.Query
{
    public class AdQueryHandler : IRequestHandler<AdQuery, AdQueryResult>
    {
        private Application.Services.Ads.IAdQueryService _adService;

        public AdQueryHandler(Application.Services.Ads.IAdQueryService adService)
        {
            this._adService = adService;
        }

        public AdQueryResult Handle(AdQuery message)
        {
            var model = new AdQueryResult();
            model.Ads.ToList().Add(this._adService.GetAdTitleContainsAndApplyDiscount(message.SearchString, message.Discount));
            return model;

        }
    }
}