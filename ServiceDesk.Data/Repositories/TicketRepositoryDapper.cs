using Dapper;
using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ServiceDesk.Data.Repositories
{
    public class TicketRepositoryDapper : ITicketsRepository
    {
        private readonly string _connectionString;
        public TicketRepositoryDapper()
        {
            _connectionString = @"Server=.;Initial Catalog = master; Integrated Security = true";
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "Insert INTO Tickets(Title,TypeId,Date,Description) OUTPUT Inserted.id " +
                    $"Values(\'{ticket.Title}\',\'{ticket.Department.id}\',\'{ticket.Date.ToString("s")}\',\'{ticket.Description}\')";
                var affectedRows = Convert.ToInt32(connection.ExecuteScalar(sql));
                ticket.id = affectedRows;

                return ticket;
            }
        }

        public bool DelById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
                try
                {
                    connection.Query<Ticket>($"DELETE FROM dbo.Tickets WHERE Tickets.Id={id}");
                    return true;
                }
                catch
                {
                    return false;
                }
                 
        }

        public IEnumerable<Ticket> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<Ticket>("SELECT * FROM CarWashers");
            }
        }
        public Ticket GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
                return connection.Query<Ticket>("SELECT * FROM dbo.Tickets WHERE Tickets.Id=@Id", new { Id = id }).FirstOrDefault();
        }
    }
}
