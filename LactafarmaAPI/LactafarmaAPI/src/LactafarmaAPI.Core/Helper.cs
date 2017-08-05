﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LactafarmaAPI.Core
{
    internal static class Helper
    {
        public static int CombineHashCodes(IEnumerable<object> objs)
        {
            unchecked
            {
                var hash = 17;
                foreach (var obj in objs)
                    hash = hash * 23 + (obj != null ? obj.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
