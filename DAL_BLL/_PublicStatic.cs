using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class _PublicStatic
    {
        public static void clearCache(QL_MBTBDTDataContext context)
        {
            const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var method = context.GetType().GetMethod("ClearCache", FLAGS);
            method.Invoke(context, null);
        }
    }
}
