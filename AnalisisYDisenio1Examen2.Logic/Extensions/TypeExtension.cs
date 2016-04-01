using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisYDisenio1Examen2.Logic.Extensions
{
    public static class TypeExtension
    {
        public static bool IsPrimitivePP(this Type type)
        {
            return type.IsPrimitive || type == typeof(string) || type == typeof(DateTime) || type == typeof(decimal);
        }

        public static Type GetEnumeratedType(this Type type)
        {
            var enumType = type.GetElementType();
            if (null != enumType) return enumType;

            var enumTypes= type.GetGenericArguments();
            if (enumTypes.Length > 0) return enumTypes[0];

            return null;
        }
    }
}
