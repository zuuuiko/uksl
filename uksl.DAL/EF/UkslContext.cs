using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uksl.DAL.EF
{
    class UkslContext : DbContext
    {
        public UkslContext(string connectionString)
                : base(connectionString)
        {
        }
        //public virtual DbSet<Entities.Book> Books { get; set; }
    }
}
