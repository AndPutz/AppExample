using AppExampleAPI.Models;
using System.Data.SqlClient;

namespace Infra
{
    public interface IGetParameters
    {
        public List<SqlParameter> GetEntityParameters(Entity entity);
    }
}
