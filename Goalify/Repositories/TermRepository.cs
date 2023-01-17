using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using Goalify.Models;
using System;
using Goalify.Utils;

namespace Goalify.Repositories
{
    public class TermRepository
    {

        private readonly string _connectionString;
        public TermRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Terms> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Term
                        FROM terms";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var terms = new List<Terms>();
                        while (reader.Read())
                        {
                            terms.Add(new Terms()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Term = reader.GetString(reader.GetOrdinal("Term")),                                
                            });

                        }
                        reader.Close();
                        return terms;
                    }
                }
            }
        }

        public Terms Get(Terms term)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Term
                          FROM terms
                         WHERE Term = @term;";
                    cmd.Parameters.AddWithValue("@term", term);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        term = null;
                        if (reader.Read())
                        {
                            term = new Terms()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Term = DbUtils.GetString(reader, "Term"),                                

                            };

                        }
                        return term;
                    }
                }
            }
        }

        //public void Add(Terms term)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                        INSERT INTO Term (term)
        //                        OUTPUT INSERTED.ID
        //                        VALUES (@term)";
        //            cmd.Parameters.AddWithValue("@term", term.Term);


        //if (variety.Notes == null)
        //    {
        //        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
        //    }
        //    else
        //    {
        //        cmd.Parameters.AddWithValue("@notes", variety.Notes);
        //    }

        //            term.Id = (int)cmd.ExecuteScalar();
        //        }
        //    }
        //}

        //public void Update(Terms term)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                    UPDATE Terms 
        //                       SET  = Id = @Id,
        //                              term = @term                                  
        //                     WHERE Id = @id";
        //            cmd.Parameters.AddWithValue("@id", term.Id);
        //            cmd.Parameters.AddWithValue("@term", term.Term);


        //if (variety.Notes == null)
        //{
        //    cmd.Parameters.AddWithValue("@notes", DBNull.Value);
        //}
        //else
        //{
        //    cmd.Parameters.AddWithValue("@notes", variety.Notes);
        //}

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void Delete(int id)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = "DELETE FROM Goals WHERE Id = @id";
        //            cmd.Parameters.AddWithValue("@id", id);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

    }
}

