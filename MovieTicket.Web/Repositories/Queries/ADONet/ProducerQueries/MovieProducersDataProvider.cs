using MovieTicket.Web.Models.ViewModels.ProducerVM;
using MovieTicket.Web.Settings;
using System.Data.SqlClient;

namespace MovieTicket.Web.Repositories.Queries.ADONet.ProducerQueries
{
    public class MovieProducersDataProvider
    {
        public List<ReadProducerVM> GetProducersByMovieId(int movieId, int quantity)
        {
            List<ReadProducerVM> producers = new List<ReadProducerVM>();
            SqlConnection conn = new SqlConnection(Global.ConnectionString);

            string query = $"SELECT top {quantity} * from Producers p inner join MoviesProducers mp on(p.Id = mp.ProducerId) where MovieId = @movieId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@movieId", movieId);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    producers.Add(new ReadProducerVM
                    {
                        Id = Convert.ToInt16(reader["Id"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        Bio = Convert.ToString(reader["Bio"]),
                        PictureUrl = Convert.ToString(reader["PictureUrl"]),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        CountryId = Convert.ToInt16(reader["CountryId"])
                    });
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
            finally { conn.Close(); }

            return producers;
        }
    }
}
