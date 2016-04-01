using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalisisYDisenio1Examen2.Logic.Attributes;

namespace AnalisisYDisenio1Examen2.Tests
{
    public class School
    {
        public string Name;
        public int ClassCount;
        private string Owner;

        public School(string name, int classCount, string owner)
        {
            Name = name;
            ClassCount = classCount;
            Owner = owner;
        }
    }

    public class Student
    {
        [XMLName("studentName")]
        public string Name;

        public Student(string name)
        {
            Name = name;
        }
    }
}
