using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.ActorVM;
using MovieTicket.Web.Settings;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MovieTicket.Web.Repositories.Queries.ADONet.ActorQueries
{
    public class MovieActorsDataProvider
    {
        public List<ReadActorVM> GetActorsByMovieId(int movieId, int quantity, string Provider)
        {
            List<ReadActorVM> actors = new List<ReadActorVM>();

            if(Provider == "SQL")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);

                string query = $"SELECT top {quantity} * from Actors a inner join MoviesActors ma on (a.Id = ma.ActorId) where MovieId = @movieId";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        actors.Add(new ReadActorVM()
                        {
                            Id = Convert.ToInt16(reader["Id"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                            Bio = Convert.ToString(reader["Bio"]),
                            PictureUrl = Convert.ToString(reader["PictureUrl"]),
                            CountryId = Convert.ToInt16(reader["CountryId"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                        });
                    }

                    reader.Close();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(Global.ConnectionString);

                string query = $"SELECT * From Actors a inner join MoviesActors ma on(a.Id = ma.ActorId) where ma.MovieId = @movieId LIMIT {quantity}";
            
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        actors.Add(new ReadActorVM()
                        {
                            Id = Convert.ToInt16(reader["Id"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                            Bio = Convert.ToString(reader["Bio"]),
                            PictureUrl = Convert.ToString(reader["PictureUrl"]),
                            CountryId = Convert.ToInt16(reader["CountryId"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                        });
                    }

                    reader.Close();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }

            }

            return actors;
        }
    }
}
