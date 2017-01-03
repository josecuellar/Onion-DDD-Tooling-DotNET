using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;
using Domain.Core.Model;
using Domain.Core.Event;

namespace Domain.Core.Model.Ads

{
   
    public interface IAdPriceChanged : IDomainEvent
    {
        AdId AdId { get; set; }

        Money ToPrice { get; set; }

        DateTime OccurredOn { get; set; }
    }
}
