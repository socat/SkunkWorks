namespace HelperLibrary.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    public static class SqlHelper
    {
        #region Methods

        public static object Coalesce<T>(T? tee, object obj)
            where T : struct
        {
            return tee.HasValue ? tee.Value : obj;
        }

        public static object Coalesce<T>(T tee, object obj)
            where T : class
        {
            return tee ?? obj;
        }

        public static SqlCommand CreateCommand(string cmdText, string connectionString)
        {
            var connection = new SqlConnection(connectionString);

            var command = new SqlCommand(cmdText, connection);

            //The time in seconds to wait for the command to execute.
            command.CommandTimeout = 172800; //60sec * 60min * 48hours

            command.Disposed += delegate
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
                connection = null;
            };

            return command;
        }

        /// <summary>
        /// Opens connection, executes a query against the connection, returns the number of rows affected and closes the connection 
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            try
            {
                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }

                return sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlCommand.Connection.State != ConnectionState.Closed) sqlCommand.Connection.Close();
            }
        }

        public static SqlDataReader ExecuteReader(SqlCommand sqlCommand)
        {
            try
            {
                sqlCommand.Connection.Open();

                return sqlCommand.ExecuteReader();
            }
            finally
            {
                if (sqlCommand.Connection.State != ConnectionState.Closed) sqlCommand.Connection.Close();
            }
        }

        public static object ExecuteScalar(SqlCommand sqlCommand)
        {
            try
            {
                sqlCommand.Connection.Open();

                return sqlCommand.ExecuteScalar();
            }
            finally
            {
                if (sqlCommand.Connection.State != ConnectionState.Closed) sqlCommand.Connection.Close();
            }
        }

        #endregion Methods
    }
}