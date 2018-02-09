using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uksl.DAL.EF;
using uksl.DAL.Interfaces;

namespace uksl.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private UkslContext db;
        //private BookRepository bookRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new UkslContext(connectionString);
        }
        //public IRepository<Book> Books
        //{
        //    get
        //    {
        //        if (bookRepository == null)
        //            bookRepository = new BookRepository(db);
        //        return bookRepository;
        //    }
        //}

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
