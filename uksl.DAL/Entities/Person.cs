using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uksl.DAL.Entities
{
    public class Person
    {
        public string AspNetUserId { get; set; }
        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string NickName { get; set; }
        public int? UniversityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
