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
    public class PersonRepository : IPersonRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public bool CheckUniqueField(string fieldName, object fieldValue)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(fieldName, "^[a-zA-Z0-9]+$")) return false;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                var sql = "SELECT count(Id) FROM vPersons WHERE " + fieldName + " = @pFieldValue;";
                var count = db.QuerySingle<int>(sql, new { pFieldValue = fieldValue });
                return count == 0;
            }
        }
        public bool CheckUniqueField(string fieldName, object fieldValue, string aspId)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(fieldName, "^[a-zA-Z0-9]+$")) return false;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                var sql = "SELECT count(Id) FROM vPersons WHERE AspNetUserId <> @pAspId and " + fieldName + " = @pFieldValue;";
                var count = db.QuerySingle<int>(sql, new { pFieldValue = fieldValue, pAspId = aspId });
                return count == 0;
            }
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
        public Person Get(string aspId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                var sql = "SELECT * FROM vPersons WHERE AspNetUserId = @pAspNetUserId;";
                return db.QuerySingle<Person>(sql, new { pAspNetUserId = aspId });
            }
        }
        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }
        public void Update(Person item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                var sql = "UpdatePerson";
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
    }
}
