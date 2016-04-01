using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AnalisisYDisenio1Examen2.Logic.Extensions;
using AnalisisYDisenio1Examen2.Logic.Attributes;

namespace AnalisisYDisenio1Examen2.Logic
{
    public class XMLSerializer
    {

        public string Serialize(dynamic value, string varName = null)
        {
            if (value == null) { return ""; }

            Type type = value.GetType();
            string serialized = "<" + type.Name + (varName != null ? " name = '" + varName + "'" : "") + ">";

            if (type.IsPrimitivePP())
            {
                serialized += Convert.ToString(value);
            }
            else if (type.IsArray)
            {
                serialized += BuildArrayTag(value);
            }
            else
            {
                serialized += BuildComplexTag(value, varName);
            }

            serialized += "</" + type.Name + ">";

            return serialized;
        }

        private string BuildArrayTag(dynamic value)
        {
            Type type = value.GetType();
            Type arrType = type.GetEnumeratedType();
            string tag = "";
            foreach (var val in value)
            {
                tag += Serialize(val);
            }


            return tag;
        }

        private string BuildComplexTag( dynamic value, string varName)
        {
            Type type = value.GetType();
           
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string tag = "";

            foreach (var field in fields)
            {
                var xmlName = field.GetCustomAttribute<XMLName>();
                tag += Serialize(field.GetValue(value), xmlName == null ? field.Name : xmlName.Name);
            }

            foreach(var property in properties)
            {
                var xmlName = property.GetCustomAttribute<XMLName>();
                tag += Serialize(property.GetValue(value), xmlName == null ? property.Name : xmlName.Name);
            }

            return tag;
        }

        private bool IsNumericType(dynamic value)
        {

            Type type = value.GetType();
            if (type == null)
            {
                return false;
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }
    }
}
