using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Attribs
{

    //C#: This is an example of a class that inherits from Attribute, implementing a source code attribute.
    //    A source code attribute should not be confused with the UML term, it facilitates declarative programming
    //    We declare the attribute above a class member, using the constructor of the attribute inside the brackets
    //    along with its parameters. This attaches an extra attribute to a class member.
    //    Think of HTML elements that have attributes, another type of declarative programming.

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ColumnWidth : Attribute
    {
        private int __width = 0;
        public int Width { get { return __width; } }

        public ColumnWidth(int p_nWidth)
        {
            __width = p_nWidth;
        }
    }
}
