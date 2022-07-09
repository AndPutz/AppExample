using AppExampleAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace Infra
{
    public class GetObjectParametersBase : IGetParameters
    {
        protected List<SqlParameter> sqlParameters;
        protected ObjectTab table;

        public GetObjectParametersBase()
        {
            sqlParameters = new List<SqlParameter>();            
        }

        public List<SqlParameter> GetEntityParameters(Entity entity)
        {
            if (sqlParameters == null)
                sqlParameters = new List<SqlParameter>();

            table = (ObjectTab)entity;

            sqlParameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar) { Value = table.Name });
            sqlParameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.VarChar) { Value = table.Description });
            sqlParameters.Add(new SqlParameter("@TYPE_ID", SqlDbType.Int) { Value = table.Type.Id });

            return sqlParameters;
        }
        
    }
}
