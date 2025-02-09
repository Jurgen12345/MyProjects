using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data.Structures
{
    public interface IItemIterator<T>
    {
        public bool EndOf { get; }
        public void Reset();
        public T? Next();
    }
}
