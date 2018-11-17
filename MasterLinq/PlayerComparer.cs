using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterLinq
{
    class PlayerComparer : IEqualityComparer<ChessPlayer>
    {
        public bool Equals(ChessPlayer x, ChessPlayer y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null))
                return false;

            if (ReferenceEquals(y, null))
                return false;

            if (x.GetType() != y.GetType())
                return false;

            return string.Equals(x.FirstName, y.FirstName, StringComparison.InvariantCultureIgnoreCase)
                && string.Equals(x.LastName, y.LastName, StringComparison.InvariantCultureIgnoreCase)
                && x.BirthYear == y.BirthYear
                && x.Rating == y.Rating
                && string.Equals(x.Country, y.Country, StringComparison.InvariantCultureIgnoreCase);

        }

        public int GetHashCode(ChessPlayer obj)
        {
            unchecked
            {
                var hashCode = (obj.FirstName != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.FirstName) : 0);
                hashCode = (hashCode * 397) ^ (obj.LastName != null? StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.LastName) : 0);
                hashCode = (hashCode * 397) ^ obj.BirthYear;
                hashCode = (hashCode * 397) ^ obj.Rating;
                hashCode = (hashCode * 397) ^ (obj.Country != null? StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Country) : 0);
                return hashCode;
            }
        }
    }
}
