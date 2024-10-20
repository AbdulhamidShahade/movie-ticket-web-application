using MovieTicket.Web.Models.ViewModels.CategoryVM;
using MovieTicket.Web.Settings;
using System.Data.SqlClient;

namespace MovieTicket.Web.Repositories.Queries.ADONet.CategoryQueries
{
    public class MovieCategoriesDataProvider
    {
        public List<ReadCategoryVM> GetCategoriesByMovieId(int movieId, int quantity, string Provider)
        {
            List<ReadCategoryVM> categories = new List<ReadCategoryVM>();

            SqlConnection conn = new SqlConnection(Global.ConnectionString);

            string query = $"SELECT top {quantity} * from Categories c inner join MoviesCategories mc on (c.Id = mc.CategoryId) where MovieId = @movieId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@movieId", movieId);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new ReadCategoryVM()
                    {
                        Id = Convert.ToInt16(reader["Id"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        PictureUrl = Convert.ToString(reader["PictureUrl"]),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
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

            return categories;
        }
    }
}
