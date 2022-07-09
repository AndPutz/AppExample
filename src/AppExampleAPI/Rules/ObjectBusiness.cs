using AppExampleAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Infra;

namespace AppExampleAPI.Rules
{
    public class ObjectBusiness : Business.BusinessBase
    {

        public override async Task<Entity> CreateObject(IConfiguration config, Entity entity)
        {
            GetInsertObjectParameters insertObjectParameters = new GetInsertObjectParameters();

            List<SqlParameter> sqlParameters = insertObjectParameters.GetEntityParameters(entity);

            SetConnectionString(config);

            entity.Id = await dbFactory.Instance.Insert(connectionString, "PR_OBJECT_API_INS", sqlParameters);

            return entity;
        }
       

        public async Task<Entity> UpdateObject(IConfiguration config, Entity entity)
        {
            GetObjectParameters objectParameters = new GetObjectParameters();
            List<SqlParameter> sqlParameters = objectParameters.GetEntityParameters(entity);

            SetConnectionString(config);

            await dbFactory.Instance.ExecuteNonQueryAsync(connectionString, "PR_OBJECT_API_UPD", sqlParameters);

            return entity;
        }

        public async Task<ObjectTab> DeleteObject(IConfiguration config, long ID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>() { new SqlParameter("@ID", SqlDbType.BigInt) { Value = ID } };

            SetConnectionString(config);

            await dbFactory.Instance.ExecuteNonQueryAsync(connectionString, "PR_OBJECT_API_DEL", sqlParameters);

            return new ObjectTab();
        }

        public async Task<ObjectTabList> SelectAllObjects(IConfiguration config)
        {
            ObjectTabList objects = new();

            SetConnectionString(config);

            SqlDataReader reader = await dbFactory.Instance.ExecuteSelect(connectionString, "PR_OBJECT_API_SEL", new List<SqlParameter>());

            while(reader.Read())
            {
                objects.Add(new ObjectTab()
                {
                    Id = (long)reader["ID"],
                    Description = reader["DESCRIPTION"].ToString(),
                    Name = reader["NAME"].ToString(),
                    Type = new TypeTab() { Id = (int)reader["TYPE_ID"], Description = reader["TYPE_DESCRIPTION"].ToString() }
                });

            }

            dbFactory.Instance.CloseConnection();

            return objects;
        }

        public async Task<ObjectTabList> SelectObjectsByName(IConfiguration config, string Name)
        {
            ObjectTabList objects = new();

            SetConnectionString(config);

            SqlDataReader reader = await dbFactory.Instance.ExecuteSelect(connectionString, "PR_OBJECT_API_SEL_BYNAME", sqlParameters: new List<SqlParameter>() 
            { 
                new SqlParameter("@NAME", SqlDbType.VarChar) { Value = Name, Size = 50 } 
            });

            while (reader.Read())
            {
                objects.Add(new ObjectTab()
                {
                    Id = (long)reader["ID"],
                    Description = reader["DESCRIPTION"].ToString(),
                    Name = reader["NAME"].ToString(),
                    Type = new TypeTab() { Id = (int)reader["TYPE_ID"], Description = reader["TYPE_DESCRIPTION"].ToString() }
                });

            }

            dbFactory.Instance.CloseConnection();

            return objects;
        }

        public async Task<ObjectTab> SelectObjectsById(IConfiguration config, long Id)
        {
            ObjectTab objectItem = new();

            SetConnectionString(config);

            SqlDataReader reader = await dbFactory.Instance.ExecuteSelect(connectionString, "PR_OBJECT_API_SEL_BYID", sqlParameters: new List<SqlParameter>()
            {
                new SqlParameter("@ID", SqlDbType.BigInt) { Value = Id }
            });

            if (reader.Read())
            {
                objectItem.Id = (long)reader["ID"];
                objectItem.Name = reader["NAME"].ToString();
                objectItem.Description = reader["DESCRIPTION"].ToString();
                objectItem.Type = new TypeTab() { Id = (int)reader["TYPE_ID"], Description = reader["TYPE_DESCRIPTION"].ToString() };              
            }

            dbFactory.Instance.CloseConnection();

            return objectItem;
        }

        public async Task<List<string>> SelectObjectsNameAutoComplete(IConfiguration config, string Name)
        {
            List<string> listReturn = new();

            SetConnectionString(config);

            SqlDataReader reader = await dbFactory.Instance.ExecuteSelect(connectionString, "PR_OBJECT_API_SEL_AUTOCOMP", sqlParameters: new List<SqlParameter>()
            {
                new SqlParameter("@NAME", SqlDbType.VarChar) { Value = Name, Size = 50 }
            });

            while (reader.Read())
            {
                listReturn.Add(reader[0].ToString());
            }

            dbFactory.Instance.CloseConnection();

            return listReturn;
        }

        private void SetConnectionString(IConfiguration config)
        {
            if(string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = Microsoft
                                       .Extensions
                                       .Configuration
                                       .ConfigurationExtensions
                                       .GetConnectionString(config, "DevDB");
            }
        }

        private List<SqlParameter> GetObjectParameters(Entity entity, bool inserted)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            ObjectTab tab = (ObjectTab)entity;

            sqlParameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar) { Value = tab.Name });
            sqlParameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.VarChar) { Value = tab.Description });
            sqlParameters.Add(new SqlParameter("@TYPE_ID", SqlDbType.Int) { Value = tab.Type.Id });
            if (inserted)
                sqlParameters.Add(new SqlParameter("@ID", SqlDbType.BigInt) { Direction = ParameterDirection.Output });
            else
                sqlParameters.Add(new SqlParameter("@ID", SqlDbType.BigInt) { Value = entity.Id });

            return sqlParameters;
        }

        
    }
}
