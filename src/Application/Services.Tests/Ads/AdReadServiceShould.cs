using Application.Services.Ads;
using Application.Services.Ads.DTO;
using Domain.Core.Model.Ads;
using Domain.Core.Services;
using Domain.Core.Services.Ads;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Application.Services.Tests.Ads
{
    [TestFixture]
    public class AdServiceShould
    {

        private Mock<IAdQueryRepository> adQueryRepository;
        private Mock<IAdDomainService> domainService;
        private IEnumerable<Ad> ads;
        private IAdQueryService adQueryService;

        private const int DISCOUNT = 30;
        private const int INVALID_DISCOUNT = -50;

        private const int AMOUNT_MONEY_AD_1 = 80;
        private const int AMOUNT_MONEY_AD_2 = 50;


        [SetUp]
        public void SetUp()
        {
            this.ads = new List<Ad>()
                {
                    new Ad(new AdId("Ad1_" + Guid.NewGuid()),
                           new Domain.Core.Model.Money(AMOUNT_MONEY_AD_1, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)),
                           new Domain.Core.Model.Coords(1.34343432, 3.44546),
                           new Domain.Core.Model.PostalCode("08150"), 
                           "Title 1"),

                    new Ad(new AdId("Ad2_" + Guid.NewGuid()),
                            new Domain.Core.Model.Money(AMOUNT_MONEY_AD_2, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)),
                            new Domain.Core.Model.Coords(1.34343432, 3.44546),
                            new Domain.Core.Model.PostalCode("08759"), 
                           "Title 2")
                };

            this.adQueryRepository = new Mock<IAdQueryRepository>();
            adQueryRepository.Setup(r => r.GetAll()).Returns(ads);

            this.domainService = new Mock<IAdDomainService>();

            this.adQueryService = new AdQueryService(this.domainService.Object, this.adQueryRepository.Object);
        }

        [Test]
        public void getall_ads_given_valid_parameters()
        {
            //Arrange

            //Act
            List<AdDto> ads = (List<AdDto>)this.adQueryService.GetAllAdsAndApplyDiscount(DISCOUNT);
            this.domainService.Verify(x => x.ApplyDiscount(this.ads, DISCOUNT), Times.Once);
            this.adQueryRepository.Verify(x => x.GetAll(), Times.Once);

            //Assert
            Assert.That(ads, Is.Not.Null);
            Assert.AreEqual(ads.Count, 2);
        }


        [Test]
        public void throwException_when_invalid_discount_parameter()
        {
            //Act
            TestDelegate testInvalidExceptionException = delegate { this.adQueryService.GetAllAdsAndApplyDiscount(INVALID_DISCOUNT); };

            //Assert
            Assert.Throws<InvalidOperationException>(testInvalidExceptionException);
        }

    }
}
