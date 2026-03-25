using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Helpers.Filter
{
    public class FilterFunctions
    {
        //generisk funktion, som kan filtrere en generisk liste udfra
        //et eller flere predicates. Gerne en liste af predicates.
        public List<Member> Filter(List<Member> members, List<Predicate<Member>> predicates)
        {
            throw new NotImplementedException();
        }
    }
}
