using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uksl.DAL.Interfaces
{
    public interface IPersonRepository:IRepository<Entities.Person>
    {
        bool CheckUniqueField(string fieldName, object fieldValue);
        bool CheckUniqueField(string fieldName, object fieldValue, string aspId);
    }
}
