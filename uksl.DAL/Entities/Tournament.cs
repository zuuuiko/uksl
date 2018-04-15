using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uksl.DAL.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? DisciplineId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
