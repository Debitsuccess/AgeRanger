using System;
using System.Web.Hosting;

namespace AgeRanger.Repository
{
    public class RepositoryBase
    {
        public bool IsDBNull(object DbObject)
        {
            if (DbObject == DBNull.Value)
            {
                return true;
            }
            return false;
        }

        public string GetServerPath()
        {
            //Testing
            //return "c:\\users\\user\\documents\\visual studio 2017\\Projects\\AgeRanger\\AgeRanger\\DataBase\\AgeRanger.db; Version = 3;";
            
            //Live
            return HostingEnvironment.MapPath("~") + "DataBase\\AgeRanger.db; Version = 3;";

        }
    }
}