using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    public class RatingsComparer : IEqualityComparer<ChessPlayer>
    {
        public bool Equals(ChessPlayer x, ChessPlayer y)
        {
            return x.Rating == y.Rating;
        }

        public int GetHashCode(ChessPlayer obj)
        {
            return obj.Rating.GetHashCode();
        }
    }
}
