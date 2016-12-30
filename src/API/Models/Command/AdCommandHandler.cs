using API.Models.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Application.Services.Ads;
using Application.Services.Ads.DTO;

namespace API.Models.Command
{
    public class AdCommandHandler : IAsyncRequestHandler<AdCommand, int>
    {
        private Application.Services.Ads.IAdCommandService _adService;

        public AdCommandHandler(Application.Services.Ads.IAdCommandService adService)
        {
            _adService = adService;
        }


        public async Task<int> Handle(AdCommand message)
        {
            AdDto dtoCreated = new AdDto()
            {
                Id = message.Id,
                Title = message.Title
            };

            return await _adService.CreateNewAd(dtoCreated);

        }
    }
}