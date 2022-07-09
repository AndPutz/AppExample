using AppExampleAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Infra;

namespace AppExampleAPI.Rules
{
    public class TypeBusiness
    {
        private string connectionString;

        public async Task<TabList> SelectAll(IConfiguration config)
        {
            TabList types = new();

            SetConnectionString(config);

            SqlDataReader reader = await dbFactory.Instance.ExecuteSelect(connectionString, "PR_TYPE_API_SEL", new List<SqlParameter>());

            while(reader.Read())
            {
                types.Add(new TypeTab()
                {
                    Id = (int)reader["ID"],
                    Description = reader["DESCRIPTION"].ToString()
                });

            }

            dbFactory.Instance.CloseConnection();

            return types;
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
    }
}
