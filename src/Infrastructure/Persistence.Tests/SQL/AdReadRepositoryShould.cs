using Domain.Core.Model.Ads;
using Persistence.SQL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Persistence.SQL.Ads;

namespace Infrastructure.Persistence.Tests
{

    [TestFixture]
    public class AdQueryRepositoryShould
        {
        private Mock<Cache.ICache<IEnumerable<Ad>>> cacheQueryAd;
            private Mock<IConnectionFactory> connectionFactory;
            private IAdQueryRepository adQueryRepository;
            private List<Ad> ads;
            
            private IDbConnection connection;

            private const string CONNECTION_STRING = "Data Source=XXX;Initial Catalog=XXX;User ID=XXX;Password=XXX;Min Pool Size=10;Max Pool Size=150";


            private const int AMOUNT_MONEY_AD_1 = 80;
            private const int AMOUNT_MONEY_AD_2 = 50;


            [SetUp]
            public void SetUp()
            {
                this.ads = new List<Ad>()
                {
                    new Ad(new AdId("Ad1_" + Guid.NewGuid()), new Domain.Core.Model.Money(AMOUNT_MONEY_AD_1, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)), new Domain.Core.Model.Coords(1.34343432, 3.44546), new Domain.Core.Model.PostalCode("08150"), "Title 1"),
                    new Ad(new AdId("Ad2_" + Guid.NewGuid()), new Domain.Core.Model.Money(AMOUNT_MONEY_AD_2, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)), new Domain.Core.Model.Coords(1.34343432, 3.44546), new Domain.Core.Model.PostalCode("08759"), "Title 2")
                };

                //Disable cache
                this.cacheQueryAd = new Mock<Cache.ICache<IEnumerable<Ad>>>();
                this.cacheQueryAd.Setup(r => r.Get(It.IsAny<string>())).Returns((IEnumerable<Ad>)null);
                //*

                this.connection = new SqlConnection(CONNECTION_STRING);
                this.connectionFactory = new Mock<IConnectionFactory>();
                this.connectionFactory.Setup(x => x.Create()).Returns(connection);

                this.adQueryRepository = new AdQueryRepository(this.connectionFactory.Object, this.cacheQueryAd.Object);

            }

            [Test]
            public void getall_ads_repository()
            {
                //Act
                IEnumerable<Ad> ads = this.adQueryRepository.GetAll();

                this.cacheQueryAd.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
                this.cacheQueryAd.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Ad>>()), Times.Once);

                //Assert
                Assert.IsNotNull(ads);
            }

            [Test]
            public void get_ad_repository()
            {
                //Act
                Ad ad = this.adQueryRepository.GetById(this.ads[0].Id);

                this.cacheQueryAd.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
                this.cacheQueryAd.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Ad>>()), Times.Once);

                //Assert
                Assert.IsNotNull(ad);
            }


        }
    }
