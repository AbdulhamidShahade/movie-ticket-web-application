using MovieTicket.Web.Models.ViewModels.ActorVM;
using MovieTicket.Web.Settings;
using System.Data.SqlClient;

namespace MovieTicket.Web.Repositories.Queries.ADONet.ActorQueries
{
    public class CountryActorsDataProvider
    {
        public List<ReadActorVM> GetActorsByCountryId(int countryId, int quantity)
        {
            List<ReadActorVM> actors = new List<ReadActorVM>();

            SqlConnection conn = new SqlConnection(Global.ConnectionString);

            string query = $"SELECT top {quantity}* from Actors where CountryId = @countryId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@countryId", countryId);

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
            catch
            {
                conn.Close();
            }
            finally
            {
                conn.Close();
            }

            return actors;
        }
    }
}
