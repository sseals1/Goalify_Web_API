﻿using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using Goalify.Models;
using System;
using Goalify.Utils;

namespace Goalify.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        private readonly string _connectionString;
        public UsersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Users> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, Email, Address
                        FROM Users";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var users = new List<Users>();
                        while (reader.Read())
                        {
                            var user = new Users()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Address = reader.GetString(reader.GetOrdinal("Address"))
                            };

                        }

                        return users;
                    }
                }
            }
        }

        public Users Get(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Name, Email, Address
                          FROM Users
                         WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Users user = null;
                        if (reader.Read())
                        {
                            user = new Users()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                Address = DbUtils.GetString(reader, "Address"),

                            };

                        }
                        return user;
                    }
                }
            }
        }

        //    public void Add(Goals goal)
        //    {
        //        using (var conn = Connection)
        //        {
        //            conn.Open();
        //            using (var cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = @"
        //                    INSERT INTO Goal (userId,categoryId, priorityId, termId, milestoneId, goalDescription, goalObjectives, notes, date)
        //                    OUTPUT INSERTED.ID
        //                    VALUES (@userId, @categoryId, @priorityId, @termId, @milestoneId, @goalDescription, @notes, @date)";
        //                cmd.Parameters.AddWithValue("@userId", goal.UserId);
        //                cmd.Parameters.AddWithValue("@categoryId", goal.CategoryId);
        //                cmd.Parameters.AddWithValue("@priorityId", goal.PriorityId);
        //                cmd.Parameters.AddWithValue("@termId", goal.TermId);
        //                cmd.Parameters.AddWithValue("@milestoneId", goal.MilestoneId);
        //                cmd.Parameters.AddWithValue("@goalDescription", goal.GoalDescription);
        //                cmd.Parameters.AddWithValue("@notes", goal.Notes);
        //                cmd.Parameters.AddWithValue("@date", goal.Date);

        //                //if (variety.Notes == null)
        //                //    {
        //                //        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
        //                //    }
        //                //    else
        //                //    {
        //                //        cmd.Parameters.AddWithValue("@notes", variety.Notes);
        //                //    }

        //                goal.Id = (int)cmd.ExecuteScalar();
        //            }
        //        }
        //    }

        //    public void Update(Goals goal)
        //    {
        //        using (var conn = Connection)
        //        {
        //            conn.Open();
        //            using (var cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = @"
        //                    UPDATE Goals 
        //                       SET  = userId = @userId,
        //                              categoryId = @categoryId,
        //                              priorityId = @priorityId, 
        //                              termId = @termId, 
        //                              milestoneId = @milestoneId, 
        //                              goalDescription = @goalDescription, 
        //                              goalObjectives = @goalObjectives, 
        //                              notes = @notes, 
        //                              date = @dates
        //                     WHERE Id = @id";
        //                cmd.Parameters.AddWithValue("@userId", goal.UserId);
        //                cmd.Parameters.AddWithValue("@categoryId", goal.CategoryId);
        //                cmd.Parameters.AddWithValue("@priorityId", goal.PriorityId);
        //                cmd.Parameters.AddWithValue("@termId", goal.TermId);
        //                cmd.Parameters.AddWithValue("@milestoneId", goal.MilestoneId);
        //                cmd.Parameters.AddWithValue("@goalDescription", goal.GoalDescription);
        //                cmd.Parameters.AddWithValue("@notes", goal.Notes);
        //                cmd.Parameters.AddWithValue("@date", goal.Date);
        //                //if (variety.Notes == null)
        //                //{
        //                //    cmd.Parameters.AddWithValue("@notes", DBNull.Value);
        //                //}
        //                //else
        //                //{
        //                //    cmd.Parameters.AddWithValue("@notes", variety.Notes);
        //                //}

        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }

        //    public void Delete(int id)
        //    {
        //        using (var conn = Connection)
        //        {
        //            conn.Open();
        //            using (var cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = "DELETE FROM Goals WHERE Id = @id";
        //                cmd.Parameters.AddWithValue("@id", id);

        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }

    }
}

