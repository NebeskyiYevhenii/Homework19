using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ServiceDesk.Data.Repositories
{
    public class TicketRepositoryDB : ITicketsRepository
    {
        private readonly string _connectionString;
        public TicketRepositoryDB()
        {
            _connectionString = @"Server=.;Initial Catalog = master; Integrated Security = true";
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                var ret = command.CommandText = "Insert INTO Tickets(Title,Type,Date,Description) OUTPUT Inserted.id " +
                    $"Values(\'{ticket.Title}\',\'{ticket.Type}\',\'{ticket.Date.ToString("s")}\',\'{ticket.Description}\')";
                var id = Convert.ToInt32(command.ExecuteScalar());

                ticket.Id = id;

                return ticket;
            }
        }
        public IEnumerable<Ticket> GetAll()
        {
            var rezult = new List<Ticket>();
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                var ret = command.CommandText = "Select * FROM Tickets";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var carWash = new Ticket();

                    carWash.Id = reader.GetInt32(0);
                    carWash.Title = reader.GetString(1);
                    carWash.Type = reader.GetString(2);
                    carWash.Date = reader.GetDateTime(3);
                    carWash.Description = reader.GetString(4);

                    rezult.Add(carWash);
                }
                reader.Close();
                return rezult;
            }
        }
        public Ticket GetById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            using (connection)
            {
                connection.Open();
                var ticket = new Ticket();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                var ret = command.CommandText = $"SELECT  Tickets.* FROM dbo.Tickets WHERE Tickets.Id = {id}";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ticket.Id = reader.GetInt32(0);
                    ticket.Title = reader.GetString(1);
                    ticket.Type = reader.GetString(2);
                    ticket.Date = reader.GetDateTime(3);
                    ticket.Description = reader.GetString(4);
                }
                reader.Close();
                return ticket;
            }
        }
    }
}
