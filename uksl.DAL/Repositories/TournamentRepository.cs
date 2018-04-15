using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uksl.DAL.Entities;
using uksl.DAL.Interfaces;

namespace uksl.DAL.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public IEnumerable<Region> GetTournamnetRegions(double tournamnetId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                var sql = "SELECT DISTINCT r.* FROM Match m JOIN Region r ON m.RegionId = r.Id AND m.TournamentId = @pTournamentId AND m.Stage = 1;";
                var regions = db.Query<Region>(sql, new { pTournamentId = tournamnetId });
                return regions;
            }
        }
        public IEnumerable<VMatch> GetMathes(double tournamentId, byte stage, int regionId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                var sql = "SELECT * FROM vMatch WHERE TournamentId = @pTournamentId AND Stage = @pStage AND RegionId = @pRegionId;";
                var matches = db.Query<VMatch>(sql, new { pTournamentId = tournamentId, pStage = stage, pRegionId = regionId });
                return matches;
            }
        }
    }
}
