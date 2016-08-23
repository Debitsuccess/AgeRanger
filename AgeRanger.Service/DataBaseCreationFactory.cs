using AgeRanger.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Service
{
    public class DataBaseCreationFactory
    {
        public IDataBaseCommonFactory GetInstance(string DatabaseType)
        {
            switch (DatabaseType)
            {
                case "SQL":
                    return new SqlServerRepository();
                case "SQLIGHT":
                    return new SqlightRepository();
                default:
                    return new SqlightRepository();
            }
        }
    }
}

