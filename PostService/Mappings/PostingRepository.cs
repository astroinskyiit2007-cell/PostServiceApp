using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace DeliveryCalculator
{
    public class PostingRepository
    {
        private readonly string _connectionString = "Data Source=postings.db";

        public void CreateDb()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Postings (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Sender TEXT,
                        Recipient TEXT,
                        Weight REAL
                    );
                ";
                command.ExecuteNonQuery();
            }
        }

        public void Add(string sender, string recipient, double weight)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Postings (Sender, Recipient, Weight) VALUES (@sender, @recipient, @weight);";
                
                command.Parameters.AddWithValue("@sender", sender);
                command.Parameters.AddWithValue("@recipient", recipient);
                command.Parameters.AddWithValue("@weight", weight);
                
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Postings WHERE Id = @id;";
                command.Parameters.AddWithValue("@id", id);
                
                command.ExecuteNonQuery();
            }
        }
    }
}