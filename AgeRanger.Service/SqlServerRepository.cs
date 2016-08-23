using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using AgeRanger.Logic;
using Entities;



namespace AgeRanger.Service
{
    public class SqlServerRepository : IDataBaseCommonFactory
    {
        //TODO: This can be taken from the config
        private string _conn = @"SQLCONN_String";

        public List<AgeGroup> GetAllAgeGroups()
        {
            List<AgeGroup> ageGroupList = new List<AgeGroup>();
            try
            {
                using (var conn = new SqlConnection(_conn))
                using (var cmd = new SqlCommand("dbo.GetAllAgeGroups", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ageGroupList.Add(new AgeGroup()
                            {
                                MinAge = (int)reader["MinAge"],
                                MaxAge = (int)reader["MaxAge"],
                                AgeGroupDescription = (string)reader["Description"]
                            });
                        }
                    }
                }
                return ageGroupList;
            }
            catch (Exception ex)
            {
                //TODO: Can be logged
                throw new Exception(ex.Message);
            }
        }

        public List<Person> GetAllPersons()
        {
            List<Person> PersonList = new List<Person>();
            try
            {
                using (var conn = new SqlConnection(_conn))
                using (var cmd = new SqlCommand("dbo.GetAllPersons", conn))
                {
                    conn.Open();
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PersonList.Add(new Person()
                                {
                                    Id = (int)reader["Id"],
                                    FirstName = (string)reader["FirstName"],
                                    LastName = (string)reader["LastName"],
                                    Age = (int)reader["Age"]
                                });
                            }
                        }
                    }
                }
                return PersonList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Person GetPersonById(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_conn))
                using (var cmd = new SqlCommand("dbo.GetPersonById", conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return new Person()
                            {
                                Id = id,
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Age = (int)reader["Age"]
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SavePerson(Person person)
        {
            try
            {
                //This stored proc can be written to handle both insert and update with MERGE INTO...
                using (var conn = new SqlConnection(_conn))
                using (var cmd = new SqlCommand("dbo.InsertUpdatePerson", conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", person.Id);
                    cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", person.LastName);
                    cmd.Parameters.AddWithValue("@Age", person.Age);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
