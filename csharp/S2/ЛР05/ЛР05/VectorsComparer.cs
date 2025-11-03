
using System.Collections.Generic;
using System.Text;

namespace LR_5
{
    class VectorsComparer : IComparer<IVectorable>
    {
        public int Compare(IVectorable vector1, IVectorable vector2)
        {
            if (vector1.GetNorm() < vector2.GetNorm())
            {
                return -1;
            }
            else if (vector1.GetNorm() > vector2.GetNorm())
            {
                return 1;
            }
            return 0;
        }
    }
}


