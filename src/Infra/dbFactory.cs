using System.Data;
using System.Data.SqlClient;

namespace Infra
{
    public class dbFactory
    {
        #region Singleton
        private static dbFactory _instance;

        static dbFactory()
        {

        }

        public static dbFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new dbFactory();
                }

                return _instance;
            }
        }
        #endregion

        public SqlConnection Connection { get; private set; }

        private string connectionString;

        /// <summary>
        /// Execute insert command setup in param command and return new ID inserted.
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="command"></param>
        /// <param name="sqlParameters"></param>
        /// <returns>Will return the value from output parameters from sqlParameters</returns>
        public async Task<long> Insert(string connectionStr, string command, List<SqlParameter> sqlParameters)
        {
            long id = -1;
            
            SetConnection(connectionStr);

            SqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(sqlParameters.ToArray());

            await cmd.ExecuteNonQueryAsync();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            SqlParameter paramOut = sqlParameters.FirstOrDefault(x => x.Direction == ParameterDirection.Output);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (paramOut != null)
                id = (long)paramOut.Value;

            CloseConnection();

            return id;
        }

        /// <summary>
        /// This command can be used to Update and Delete comands. 
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="command"></param>
        /// <param name="sqlParameters"></param>
        public async Task<int> ExecuteNonQueryAsync(string connectionStr, string command, List<SqlParameter> sqlParameters)
        {            
            SetConnection(connectionStr);

            SqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(sqlParameters.ToArray());

            int nRowsAffected = await cmd.ExecuteNonQueryAsync();

            CloseConnection();

            return nRowsAffected;
        }

        /// <summary>
        /// Will execute select commands whith the parameters sent, but it's not mandatory to send sqlParameters. 
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="command"></param>
        /// <param name="sqlParameters"></param>
        /// <returns>SqlDataReader to be processed inside of caller, so the connection will be close by the caller using the method CloseConnection after the data mapping.</returns>
        public async Task<SqlDataReader> ExecuteSelect(string connectionStr, string command, List<SqlParameter> sqlParameters)
        {
            SqlDataReader reader = null;

            SetConnection(connectionStr);            

            SqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(sqlParameters.ToArray());
            
            reader = await cmd.ExecuteReaderAsync();            

            return reader;
        }


        private void SetConnection(string connectionStr)
        {
            connectionString = connectionStr;

            if (Connection == null)
            {
                Connection = new SqlConnection(connectionString);
            }

            if (Connection.State != System.Data.ConnectionState.Open)
                Connection.Open();
        }

        public void CloseConnection()
        {
            if (Connection != null)
                Connection.Close();
        }
    }
}