using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public interface ICache
    {

        void Set(string _Key, object _oCacheValue);

        void Set(string _Key, object _oCacheValue, System.DateTime _dtExpires);

        void Remove(string _Key);

        void RemovePrefix(string prefixKey);

        object GetValue(string _Key);

        bool Exists(string _Key);

    }
}
