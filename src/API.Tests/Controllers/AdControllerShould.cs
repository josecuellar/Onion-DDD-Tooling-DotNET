using System.Web.Mvc;
using API;
using API.Controllers;
using Moq;
using Application.Services.Ads;
using NUnit.Framework;
using System.Collections.Generic;
using Domain.Core.Model.Ads;
using System;
using Application.Services.Ads.DTO;

namespace API.Tests.Controllers
{
    [TestFixture]
    public class AdControllerShould
    {

        private Mock<IAdQueryService> adService;
        private AdController adController;
        private IEnumerable<AdDto> ads;

        private const int DISCOUNT = 30;

        private const int AMOUNT_MONEY_AD_1 = 80;
        private const int AMOUNT_MONEY_AD_2 = 50;

        [SetUp]
        public void SetUp()
        {
            this.ads = new List<AdDto>()
                {
                    new AdDto() {
                           Id = "3434",
                           Amount = 536,
                           IsoCode="EUR"
                    },

                    new AdDto() {
                           Id = "1234",
                           Amount = 5336,
                           IsoCode="EUR"
                    },
                };

            this.adService = new Mock<IAdQueryService>();
            this.adService.Setup(x => x.GetAllAdsAndApplyDiscount(DISCOUNT)).Returns(this.ads);
            //this.adController = new AdController(this.adService.Object);
        }

        
    }
}
