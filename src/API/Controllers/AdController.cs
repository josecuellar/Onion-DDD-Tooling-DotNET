using Application.Services.Ads;
using Application.Services.Ads.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class AdController : ApiController
    {

        private readonly IMediator _mediator;

        public AdController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public IEnumerable<AdDto> Get([FromUri]Models.Query.AdQuery query)
        {
            return this._mediator.Send(query).Ads;
        }

        // POST api/values
        public async Task<int> Post([FromBody]API.Models.Command.AdCommand adCommand)
        {
            int result = await this._mediator.SendAsync<int>(adCommand);

            return result;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            //simulate change postal code for test. TO-DO: Create test with TDD :)
            //AdDto adToReturn = this.adService.ChangePostalCode(id.ToString(), "08150");
            //return "value";
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
