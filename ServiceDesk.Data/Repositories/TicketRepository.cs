﻿using ServiceDesk.Data.Interfaces;
using ServiceDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ServiceDesk.Data.Repositories
{
    public class TicketRepository : ITicketsRepository
    {
        private readonly string _connectionString;
        public TicketRepository()
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
                var ret = command.CommandText = "Insert INTO Tickets(Title,DepartmentId,Date,Description) OUTPUT Inserted.id " +
                    $"Values(\'{ticket.Title}\',\'{ticket.Department.id}\',\'{ticket.Date.ToString("s")}\',\'{ticket.Description}\')";
                var id = Convert.ToInt32(command.ExecuteScalar());

                ticket.id = id;

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

                    carWash.id = reader.GetInt32(0);
                    carWash.Title = reader.GetString(1);
                    //carWash.DepartmentId = reader.GetInt32(2);
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
                    ticket.id = reader.GetInt32(0);
                    ticket.Title = reader.GetString(1);
                    //ticket.DepartmentId = reader.GetInt32(2);
                    ticket.Date = reader.GetDateTime(3);
                    ticket.Description = reader.GetString(4);
                }
                reader.Close();
                return ticket;
            }
        }
        public bool DelById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                using (connection)
                {
                    connection.Open();
                    var ticket = new Ticket();
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    var ret = command.CommandText = $"DELETE FROM dbo.Tickets WHERE Tickets.Id={id}";

                    return true;
                }
            }
            catch
            {
                return false;
            }


        }
    }
}
