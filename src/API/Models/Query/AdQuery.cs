using Application.Services.Ads;
using Application.Services.Ads.DTO;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Query
{
    public class AdQuery : IRequest<AdQueryResult>
    {
        public string SearchString { get; set; }
        public int Discount { get; set; }
    }
    
    public class AdQueryResult
    {
        public IEnumerable<AdDto> Ads { get; set; }
    }
}