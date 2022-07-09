using AppExampleAPI.Models;

namespace AppExampleAPI.Business
{
    public abstract class BusinessBase
    {
        protected string connectionString;

        public abstract Task<Entity> CreateObject(IConfiguration config, Entity entity);


    }
}
