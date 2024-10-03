
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Settings;
using System.Data.SqlClient;

namespace MovieTicketWebApplication.Repositories.Queries.ADONet.CategoryQueries
{
    public class CategoryMoviesDataProvider
    {
        public List<ReadMovieVM> GetMoviesByCategoryId(int categoryId, int quantity)
        {
            List<ReadMovieVM> moviesViewModel = new List<ReadMovieVM>();
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            string query = $"SELECT top {quantity} * from Movies m inner join MoviesCategories mc on (m.Id = mc.MovieId) where mc.categoryId = @categoryId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@categoryId", categoryId);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    moviesViewModel.Add(new ReadMovieVM()
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
            return moviesViewModel;
        }
    }
}
