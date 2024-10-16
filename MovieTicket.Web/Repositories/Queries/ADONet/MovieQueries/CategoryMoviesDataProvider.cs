
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Settings;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MovieTicket.Web.Repositories.Queries.ADONet.MovieQueries
{
    public class CategoryMoviesDataProvider
    {
        public List<ReadMovieVM> GetMoviesByCategoryId(int categoryId, int quantity, string Provider)
        {
            List<ReadMovieVM> moviesViewModel = new List<ReadMovieVM>();

            if(Provider == "SQL")
            {
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
                string query = $"SELECT * from Movies m inner join MoviesCategories mc on(m.Id = mc.MovieId) where CategoryId = @categoryId LIMIT {quantity}";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
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
            return moviesViewModel;
        }
    }
}
