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
        private Application.Services.Ads.IAdReadService _adService;

        public AdQueryHandler(Application.Services.Ads.IAdReadService adService)
        {
            this._adService = adService;
        }

        public AdQueryResult Handle(AdQuery message)
        {
            var model = new AdQueryResult();
            if (string.IsNullOrEmpty(message.SearchString))
            {
                model.Ads.ToList().AddRange(this._adService.GetAllAdsAndApplyDiscount(message.Discount));
                return model;
            }

            model.Ads.ToList().AddRange(this._adService.GetAdsTitleContainsAndApplyDiscount(message.SearchString, message.Discount));
            return model;
        }
    }
}