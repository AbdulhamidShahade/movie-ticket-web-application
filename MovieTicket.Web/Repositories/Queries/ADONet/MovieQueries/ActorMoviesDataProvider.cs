using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Settings;
using System.Data.SqlClient;

namespace MovieTicketWebApplication.Repositories.Queries.ADONet.ActorQueries
{
    public class ActorMoviesDataProvider
    {
        public List<ReadMovieVM> GetMoviesByActorId(int actorId, int quantity)
        {
            List<ReadMovieVM> movies = new List<ReadMovieVM>();
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            string query = $"SELECT top {quantity} * from Movies m inner join MoviesActors ma on (m.id = ma.movieId) where ma.actorId = @actorId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@actorId", actorId);
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
            return movies;
        }
    }
}
