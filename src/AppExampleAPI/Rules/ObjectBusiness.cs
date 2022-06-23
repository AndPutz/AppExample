using AppExampleAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Infra;

namespace AppExampleAPI.Rules
{
    public class ObjectBusiness
    {
        private string connectionString;

        public async Task<ObjectTab> CreateObject(IConfiguration config, ObjectTab objectTab)
        {
            List<SqlParameter> sqlParameters = GetObjectParameters(objectTab, true);

            SetConnectionString(config);

            objectTab.ID = await dbFactory.Instance.Insert(connectionString, "PR_OBJECT_API_INS", sqlParameters);                        

            return objectTab;
        }

        public async Task<ObjectTab> UpdateObject(IConfiguration config, ObjectTab objectTab)
        {
            List<SqlParameter> sqlParameters = GetObjectParameters(objectTab, false);

            SetConnectionString(config);

            await dbFactory.Instance.ExecuteNonQueryAsync(connectionString, "PR_OBJECT_API_UPD", sqlParameters);

            return objectTab;
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
                    ID = (long)reader["ID"],
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
                    ID = (long)reader["ID"],
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
                objectItem.ID = (long)reader["ID"];
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

        private List<SqlParameter> GetObjectParameters(ObjectTab objectTab, bool inserted)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar) { Value = objectTab.Name });
            sqlParameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.VarChar) { Value = objectTab.Description });
            sqlParameters.Add(new SqlParameter("@TYPE_ID", SqlDbType.Int) { Value = objectTab.Type.Id });
            if (inserted)
                sqlParameters.Add(new SqlParameter("@ID", SqlDbType.BigInt) { Direction = ParameterDirection.Output });
            else
                sqlParameters.Add(new SqlParameter("@ID", SqlDbType.BigInt) { Value = objectTab.ID });

            return sqlParameters;
        }
    }
}
