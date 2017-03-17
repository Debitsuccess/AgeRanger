using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using AgeRanger.Models;

namespace AgeRanger.Repository
{
    public class PersonRepository: RepositoryBase, IPersonRepository
    {

        public async Task<bool> UpdatePerson(PersonModel person)
        {

            var connection = new SQLiteConnection("Data Source=" + GetServerPath());
            connection.Open();

            string selectSQL = "update Person set FirstName = @FirstName,  LastName = @LastName, Age = @Age where Person.ID = @Id ";
            SQLiteCommand cmd = new SQLiteCommand(selectSQL, connection);
            cmd.Parameters.AddWithValue("@Id", person.Id);
            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", person.LastName);
            cmd.Parameters.AddWithValue("@Age", person.Age);

            await cmd.ExecuteNonQueryAsync();
            connection.Close();


            return true;

        }

        public async Task<PersonModel> GetPerson(int Id)
        {
            PersonModel person = new PersonModel();
            var connection = new SQLiteConnection("Data Source=" + GetServerPath());
            connection.Open();

            string selectSQL = "SELECT * FROM Person p where p.ID = @Id ";
            SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, connection);
            selectCommand.Parameters.AddWithValue("@Id", Id);

            SQLiteDataReader dataReader = await selectCommand.ExecuteReaderAsync() as SQLiteDataReader;
            while (dataReader.Read())
            {

                person.Id = Convert.ToInt32(dataReader.GetValue(0));
                person.FirstName = dataReader.GetValue(1).ToString();
                person.LastName = dataReader.GetValue(2).ToString();
                person.Age = Convert.ToInt32(dataReader.GetValue(3));
                
            }

            connection.Close();
            return person;
        }
        public async Task<List<PersonModel>> GetAllPeople()
        {
            List<PersonModel> allPeople = new List<PersonModel>();
            var connection = new SQLiteConnection("Data Source=" + GetServerPath());
            connection.Open();

            string selectSQL = "SELECT * FROM Person";
            SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, connection);

            SQLiteDataReader dataReader = await selectCommand.ExecuteReaderAsync() as SQLiteDataReader;

            while (dataReader.Read())
            {
                allPeople.Add( new PersonModel
                {
                    Id = Convert.ToInt32(dataReader.GetValue(0)),
                    FirstName = dataReader.GetValue(1).ToString(),
                    LastName = dataReader.GetValue(2).ToString(),
                    Age = Convert.ToInt32(dataReader.GetValue(3)),
                });
            }

            connection.Close();
            return allPeople;
        }

        public async Task<List<PersonModel>> SearchPeople(string searchText)
        {
            List<PersonModel> allPeople = new List<PersonModel>();
            var connection = new SQLiteConnection("Data Source=" + GetServerPath());

            connection.Open();

            string selectSQL = "SELECT * FROM Person p where p.FirstName like @searchText or p.LastName like @searchText";
            SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, connection);
            selectCommand.Parameters.AddWithValue("@searchText", searchText + "%");

            SQLiteDataReader dataReader = await selectCommand.ExecuteReaderAsync() as SQLiteDataReader;

            while (dataReader.Read())
            {
                allPeople.Add(new PersonModel
                {
                    Id = Convert.ToInt32(dataReader.GetValue(0)),
                    FirstName = dataReader.GetValue(1).ToString(),
                    LastName = dataReader.GetValue(2).ToString(),
                    Age = Convert.ToInt32(dataReader.GetValue(3)),
                });
            }

            connection.Close();
            return allPeople;
        }

        public async Task AddPerson(PersonModel person)
        {
            var connection = new SQLiteConnection("Data Source=" + GetServerPath());
            connection.Open();

            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO Person (FirstName, LastName, Age ) VALUES (@FirstName, @LastName, @Age)", connection);

            insertSQL.Parameters.AddWithValue("@FirstName", person.FirstName);
            insertSQL.Parameters.AddWithValue("@LastName", person.LastName);
            insertSQL.Parameters.AddWithValue("@Age", person.Age);

            await insertSQL.ExecuteNonQueryAsync();
            connection.Close();

        }

        public async Task DeleteAllUsers()
        {
            var connection = new SQLiteConnection("Data Source=" + GetServerPath());
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand("delete from Person", connection);

            await cmd.ExecuteNonQueryAsync();

            connection.Close();
        }
    }
}