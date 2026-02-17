using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Helpers.Sorting
{
    public class BoatCompareByID : IComparer<Boat>
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
            if (x.Id == y.Id)
            {
                return 0;
            }
            if (x.Id > y.Id)
            {
                return 1;
            }
            return -1;
            
        }
    }
}
