
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Settings;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MovieTicket.Web.Repositories.Queries.ADONet.MovieQueries
{
    public class ProducerMoviesDataProvider
    {
        public List<ReadMovieVM> GetMoviesByProducerId(int producerId, int quantity, string provider)
        {
            List<ReadMovieVM> movies = new List<ReadMovieVM>();

            if(provider == "SQL")
            {
                SqlConnection conn = new SqlConnection(Global.ConnectionString);
                string query = $"SELECT top {quantity} * from Movies m inner join MoviesProducers mp on (m.id = mp.movieId) where mp.producerId = @producerId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@producerId", producerId);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        movies.Add(new ReadMovieVM
                        {
                            Id = Convert.ToInt16(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),
                            Description = Convert.ToString(reader["Description"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Length = Convert.ToInt16(reader["Length"]),
                            PictureUrl = Convert.ToString(reader["PictureUrl"]),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"])
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
                string query = $"SELECT * from Movies m inner join MoviesProducers mp on(m.Id = mp.MovieId) where ProducerId = @producerId LIMIT {quantity}";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@producerId", producerId);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        movies.Add(new ReadMovieVM
                        {
                            Id = Convert.ToInt16(reader["Id"]),
                            Name = Convert.ToString(reader["Name"]),
                            Description = Convert.ToString(reader["Description"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Length = Convert.ToInt16(reader["Length"]),
                            PictureUrl = Convert.ToString(reader["PictureUrl"]),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"])
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
            
            return movies;
        }
    }
}
