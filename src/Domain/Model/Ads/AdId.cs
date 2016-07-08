using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Ads
{
    /// <summary>
    /// Value Object AdId. Inmutable. 
    /// </summary>
    public class AdId
    {

        public readonly string Id;

        public AdId(string id)
        {
            
            if (string.IsNullOrEmpty(id))
            {
                this.Id = new Guid().ToString();
            }

            this.Id = id;

        }

    }
}
