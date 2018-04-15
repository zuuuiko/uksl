using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uksl.DAL.Entities
{
    public class VMatch
    {
        public decimal Id { get; set; }
        public decimal TournamentId { get; set; }
        public string Tournament { get; set; }
        public byte Stage { get; set; }
        public int RegionId { get; set; }
        public string Region { get; set; }
        public int RegionStructureId { get; set; }
        public string Type { get; set; }
        public int RoundId { get; set; }
        public string Round { get; set; }
        public int SeqNo { get; set; }
        public decimal? HomeTeamId { get; set; }
        public string HomeTeam { get; set; }
        public decimal? AwayTeamId { get; set; }
        public string AwayTeam { get; set; }
        public decimal? WinnerTeamId { get; set; }
        public string WinnerTeam { get; set; }
        public int? HomeTeamResult { get; set; }
        public int? AwayTeamResult { get; set; }
    }
}
