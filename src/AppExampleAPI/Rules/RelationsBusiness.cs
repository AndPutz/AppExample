using AppExampleAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Infra;

namespace AppExampleAPI.Rules
{
    public class RelationsBusiness
    {
        private string connectionString;

        public async Task<RelationsTab> CreateRelations(IConfiguration config, RelationsTab relationsTab)
        {
            List<SqlParameter> sqlParameters = GetObjectParameters(relationsTab, true);

            SetConnectionString(config);

            relationsTab.ID = await dbFactory.Instance.Insert(connectionString, "PR_RELATIONS_API_INS", sqlParameters);                        

            return relationsTab;
        }

        public async Task<RelationsTab> UpdateRelations(IConfiguration config, RelationsTab relationsTab)
        {
            List<SqlParameter> sqlParameters = GetObjectParameters(relationsTab, false);

            SetConnectionString(config);

            await dbFactory.Instance.ExecuteNonQueryAsync(connectionString, "PR_RELATIONS_API_UPD", sqlParameters);

            return relationsTab;
        }

        public async Task<RelationsTab> DeleteRelations(IConfiguration config, long ID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>() { new SqlParameter("@ID", SqlDbType.BigInt) { Value = ID } };

            SetConnectionString(config);

            await dbFactory.Instance.ExecuteNonQueryAsync(connectionString, "PR_RELATIONS_API_DEL", sqlParameters);

            return new RelationsTab();
        }

        public async Task<RelationsTabList> SelectAllRelations(IConfiguration config)
        {
            RelationsTabList relations = new();

            SetConnectionString(config);

            SqlDataReader reader = await dbFactory.Instance.ExecuteSelect(connectionString, "PR_RELATIONS_API_SEL", new List<SqlParameter>());

            try
            {
                while (reader.Read())
                {
                    relations.Add(new RelationsTab()
                    {
                        ID = (long)reader["ID"],
                        ObjectA = new ObjectTab()
                        {
                            Id = (long)reader["ID_OBJECT_A"],
                            Name = reader["NAME_A"].ToString(),
                            Description = reader["DESCRIPTION_A"].ToString(),
                            Type = new TypeTab() { Id = (int)reader["TYPE_ID_A"], Description = reader["TYPE_DESCRIPTION_A"].ToString() }
                        },
                        ObjectB = new ObjectTab()
                        {
                            Id = (long)reader["ID_OBJECT_B"],
                            Name = reader["NAME_B"].ToString(),
                            Description = reader["DESCRIPTION_B"].ToString(),
                            Type = new TypeTab() { Id = (int)reader["TYPE_ID_B"], Description = reader["TYPE_DESCRIPTION_B"].ToString() }
                        }
                    });

                }
            }
            finally
            {
                dbFactory.Instance.CloseConnection();
            }

            return relations;
        }

        public async Task<RelationsTabList> SelectRelationsByName(IConfiguration config, string Name)
        {
            RelationsTabList relations = new();

            SetConnectionString(config);

            SqlDataReader reader = await dbFactory.Instance.ExecuteSelect(connectionString, "PR_RELATIONS_API_SEL_BYNAME", sqlParameters: new List<SqlParameter>() 
            { 
                new SqlParameter("@NAME", SqlDbType.VarChar) { Value = Name, Size = 50 } 
            });
            
            try
            {
                while (reader.Read())
                {
                    relations.Add(new RelationsTab()
                    {
                        ID = (long)reader["ID"],
                        ObjectA = new ObjectTab()
                        {
                            Id = (long)reader["ID_OBJECT_A"],
                            Name = reader["NAME_A"].ToString(),
                            Description = reader["DESCRIPTION_A"].ToString(),
                            Type = new TypeTab() { Id = (int)reader["TYPE_ID_A"], Description = reader["TYPE_DESCRIPTION_A"].ToString() }
                        },
                        ObjectB = new ObjectTab()
                        {
                            Id = (long)reader["ID_OBJECT_B"],
                            Name = reader["NAME_B"].ToString(),
                            Description = reader["DESCRIPTION_B"].ToString(),
                            Type = new TypeTab() { Id = (int)reader["TYPE_ID_B"], Description = reader["TYPE_DESCRIPTION_B"].ToString() }
                        }
                    });
                }                
            }
            finally
            {
                dbFactory.Instance.CloseConnection();
            }
            
            return relations;
        }

        /// <summary>
        /// This will list all object names distinctly that can be in Object A or B column.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public async Task<List<string>> SelectRelationsNameAutoComplete(IConfiguration config, string Name)
        {
            List<string> listReturn = new();

            SetConnectionString(config);

            SqlDataReader reader = await dbFactory.Instance.ExecuteSelect(connectionString, "PR_RELATIONS_API_SEL_AUTOCOMP", sqlParameters: new List<SqlParameter>()
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

        private List<SqlParameter> GetObjectParameters(RelationsTab relationsTab, bool inserted)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("@ID_OBJECT_A", SqlDbType.BigInt) { Value = relationsTab.ObjectA.Id });
            sqlParameters.Add(new SqlParameter("@ID_OBJECT_B", SqlDbType.BigInt) { Value = relationsTab.ObjectB.Id });
            
            if (inserted)
                sqlParameters.Add(new SqlParameter("@ID", SqlDbType.BigInt) { Direction = ParameterDirection.Output });
            else
                sqlParameters.Add(new SqlParameter("@ID", SqlDbType.BigInt) { Value = relationsTab.ID });

            return sqlParameters;
        }
    }
}
