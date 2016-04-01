using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisYDisenio1Examen2.Logic.Attributes
{
    public class XMLName : Attribute
    {
        public string Name;

        public XMLName(string name)
        {
            Name = name;
        }
    }
}
