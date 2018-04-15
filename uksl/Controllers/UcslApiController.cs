using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using uksl.DAL.Entities;
using uksl.DAL.Interfaces;
using uksl.DAL.Repositories;

namespace uksl.Controllers
{
    //[Route("api/UcslApi")]
    public class UcslApiController : ApiController
    {
        public ITournamentRepository TournamentRepository { get; private set; }
        public UcslApiController()
        {
            TournamentRepository = new TournamentRepository();
        }
        //[HttpGet]
        //[Route("api/UcslApi/GetRegionList")]
        public IHttpActionResult GetTournamentRegions(double tournamnetId)
        {
            var data = TournamentRepository.GetTournamnetRegions(tournamnetId);
            return Json(data/*.Select(r=>new { regionId = r.Id, regionName = r.Name })*/);
            //return Json(new[] { new { regionId = 1, regionName = "KNEU" }, new { regionId = 2, regionName = "KPI" } });
        }
        public IHttpActionResult GetTournamentData(double tournamentId, byte stage, int regionId)
        {
            var matches = TournamentRepository.GetMathes(tournamentId, stage, regionId);
            TournamentData data = null;
            if (matches.Count() > 0)
            {
                data = TransformMatchesToTournamentData(matches);
            }
            return Json(data);
        }

        private TournamentData TransformMatchesToTournamentData(IEnumerable<VMatch> matches)
        {
            var tournamentData = new TournamentData();
            tournamentData.group = new Group();
            var match = matches.First();
            tournamentData.TournamentId = match.TournamentId;
            tournamentData.Stage = match.Stage;
            tournamentData.group.RegionId = match.RegionId;
            tournamentData.group.name = match.Type;
            tournamentData.group.structureType = match.Type;

            tournamentData.group.rounds = matches
                    .Select(m => new Round { id = m.RoundId, name = m.Round }).Distinct().ToList();

            foreach (var round in tournamentData.group.rounds)
            {
                round.matches = matches.Where(m => m.RoundId == round.id)
                    .Select(m =>
                    new Match
                    {
                        id = m.SeqNo,
                        winner = m.WinnerTeam,
                        awayTeam = m.AwayTeam,
                        homeTeam = m.HomeTeam,
                        awayTeamResult = m.AwayTeamResult,
                        homeTeamResult = m.HomeTeamResult
                    }).ToList();
            }
            return tournamentData;
        }
        class TournamentData
        {
            public decimal TournamentId { get; set; }
            public byte Stage { get; set; }
            public Group group { get; set; }
        }
        class Group
        {
            public int RegionId { get; set; }
            public string name { get; set; }
            public string structureType { get; set; }
            public IEnumerable<Round> rounds { get; set; } = new List<Round>();
        }
        class Round
        {
            public string name { get; set; }
            public int id { get; set; }
            public IEnumerable<Match> matches { get; set; } = new List<Match>();
            public override bool Equals(object obj)
            {
                var o = obj as Round;
                if (o == null) return false;
                return o.id == id && o.name == name;
            }
            public override int GetHashCode()
            {
                return id ^ name.GetHashCode();
            }
        }
        class Match
        {
            public int id { get; set; }
            public string winner { get; set; }
            public string homeTeam { get; set; }
            public string awayTeam { get; set; }
            public int? homeTeamResult { get; set; }
            public int? awayTeamResult { get; set; }
        }
        //GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}