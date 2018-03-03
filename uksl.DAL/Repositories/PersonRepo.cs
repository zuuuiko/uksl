using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uksl.DAL.Entities;
using uksl.DAL.Interfaces;

namespace uksl.DAL.Repositories
{
    class PersonRepo : IRepository<Person>
    {
        private readonly string connectionString;

        public PersonRepo(string connStr)
        {
            connectionString = connStr;
        }

        public bool CheckUniqueField(string fieldName, object fieldValue)
        {
            return true;
        }

        public void Create(Person item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                var sql = "CreatePerson";
                db.Execute(sql,
                    new
                    {
                        pAspNetUserId = item.AspNetUserId,
                        pFName = item.FName,
                        pLName = item.LName,
                        pMName = item.MName,
                        pNickName = item.NickName,
                        pBirthDate = item.BirthDate,
                        pUniversityId = item.UniversityId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> Find(Func<Person, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
