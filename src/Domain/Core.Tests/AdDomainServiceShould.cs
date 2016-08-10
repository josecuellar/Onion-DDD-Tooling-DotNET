using NUnit.Framework;
using System;
using Domain.Core.Model.Ads;
using Domain.Core.Services.Ads;
using System.Collections.Generic;

namespace Comain.Core.Tests
{

    namespace Application.Services.Tests.Ads
    {
        [TestFixture]
        public class AdDomainServiceShould
        {
            private IAdDomainService adDomainService;
            private List<Ad> ads;

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
                           new Domain.Core.Model.PostalCode("08150")),

                    new Ad(new AdId("Ad2_" + Guid.NewGuid()), 
                            new Domain.Core.Model.Money(AMOUNT_MONEY_AD_2, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)), 
                            new Domain.Core.Model.Coords(1.34343432, 3.44546), 
                            new Domain.Core.Model.PostalCode("08759"))
                };

                this.adDomainService = new AdDomainService();
            }

            [Test]
            public void apply_ads_discount_given_valid_parameters()
            {
                //Arrange

                //Act
                this.adDomainService.ApplyDiscount(this.ads, DISCOUNT);

                //Assert
                Assert.AreEqual(this.ads[0].Price.Amount, AMOUNT_MONEY_AD_1 - DISCOUNT);
                Assert.AreEqual(this.ads[1].Price.Amount, AMOUNT_MONEY_AD_2 - DISCOUNT);
            }

            [Test]
            public void apply_ad_discount_given_valid_parameters()
            {
                //Arrange

                //Act
                this.adDomainService.ApplyDiscount(this.ads[0], DISCOUNT);

                //Assert
                Assert.AreEqual(this.ads[0].Price.Amount, AMOUNT_MONEY_AD_1 - DISCOUNT);
            }

            [Test]
            public void throwException_when_valid_ad_and_invalid_discount_parameter()
            {
                //Act
                TestDelegate testInvalidExceptionException = delegate { this.adDomainService.ApplyDiscount(this.ads[0], INVALID_DISCOUNT); };

                //Assert
                Assert.Throws<InvalidOperationException>(testInvalidExceptionException);
            }

            [Test]
            public void throwException_when_valid_ads_and_invalid_discount_parameter()
            {
                //Act
                TestDelegate testInvalidExceptionException = delegate { this.adDomainService.ApplyDiscount(this.ads[0], INVALID_DISCOUNT); };

                //Assert
                Assert.Throws<InvalidOperationException>(testInvalidExceptionException);
            }

        }
    }

}
