using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public interface IItemComparison<T>
    {
        public int Compare(T p_oThis, T p_oOther);
    }

}
