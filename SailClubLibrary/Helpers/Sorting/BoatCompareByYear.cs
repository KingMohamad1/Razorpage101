using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareByYear : IComparer<Boat>
    {
        public int Compare(Boat? x, Boat? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x != null && y == null)
            {
                return 1;
            }
            if (x == null && y != null)
            {
                return -1;
            }
            if (x.YearOfConstruction.CompareTo(y.YearOfConstruction) == 0)
            {
                return 0;
            }
            if (x.YearOfConstruction.CompareTo(y.YearOfConstruction) > 0)
            {
                return 1;
            }
            return -1;
        }
    }
}
