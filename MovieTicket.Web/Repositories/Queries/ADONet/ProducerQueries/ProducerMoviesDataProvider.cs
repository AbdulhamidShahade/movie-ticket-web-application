
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Settings;
using System.Data.SqlClient;

namespace MovieTicketWebApplication.Repositories.Queries.ADONet.ProducerQueries
{
    public class ProducerMoviesDataProvider
    {
        public List<ReadMovieVM> GetMoviesByProducerId(int producerId, int quantity)
        {
            List<ReadMovieVM> movies = new List<ReadMovieVM>();
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
                        StartDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["StartDate"])),
                        EndDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["EndDate"]))
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
            return movies;
        }
    }
}
