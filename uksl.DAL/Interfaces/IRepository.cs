using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uksl.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        List<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        bool CheckUniqueField(string fieldName, object fieldValue);
    }
    public static class RepoFabric
    {
        public static IRepository<T> Create<T>() where T : class
        {
            var repoClassName = "uksl.DAL.Repositories." + typeof(T).Name + "Repo`1"; ;
            Type generic = Type.GetType(repoClassName);
            Type constructedType = generic.MakeGenericType(typeof(T));
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return Activator.CreateInstance(constructedType, new object[] { connectionString }) as IRepository<T>;
        }
    }
}
