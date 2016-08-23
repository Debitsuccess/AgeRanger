using AgeRanger.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SQLite;

namespace AgeRanger.Service
{
    public class SqlightRepository : IDataBaseCommonFactory
    {
        //TODO: This can be moved to the config
        private string _conn = @"Data Source = G:\Example\AgeRanger-master\AgeRanger.db; Version=3;";

        public List<AgeGroup> GetAllAgeGroups()
        {
            List<AgeGroup> ageGroupList = new List<AgeGroup>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(_conn))
                {
                    conn.Open();
                    string sql = "SELECT MinAge, MaxAge, Description FROM AgeGroup";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
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
                }
                return ageGroupList;
            }
            catch (SQLiteException ex)
            {
                //TODO: This can be logged
                throw new Exception(ex.Message);
            }
        }

        public List<Person> GetAllPersons()
        {
            List<Person> PersonList = new List<Person>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(_conn))
                {
                    conn.Open();
                    string sql = "SELECT Id, FirstName, LastName FROM Person";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
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
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Person GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public void SavePerson(Person person)
        {
            if (person.Id == 0)
                InsertPerson(person);
            else
                UpdatePerson(person);
        }

        private void InsertPerson (Person person)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(_conn))
                {
                    conn.Open();
                    var sql = "INSERT INTO Person (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", person.LastName);
                        cmd.Parameters.AddWithValue("@Age", person.Age);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void UpdatePerson (Person person)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(_conn))
                {
                    conn.Open();
                    var sql = "UPDATE Person "
                            + "SET FirstName = @FirstName "
                            + ", LastName = @LastName "
                            + ", Age = @Age "
                            + "WHERE Id = @Id";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", person.LastName);
                        cmd.Parameters.AddWithValue("@Age", person.Age);
                        cmd.Parameters.AddWithValue("@Id", person.Id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
