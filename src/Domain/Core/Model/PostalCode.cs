using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model
{

    /// <summary>
    /// Value Object PostalCode. 1 code - N locations.
    /// </summary>
    public class PostalCode
    {

        public readonly string Code;

        public readonly string Name;

        public PostalCode(string code)
        {
            this.Code = code;
        }

        public PostalCode(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public PostalCode changePostalCode(string code)
        {
            return new PostalCode(code);
        }

    }

}
