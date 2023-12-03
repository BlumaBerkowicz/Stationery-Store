using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AdoNetContext _AdoNetContext;
        public RatingRepository(AdoNetContext AdoNetContext)
        {
            _AdoNetContext = AdoNetContext;
        }
        public async Task Post(Rating rating)
        {
            string queryString = "INSERT INTO Rating(categoryId,name,price,description,image)" +
                    "VALUES(@categoryId,@name,@price,@description,@image)";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
                command.Parameters.Add("@description", SqlDbType.VarChar, 200).Value = description;
                command.Parameters.Add("@image", SqlDbType.VarChar, 50).Value = image;
                command.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                command.Parameters.Add("@price", SqlDbType.Int).Value = price;
                connection.Open();
                int rowsAffect = command.ExecuteNonQuery();
                return rowsAffect;
            }
        }
    }
}
