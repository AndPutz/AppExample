using AppExampleAPI.Interfaces;
using AppExampleAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AppExampleAPI.Rules
{
    public class ObjectBusiness
    {
        public async Task<ObjectTab> CreateObject(IConfiguration config, ObjectTab objectTab)
        {

            List<SqlParameter> sqlParameters = GetObjectParameters(objectTab);

            string connectionString = Microsoft
                                       .Extensions
                                       .Configuration
                                       .ConfigurationExtensions
                                       .GetConnectionString(config, "DevDB");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "PR_OBJECT_API_INS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(sqlParameters.ToArray());

            await cmd.ExecuteNonQueryAsync();

            long ObjectId = (long)(cmd.Parameters[cmd.Parameters.Count - 1].Value);

            objectTab.ID = ObjectId;

            return objectTab;
        }

        private List<SqlParameter> GetObjectParameters(ObjectTab objectTab)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar) { Value = objectTab.Name });
            sqlParameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.VarChar) { Value = objectTab.Description });
            sqlParameters.Add(new SqlParameter("@TYPE_ID", SqlDbType.Int) { Value = objectTab.Type.Id });
            sqlParameters.Add(new SqlParameter("@ID", SqlDbType.BigInt) { Direction = ParameterDirection.Output });

            return sqlParameters;
        }
    }
}
