﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web
{
    public static class StringExtension
    {
        public static bool ContainsAll(this string source, params string[] values)
        {
            if (values.Count() <= 0) return false;
            return values.All(x => source.Contains(x));
        }

        public static bool ContainsAny(this string source, params string[] values)
        {
            if (values.Count() <= 0) return false;
            return values.Any(x => source.Contains(x));
        }
    }
}