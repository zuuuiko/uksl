using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uksl.DAL.Entities;
using uksl.Models;

namespace uksl.App_Code.Utils
{
    public static class Mapper
    {
        public static Person ToPerson(RegisterViewModel obj, string aspUserId) => new Person
        {
            AspNetUserId = aspUserId,
            FName = obj.FirstName,
            LName = obj.LastName,
            MName = obj.MiddleName,
            NickName = obj.NickName,
            BirthDate = obj.BirthDate,
            UniversityId = obj.UniversityId
        };
    }
}