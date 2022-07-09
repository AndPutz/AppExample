using AppExampleAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace Infra
{
    public class GetObjectParameters : GetObjectParametersBase
    {       
        new List<SqlParameter> GetEntityParameters(Entity entity)
        {
            base.GetEntityParameters(entity);
                   
            sqlParameters.Add(new SqlParameter("@ID", SqlDbType.BigInt) { Value = entity.Id });

            return sqlParameters;
        }
    }
}
