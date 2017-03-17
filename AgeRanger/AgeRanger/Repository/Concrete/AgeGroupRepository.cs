using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using AgeRanger.Models;

namespace AgeRanger.Repository
{
    public class AgeGroupRepository :RepositoryBase, IAgeGroupRepository
    {
        public List<AgeGroupModel> GetAllAgeGroups()
        {
            List<AgeGroupModel> allAgeGroup = new List<AgeGroupModel>();
            var connection = new SQLiteConnection("Data Source=" + GetServerPath());
            connection.Open();

            string selectSQL = "SELECT * FROM AgeGroup";
            SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, connection);

            SQLiteDataReader dataReader = selectCommand.ExecuteReader();

            while (dataReader.Read())
            {
                var AgeGroupModel = new AgeGroupModel();


                if (!IsDBNull(dataReader.GetValue(0)))
                {
                    AgeGroupModel.Id = Convert.ToInt32(dataReader.GetValue(0));
                }

                if (!IsDBNull(dataReader.GetValue(1)))
                {
                    AgeGroupModel.MinAge = Convert.ToInt32(dataReader.GetValue(1));
                }
                else {
                    AgeGroupModel.MinAge = null;
                }


                if (!IsDBNull(dataReader.GetValue(2)))
                {
                    AgeGroupModel.MaxAge = Convert.ToInt32(dataReader.GetValue(2));
                }
                else
                {
                    AgeGroupModel.MaxAge = null;
                }

                if (!IsDBNull(dataReader.GetValue(3)))
                {
                    AgeGroupModel.Description = dataReader.GetValue(2).ToString();
                }

                allAgeGroup.Add(AgeGroupModel);
            }

            return allAgeGroup;

        }
    }
}