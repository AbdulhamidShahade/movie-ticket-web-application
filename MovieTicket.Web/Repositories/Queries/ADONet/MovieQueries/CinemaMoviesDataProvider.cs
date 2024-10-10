
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Settings;
using System.Data.SqlClient;

namespace MovieTicket.Web.Repositories.Queries.ADONet.MovieQueries
{
    public class CinemaMoviesDataProvider
    {
        public List<ReadMovieVM> GetMoviesByCinemaId(int id, int quantity)
        {
            List<ReadMovieVM> movies = new List<ReadMovieVM>();
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            string query = $"SELECT Top {quantity} * From Movies where cinemaId = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
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
                        PictureUrl = Convert.ToString(reader["PictureUrl"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        Length = Convert.ToInt16(reader["Length"]),
                    });
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return movies;
        }
    }
}
