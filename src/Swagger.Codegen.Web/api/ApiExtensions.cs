using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Swagger.Codegen.Web.Api
{
    public static class ApiExtensions
    {
        #region IEnumerable<T>

        public static TDest MapTo<TDest>(this object source)
        {
            if (source == null)
            {
                return default(TDest);
            }

            return Mapper.Map<TDest>(source);
        }

        public static IEnumerable<TDest> MapTo<TDest>(this IEnumerable source)
        {
            if (source == null)
            {
                return new TDest[0];
            }

            return source.Cast<object>().Select(x => MapTo<TDest>(x));
        }

        public static Nullable<TDest> MapToNullable<TDest>(this object source)
            where TDest : struct
        {
            if (source == null)
            {
                return null;
            }

            return Mapper.Map<TDest>(source);
        }

        #endregion IEnumerable<T>

        #region String

        public static string ToValidFilename(this string val)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                val = val.Replace(c, '_');
            }

            return val;
        }

        #endregion String
    }
}