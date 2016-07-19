using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Web;
using System.Runtime;
using System.Collections;

namespace Cache
{

    public class HttpRuntimeCache : ICache
    {

        public const int AbsoluteMinutesCache = 720;

        public const int SlidingMinutesCache = 720;

        public void Set(string _Key, object _oCacheValue)
        {
            if (System.Web.HttpContext.Current == null)
                throw new InvalidOperationException("Persistence.InMemory.HttpRuntimeCache.Set :: Entorno HttpContext incorrecto.");

            if (_oCacheValue == null || string.IsNullOrEmpty(_Key))
                throw new InvalidDataException("Persistence.InMemory.HttpRuntimeCache.Set :: Parámetros de entrada incorrectos");

            if ((HttpRuntime.Cache[_Key.ToString()] != null))
                HttpRuntime.Cache[_Key.ToString()] = _oCacheValue;
            else
            {
                HttpRuntime.Cache.Insert(
                    _Key,
                    _oCacheValue,
                    null,
                    DateTime.Now.AddMinutes(AbsoluteMinutesCache),
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    System.Web.Caching.CacheItemPriority.Default,
                    null);
            }
        }

        public void Set(string _Key, object _oCacheValue, System.DateTime _dtExpires)
        {
            if (System.Web.HttpContext.Current == null)
                throw new InvalidOperationException("Persistence.InMemory.HttpRuntimeCache.Set :: Entorno HttpContext incorrecto.");

            if (_oCacheValue == null || string.IsNullOrEmpty(_Key))
                throw new InvalidDataException("Persistence.InMemory.HttpRuntimeCache.Set :: Parámetros de entrada incorrectos");

            HttpRuntime.Cache.Insert(
                _Key,
                _oCacheValue,
                null,
                _dtExpires,
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.Default,
                null);
        }

        public void Remove(string _Key)
        {
            if (System.Web.HttpContext.Current == null)
                throw new InvalidOperationException("Persistence.InMemory.HttpRuntimeCache.Set :: Entorno HttpContext incorrecto.");

            if (string.IsNullOrEmpty(_Key))
                throw new InvalidDataException("Persistence.InMemory.HttpRuntimeCache.Set :: Parámetros de entrada incorrectos");

            HttpRuntime.Cache.Remove(_Key);
        }

        public void RemovePrefix(string prefixKey)
        {
            if (System.Web.HttpContext.Current == null)
                throw new InvalidOperationException("Persistence.InMemory.HttpRuntimeCache.RemovePrefix :: Entorno HttpContext incorrecto.");

            foreach (DictionaryEntry dicache in HttpRuntime.Cache)
            {
                if (dicache.Key.ToString().ToLower().StartsWith(prefixKey.ToLower()))
                    HttpRuntime.Cache.Remove(dicache.Key.ToString());
            }
        }

        public object GetValue(string _Key)
        {
            if (System.Web.HttpContext.Current == null)
                throw new InvalidOperationException("Persistence.InMemory.HttpRuntimeCache.GetValue :: Entorno HttpContext incorrecto.");

            if (string.IsNullOrEmpty(_Key))
                throw new InvalidDataException("Persistence.InMemory.HttpRuntimeCache.GetValue :: Parámetros de entrada incorrectos");

            return HttpRuntime.Cache.Get(_Key);
        }

        public bool Exists(string _Key)
        {

            if (System.Web.HttpContext.Current == null)
                throw new InvalidOperationException("Persistence.InMemory.HttpRuntimeCache.Exists :: Entorno HttpContext incorrecto.");

            if (string.IsNullOrEmpty(_Key))
                throw new InvalidDataException("Persistence.InMemory.HttpRuntimeCache.Exists :: Parámetros de entrada incorrectos");

            if (HttpRuntime.Cache.Get(_Key) != null)
                return true;

            return false;
        }

    }

}
