using Cache;
using Domain.Core.Model.Ads;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Infrastructure.Cache.Tests
{

    [TestFixture]
    public class HttpRuntimeCacheShould
    {
        private ICache<IEnumerable<Ad>> cacheAds;
        private ICache<Ad> cacheAd;
        private List<Ad> ads;

        private const string KEY_CACHE_ADS = "AdsIdTest";
        private const string KEY_CACHE_AD = "AdIdTest";

        private const int AMOUNT_MONEY_AD_1 = 80;
        private const int AMOUNT_MONEY_AD_2 = 50;

        [SetUp]
        public void SetUp()
        {

            //Simulate current context
            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter())
            );

            this.ads = new List<Ad>()
            {
                new Ad(new AdId("Ad1_" + Guid.NewGuid()), new Domain.Core.Model.Money(AMOUNT_MONEY_AD_1, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)), new Domain.Core.Model.Coords(1.34343432, 3.44546), new Domain.Core.Model.PostalCode("08150"), "Title 1"),
                new Ad(new AdId("Ad2_" + Guid.NewGuid()), new Domain.Core.Model.Money(AMOUNT_MONEY_AD_2, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)), new Domain.Core.Model.Coords(1.34343432, 3.44546), new Domain.Core.Model.PostalCode("08759"), "Title 2")
            };

            //Disable cache
            this.cacheAds = new HttpRuntimeCache<IEnumerable<Ad>>();
            this.cacheAd = new HttpRuntimeCache<Ad>();
            //*

        }

        [Test]
        public void set_and_get_ad_cache_repository()
        {
            //Arrange
            this.cacheAd.Set(KEY_CACHE_AD, this.ads[0]);

            //Act
            Ad adCached = this.cacheAd.Get(KEY_CACHE_AD);

            //Assert
            Assert.IsNotNull(adCached);
            Assert.AreEqual(adCached.Id.Id, this.ads[0].Id.Id);
            Assert.AreEqual(adCached.Price.Amount, this.ads[0].Price.Amount);
            //ToDo: Check All Data Object or implement Equals en entities
        }

        [Test]
        public void set_and_get_ads_cache_repository()
        {
            //Arrange
            this.cacheAds.Set(KEY_CACHE_ADS, this.ads);

            //Act
            List<Ad> adsCached = (List<Ad>)this.cacheAds.Get(KEY_CACHE_ADS);

            //Assert
            Assert.IsNotNull(adsCached);
            Assert.AreEqual(adsCached[0].Id.Id, this.ads[0].Id.Id);
            Assert.AreEqual(adsCached[0].Price.Amount, this.ads[0].Price.Amount);

            Assert.AreEqual(adsCached[1].Id.Id, this.ads[1].Id.Id);
            Assert.AreEqual(adsCached[1].Price.Amount, this.ads[1].Price.Amount);
            //ToDo: Check All Data Object or implement Equals en entities
        }

        [Test]
        public void remove_cache_repository()
        {
            //Arrange
            this.cacheAds.Set(KEY_CACHE_ADS, this.ads);
            this.cacheAds.Remove(KEY_CACHE_ADS);

            //Act
            List<Ad> adsCached = (List<Ad>)this.cacheAds.Get(KEY_CACHE_ADS);

            //Assert
            Assert.IsNull(adsCached);
        }

        [Test]
        public void throwException_given_incorrect_key_cahe_to_save_ads()
        {
            //Arrange
            TestDelegate testInvalidExceptionException = delegate { this.cacheAds.Set(string.Empty, this.ads); };

            //Assert
            Assert.Throws<InvalidDataException>(testInvalidExceptionException);
        }

        [Test]
        public void throwException_given_incorrect_value_cahe_to_save_ads()
        {
            //Arrange
            TestDelegate testInvalidExceptionException = delegate { this.cacheAds.Set(KEY_CACHE_ADS, null); };

            //Assert
            Assert.Throws<InvalidDataException>(testInvalidExceptionException);
        }


        [Test]
        public void throwException_given_incorrect_key_cahe_to_save_ad()
        {
            //Arrange
            TestDelegate testInvalidExceptionException = delegate { this.cacheAd.Set(string.Empty, this.ads[0]); };

            //Assert
            Assert.Throws<InvalidDataException>(testInvalidExceptionException);
        }

        [Test]
        public void throwException_given_incorrect_current_context()
        {
            //Arrange
            HttpContext.Current = null;
            TestDelegate testInvalidExceptionException = delegate { this.cacheAd.Set(KEY_CACHE_ADS, this.ads[0]); };

            //Assert
            Assert.Throws<InvalidOperationException>(testInvalidExceptionException);
        }

    }
}

