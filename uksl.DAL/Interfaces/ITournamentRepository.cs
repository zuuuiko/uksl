using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uksl.DAL.Entities;

namespace uksl.DAL.Interfaces
{
    public interface ITournamentRepository
    {
        IEnumerable<Region> GetTournamnetRegions(double tournamnetId);
        IEnumerable<VMatch> GetMathes(double tournamnetId, byte stage, int regionId);
    }
}
