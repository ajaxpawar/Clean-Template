using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Common.Utilities
{
    public static class ValidationUtils
    {
        public static bool IsNotNull(object obj)
        {
            return obj != null;
        }
        public static bool IsNotNullAndNotEmpty<T>(IEnumerable<T> list)
        {
            return list != null && list.Any();
        }
    }
}
