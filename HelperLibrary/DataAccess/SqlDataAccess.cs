namespace HelperLibrary.DataAccess
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Xml;

    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;

    public sealed partial class SqlDataAccess : IDisposable
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        bool disposed = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Provides access to data storage.
        /// </summary>
        public SqlDataAccess()
        {
        }

        /// <summary>
        /// Provides access to data storage
        /// </summary>
        public SqlDataAccess(string connString, CommandType cmdType, string command)
        {
            this.CmdToExecute = command;
            this.ConnString = connString;
            this.CmdType = cmdType;
        }

        /// <summary>
        /// Provides access to data storage
        /// </summary>
        /// <param name="recordset">Overrides the default recordset name</param>
        public SqlDataAccess(string connString, CommandType cmdType, string command, string recordset)
        {
            this.RecordSetName = recordset;
            this.CmdToExecute = command;
            this.ConnString = connString;
            this.CmdType = cmdType;
        }

        /// <summary>
        /// Deconstructor to let the system know this was not explicitly disposed of.
        /// </summary>
        ~SqlDataAccess()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Name of the stored procedure to execute.
        /// </summary>
        public string CmdToExecute
        {
            get; set;
        }

        /// <summary>
        /// The type of command to run.
        /// </summary>
        public CommandType CmdType
        {
            get; set;
        }

        /// <summary>
        /// Connection String
        /// </summary>
        public string ConnString
        {
            get; set;
        }

        /// <summary>
        /// Public property exposing System.Data.SqlDbType so that developer does not need to specify using System.Data;
        /// </summary>
        public SqlDbType DBType
        {
            get; set;
        }

        /// <summary>
        /// Default recordset name.
        /// </summary>
        public string RecordSetName
        {
            get; set;
        }

        /// <summary>
        /// Gets the number of rows affected by the sql command.
        /// </summary>
        public int RowsAffected
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlCommand SqlCmd
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlConnection SqlConn
        {
            get; set;
        }

        /// <summary>
        /// Gets/Sets the ConnectionTimeout property on the sql command.
        /// </summary>
        public int Timeout
        {
            get
            {
                return SqlCmd.CommandTimeout;
            }
            set
            {
                SqlCmd.CommandTimeout = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// IDispose member.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Returns data as an XmlDocument object.
        /// </summary>
        public XmlDocument ExecDataXml()
        {
            this.BuildCmd();
            XmlDocument response = new XmlDocument();
            DataSet ds = new DataSet();
            try
            {
                System.Diagnostics.Trace.WriteLine(string.Concat("Begin execute command ", this.CmdToExecute), "DAO");
                SqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(this.SqlCmd);
                adapter.Fill(ds, this.RecordSetName);
                if (ds.Tables.Count > 0)
                {
                    this.RowsAffected = ds.Tables[0].Rows.Count;
                }
                adapter.Dispose();
            }
            catch (Exception)
            {
                return response;
            }
            finally
            {
                SqlCmd.Dispose();
                SqlConn.Dispose();
            }
            System.Diagnostics.Trace.WriteLine(string.Concat("End execute command ", this.CmdToExecute), "DAO");

            string dsXml = ds.GetXml();
            dsXml = dsXml.Replace("<NewDataSet>", string.Empty);
            dsXml = dsXml.Replace("</NewDataSet>", string.Empty);
            dsXml = dsXml.Replace("<NewDataSet />", string.Empty);
            dsXml = dsXml.Replace("<root>", string.Empty);
            dsXml = dsXml.Replace("</root>", string.Empty);

            response.LoadXml("<response><status>OK</status><recordset/></response>");
            response.SelectSingleNode("response/recordset").InnerXml = dsXml;

            if (string.IsNullOrEmpty(dsXml))
            {
                response.SelectSingleNode("response/status").InnerText = "ERROR";
                response.SelectSingleNode("response").RemoveChild(response.SelectSingleNode("response/recordset"));
                response.SelectSingleNode("response").AddNode("error", "No records returned");
            }

            return response;
        }

        public void serverconn()
        {
            //string connectionString, scriptText;
            //SqlConnection sqlConnection = new SqlConnection(this.ConnString);
            //ServerConnection svrConnection = new ServerConnection(this.SqlConn);

            //Server server = new Server(svrConnection);
            //server.ConnectionContext.ExecuteNonQuery(scriptText);
        }

        /// <summary>
        /// Builds the connection and command objects
        /// </summary>
        void BuildCmd()
        {
            // this.ConnString, this.CmdType, this.CmdToExecute cannot be null

            SqlConn = new SqlConnection(this.ConnString);
            SqlCmd = new SqlCommand(string.Empty, SqlConn);
            SqlCmd.CommandType = this.CmdType;
            SqlCmd.CommandText = this.CmdToExecute;
        }

        /// <summary>
        /// Private dispose method to handle any additional resource cleanup.
        /// </summary>
        void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing && SqlConn != null && SqlConn.State == ConnectionState.Open)
                {
                    if (SqlCmd != null)
                    {
                        SqlCmd.Dispose();
                    }
                    SqlConn.Dispose();
                }
                disposed = true;
            }
        }

        #endregion Methods
    }
}