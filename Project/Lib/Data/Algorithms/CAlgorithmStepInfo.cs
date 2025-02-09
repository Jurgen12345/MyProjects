using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data.Structures;

namespace Lib.Data.Algorithms
{
    
    public class CAlgorithmStepInfo
    {
        public int InnerLoopIndex { get; set; }
        public int OuterLoopIndex { get; set; }

        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int MiddleIndex { get; set; }

        public string? Message { get; set; } = "";
    }


    public class CAlgorithmLLStepInfo
    {
        public int InnerLoopIndex { get; set; }
        public int OuterLoopIndex { get; set; }

        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int MiddleIndex { get; set; }

        public string Message { get; set; } = "";
    }



    // [C# ADVANCED] DELEGATES: A delegate is a type of a method, that defines a specific parameter list.
    public delegate void AlgorithmStepHandler<T>(CArray<T> Sender, CAlgorithmStepInfo Info);

    public delegate void AlgorithmLLStepHandler<T>(CSinglyLinkedList<T> Sender, CAlgorithmStepInfo Info);

}
