//----------------------------------------------------------------
// <copyright file="Crm.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------


namespace HelperLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using Microsoft.Crm.Sdk;
    using Microsoft.Crm.Sdk.Query;
    using Microsoft.Crm.SdkTypeProxy;

    using Dbg = HelperLibrary.DebugOut;

    /// <summary>
    /// Crm Object, used to manage CRM deployments.
    /// </summary>
    public partial class Crm : IDisposable
    {
        #region Fields

        /// <summary>
        /// Relative path to the CRM discovery service.
        /// </summary>
        const string _MSCrmDiscoveryServicePath = "/mscrmservices/2007/ad/crmdiscoveryservice.asmx";

        /// <summary>
        /// Relative path to the CRM Service.
        /// </summary>
        const string _MSCrmServicePath = "/MSCrmServices/2007/CrmService.asmx";

        /// <summary>
        /// Timeout in minutes until business units collection is invalid.
        /// </summary>
        private static int businessUnitCacheTimeOut = 1;

        /// <summary>
        /// Time that the business units collection was last updated.
        /// </summary>
        private DateTime businessUnitsLastUpdated = DateTime.Now;

        /// <summary>
        /// Private CRM Discovery Service object to allow connection to a Microsoft CRM Dynamics Discovery Service API.
        /// </summary>
        private CrmDiscoveryService.CrmDiscoveryService crmDiscoveryService = null;

        /// <summary>
        /// Used by application to determine whether or not to (re)initialize the CRM Discovery Service.
        /// </summary>
        private bool CrmDiscoveryServiceInitialized = false;

        /// <summary>
        /// Private CrmService object to remotely manage Microsoft Dynamics CRM via Service API.
        /// </summary>
        private Microsoft.Crm.SdkTypeProxy.CrmService crmService = null;

        /// <summary>
        /// Used by application to determine whether or not to (re)initialize the CRM Service.
        /// </summary>
        private bool CrmServiceInitialized = false;

        /// <summary>
        /// Private CRM authentication token to allow connection to the Microsoft Dynamics CRM Service.
        /// </summary>
        private Microsoft.Crm.Sdk.CrmAuthenticationToken crmToken = null;

        /// <summary>
        /// Private field for BusinessUnits property.
        /// </summary>
        private List<businessunit> _businessUnits = null;

        /// <summary>
        /// Private field for IsSsl property.
        /// </summary>
        private bool _isSsl = false;

        /// <summary>
        /// Private field for OrganizationName property.
        /// </summary>
        private string _orgName = string.Empty;

        /// <summary>
        /// Private field for Port property.
        /// </summary>
        private int _port = 80;

        /// <summary>
        /// Private field for ServerName property.
        /// </summary>
        private string _serverName = string.Empty;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor, does not call InitializeCrmService();
        /// </summary>
        public Crm()
        {
        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="orgName"></param>
        /// <param name="useSsl"></param>
        public Crm(string serverName, string orgName, bool useSsl)
            : this(serverName, orgName, (useSsl) ? 443 : 80, useSsl)
        {
            this.ServerName = serverName;
            this.OrganizationName = orgName;
            this.Port = (useSsl) ? 443 : 80;
            this.IsSsl = useSsl;
            this.InitializeCrmService();
        }

        /// <summary>
        /// Creates an instance of a Crm class.
        /// </summary>
        /// <param name="serverName">FQDN or WINS server name.</param>
        /// <param name="orgName">Name of the CRM organization.</param>
        /// <param name="port">Port on which the CRM application resides.</param>
        /// <param name="useSsl">Whether or not to access the application via SSL.</param>
        public Crm(string serverName, string orgName = "", int port = 0, bool useSsl = false)
        {
            this.ServerName = serverName;
            if (!string.IsNullOrEmpty(orgName))
            {
                this.OrganizationName = orgName;
            }
            this.IsSsl = useSsl;
            if (port == 0)
            {
                this.Port = (this.IsSsl) ? 443 : 80;
            }
        }

        #endregion Constructors

        #region Enumerations

        /// <summary>
        /// Action to take on a particular business unit.
        /// </summary>
        public enum BusinessUnitAction
        {
            /// <summary>
            /// None specified.
            /// </summary>
            None,
            /// <summary>
            /// Create a new business unit.
            /// </summary>
            Create,
            /// <summary>
            /// Disable a current business unit.
            /// </summary>
            Disable,
            /// <summary>
            /// Enable a current business unit.
            /// </summary>
            Enable
        }

        /// <summary>
        /// Enum for CrmAuthentication.AuthenticationType values
        /// </summary>
        public enum CrmAuthenticationType : int
        {
            /// <summary>
            /// Specifies Active Directory authentication.
            /// </summary>
            AD = 0,
            /// <summary>
            /// Specifies Passport authentication.
            /// </summary>
            Passport = 1,
            /// <summary>
            /// Specifies Internet Facing Deployment authentication (formerly known as SPLA).
            /// </summary>
            Spla = 2
        }

        #endregion Enumerations

        #region Properties

        /// <summary>
        /// Property accessort that handles querying for, caching, and refreshing the list of current business units.
        /// </summary>
        public List<businessunit> BusinessUnits
        {
            get
            {
                this.InitializeCrmService();
                if (_businessUnits.IsNull()
                    || _businessUnits.Count() == 0
                    || businessUnitsLastUpdated.AddMinutes(businessUnitCacheTimeOut) > DateTime.Now)
                {
                    _businessUnits = new List<businessunit>();
                    QueryExpression query = new QueryExpression();
                    query.EntityName = EntityName.businessunit.ToString();
                    query.ColumnSet = new AllColumns();
                    BusinessEntityCollection resultSet = crmService.RetrieveMultiple(query);

                    _businessUnits = (List<businessunit>)resultSet.BusinessEntities
                        .Select(p => (businessunit)p)
                        .ToList<businessunit>();

                    businessUnitsLastUpdated = DateTime.Now;
                }
                return _businessUnits;
            }
            private set
            {
                _businessUnits = value;
            }
        }

        /// <summary>
        /// Determines if the web service is on a secure connection.
        /// </summary>
        public bool IsSsl
        {
            get
            {
                return _isSsl;
            }
            set
            {
                if (_isSsl != value)
                {
                    CrmServiceInitialized = false;
                    CrmDiscoveryServiceInitialized = false;
                }
                _isSsl = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the organization.
        /// </summary>
        public string OrganizationName
        {
            get
            {
                return _orgName;
            }
            set
            {
                // Invalidate current CRM Service connections when Organization Name is changed.
                if (!_orgName.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    CrmServiceInitialized = false;
                }
                _orgName = value;
            }
        }

        /// <summary>
        /// Web Service port.
        /// </summary>
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                if (_port != value)
                {
                    CrmServiceInitialized = false;
                    CrmDiscoveryServiceInitialized = false;
                }
                _port = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                // Invalidate current CRM Service and Discovery Service connections if Server Name is changed.
                if (!_serverName.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    CrmDiscoveryServiceInitialized = false;
                    CrmServiceInitialized = false;
                }
                _serverName = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Create a new business unit.
        /// </summary>
        /// <param name="bu">New Business Unit to create.</param>
        /// <exception cref="Exception">Throws an Exception if there is an existing Business Unit with the same name or Business Unit ID.</exception>
        public CreateResponse CreateBusinessUnit(businessunit bu)
        {
            this.InitializeCrmService();
            // check for existing
            bool buexist = this.DoesBusinessUnitExist(businessUnitID: bu.businessunitid.Value, businessUnitName: bu.name);
            if (buexist)
            {
                string errorMessage = string.Format("Create Error: There is a business unit with the same name ({0}) or BusinessUnitID ({1}) in the target organization ({2})"
                    , bu.name
                    , bu.businessunitid.Value
                    , this.OrganizationName);
                throw new Exception(errorMessage);
            }
            else
            {
                TargetCreateBusinessUnit tcbu = new TargetCreateBusinessUnit();
                tcbu.BusinessUnit = bu;
                CreateRequest cr = new CreateRequest();
                cr.Target = tcbu;
                CreateResponse cresp = (CreateResponse)crmService.Execute(cr);
                return cresp;
            }
        }

        /// <summary>
        /// Creates 
        /// </summary>
        /// <param name="businessUnits"></param>
        public void CreateBusinessUnits(List<businessunit> create)
        {
            List<businessunit> currentUnits = new List<businessunit>();
            currentUnits.AddRange(this.BusinessUnits);

            List<businessunit> existing = new List<businessunit>();
            List<businessunit> orphaned = new List<businessunit>();
            List<businessunit> abandoned = new List<businessunit>();

            List<Guid> buidArray = currentUnits.Where(p => p.businessunitid != null).Select(p => p.businessunitid.Value).ToList<Guid>();
            List<Guid> disabledBuidArray = currentUnits.Where(p => p.businessunitid != null && p.isdisabled.Value == true).Select(p => p.businessunitid.Value).ToList<Guid>();
            List<string> nameArray = currentUnits.Where(p => !p.name.IsNullOrEmpty()).Select(p => p.name).ToList();

            // preprocessing checks:
            // * Do any members of createBusinessUnits already exist in target instance?
            existing.AddRange(create.Where(p=> buidArray.Contains(p.businessunitid.Value) || nameArray.Where(q=> q.Equals(p.name, StringComparison.InvariantCultureIgnoreCase)).Count() > 0).Select(p=>p));

            // - append buids from create collection to allow creation of parent business units with children
            buidArray.AddRange(create.Where(p => p.businessunitid != null).Select(p => p.businessunitid.Value).ToList<Guid>());

            // * Do any members of createBusinessUnits reference a parentbusinessunit that does not exist in createBusinessUnits or target instance?
            orphaned.AddRange(create.Where(p => !buidArray.Contains(p.parentbusinessunitid.Value)).Select(p => p));

            // * Do any members of createBusinessUnits reference a parentbusinessunit that is disabled on target instance?
            abandoned.AddRange(create.Where(p => disabledBuidArray.Contains(p.parentbusinessunitid.Value)).Select(p => p));

            if (//existing.Count() > 0 || orphaned.Count() > 0 || abandoned.Count() > 0
                 1 == 2)
            {
                #region error message block
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("The new business units did not pass validation.");
                sb.AppendLine();
                sb.AppendLine("The application cannot continue until these discrepencies are resolved.");
                sb.AppendLine();
                sb.AppendLine("Here are the three conditions that cause the this message to appear:");
                sb.AppendLine(" 1) New business units must have a unique Name and Business Unit ID (BUID).");
                if (existing.Count() > 0)
                {
                    sb.AppendLine("   * Examples of Business Units that already exist on the target machine are as follows: \r\n\t{0}", existing.DbgString());
                }
                sb.AppendLine(" 2) New business units must specify the PUID of an existing Business Unit, a new Business Unit in this list, or specify \"ROOT\" to be a child of the root Business Unit.");
                if (orphaned.Count() > 0)
                {
                    sb.AppendLine("   * Examples of Business Units that reference non-existant Parent Business Units are as follows: \r\n\t{0}", orphaned.DbgString());
                }
                sb.AppendLine(" 3) New business units cannot be children of a disabled Parent Business Unit.");

                if (abandoned.Count() > 0)
                {
                    sb.AppendLine("   * Examples of Business Units that reference a disabled Parent Business Unit are as follows: \r\n\t{0}", abandoned.DbgString());
                }
                #endregion

                Dbg.WriteLine(sb.ToString());
            }
            else
            {
                // combine current & new lists together, output to console.
                List<businessunit> newBusinessUnits = new List<businessunit>();
                // add new business units
                newBusinessUnits.AddRange(create);
                // append existing business units
                newBusinessUnits.AddRange(currentUnits);
                // sort the business units by placing the root business unit at the top, append it's direct descendants, then descendants of descendants, etc.
                newBusinessUnits.OrderList(newBusinessUnits.IndexOf(newBusinessUnits.Where(p => p.parentbusinessunitid.IsNull()).Select(p => p).First()));

                // remove disabled business units, children of disabled business units, and root elements
                newBusinessUnits.RemoveAll(p => p.isdisabled.Value == true
                                                || p.parentbusinessunitid == null
                                                || disabledBuidArray.Contains((p.parentbusinessunitid != null) ? p.parentbusinessunitid.Value : Guid.Empty));

                // add each one in sequence...
                //List<CreateResponse> updateValues = newBusinessUnits.Select(p => this.CreateBusinessUnit(p)).ToList();

                //Dbg.WriteLine("update guids: \r\n\t{0}", string.Join("\r\n\t", updateValues.Where(p => !p.IsNull()).Select(p => p.id).ToArray()));

            }
        }

        /// <summary>
        /// IDisposable methods.
        /// </summary>
        public void Dispose()
        {
            this.crmToken = null;
            this.crmService = null;
            this.BusinessUnits = null;

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Determines if a Business Unit with the same name or Business Unit ID exists on the target machine.
        /// </summary>
        /// <param name="businessUnitID">Business Unit ID of the Business Unit to search for.</param>
        /// <param name="businessUnitName">Business Unit name of the Business Unit to search for.</param>
        /// <returns>True if a business unit with the same name or Business Unit ID exists on the target machine, otherwise false.</returns>
        public bool DoesBusinessUnitExist(Guid businessUnitID, string businessUnitName)
        {
            if (businessUnitID.IsNull()  && businessUnitName.IsNullOrEmpty())
            {
                throw new ArgumentNullException("You must supply a businessUnitID or a businessUnitName.");
            }

            IEnumerable<Guid> buidArray = this.BusinessUnits.Where(p=> p.businessunitid != null)
                                                       .Select(p=> p.businessunitid.Value)
                                                       .ToArray<Guid>();

            IEnumerable<string> nameArray = this.BusinessUnits.Where(p => !p.name.IsNullOrEmpty())
                                                         .Select(p => p.name)
                                                         .AsEnumerable();

            if (!businessUnitID.IsNull() && buidArray.Where(p => p == businessUnitID).Count() > 0)
            {
                return true;
            }

            if (!businessUnitName.IsNullOrEmpty() && nameArray.Where(p => p.Equals(businessUnitName, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a business unit by name.
        /// </summary>
        /// <param name="businessUnitName">Name of the business unit (case-insensitive).</param>
        /// <returns>A Business Unit object obtained by the CRM Service.</returns>
        public businessunit GetBusinessUnit(string businessUnitName)
        {
            if (businessUnitName.IsNullOrEmpty())
            {
                throw new ArgumentNullException("businessUnitName cannot be null or empty");
            }

            this.InitializeCrmService();

            //Get the business unit
            QueryByAttribute buQuery = new QueryByAttribute();
            buQuery.ColumnSet = new AllColumns();
            buQuery.EntityName = EntityName.businessunit.ToString();
            buQuery.Attributes = new string[] { "name" };
            buQuery.Values = new string[] { businessUnitName };

            BusinessEntityCollection resultSet = crmService.RetrieveMultiple(buQuery);

            return (resultSet.BusinessEntities.Count <= 0)
                ? null
                : resultSet.BusinessEntities
                    .Where(p => ((businessunit)p).name.Equals(businessUnitName, StringComparison.InvariantCultureIgnoreCase))
                    .Select(p => ((businessunit)p))
                    .First();
        }

        /// <summary>
        /// Retrieves a collection of organizations/crm installations on the target server.  
        /// </summary>
        /// <returns></returns>
        public CrmDiscoveryService.OrganizationDetail[] GetOrgNames()
        {
            this.InitializeCrmDiscoveryService();
            CrmDiscoveryService.RetrieveOrganizationsRequest request = new CrmDiscoveryService.RetrieveOrganizationsRequest();
            CrmDiscoveryService.RetrieveOrganizationsResponse response = (CrmDiscoveryService.RetrieveOrganizationsResponse)this.crmDiscoveryService.Execute(request);
            CrmDiscoveryService.OrganizationDetail[] orgs = ((CrmDiscoveryService.RetrieveOrganizationsResponse)this.crmDiscoveryService.Execute(request)).OrganizationDetails;
            return orgs;
        }

        /// <summary>
        /// Returns the root business unit for the current organization.
        /// </summary>
        /// <returns></returns>
        public businessunit GetRootBusinessUnit()
        {
            this.InitializeCrmService();
            QueryExpression query = new QueryExpression();;
            query.EntityName = EntityName.businessunit.ToString();
            query.ColumnSet = new AllColumns();
            BusinessEntityCollection resultSet = crmService.RetrieveMultiple(query);
            if (resultSet.BusinessEntities.Count() > 0 && resultSet.BusinessEntities.Where(p => ((businessunit)p).parentbusinessunitid == null).Count() > 0)
            {
                return (businessunit)resultSet.BusinessEntities.Where(p => ((businessunit)p).parentbusinessunitid == null).First();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Imports customization xml into the current CRM organization.
        /// </summary>
        /// <param name="customizations">Xml Document containing the CRM Customizations to import.</param>
        public void ImportCustomizations(System.Xml.XmlDocument customizations)
        {
            this.InitializeCrmService();
            this.crmService.Timeout = -1;
            Microsoft.Crm.SdkTypeProxy.ImportAllXmlRequest importAllRequest = new Microsoft.Crm.SdkTypeProxy.ImportAllXmlRequest();
            importAllRequest.CustomizationXml = customizations.OuterXml;
            Microsoft.Crm.SdkTypeProxy.ImportAllXmlResponse importAllResponse = (Microsoft.Crm.SdkTypeProxy.ImportAllXmlResponse)crmService.Execute((Microsoft.Crm.SdkTypeProxy.Request)importAllRequest);
        }

        /// <summary>
        /// Output current object information.
        /// </summary>
        /// <returns>String denoting current ServerName, OrganizationName, port, and ssl values.</returns>
        public override string ToString()
        {
            return string.Concat("crmObj { ServerName: ", this.ServerName,
                                  ", OrganizationName: ", this.OrganizationName,
                                  ", IsSsl: ", this.IsSsl,
                                  ", Port: ", this.Port,
                                  " }");
        }

        /// <summary>
        /// Used to activate or deactivate a current business unit.
        /// </summary>
        /// <param name="businessUnitID">Business Unit ID of the business unit to activate or deactivate.</param>
        /// <param name="businessUnitName"></param>
        /// <param name="state"></param>
        public void UpdateBusinessUnitState(Guid businessUnitID, string businessUnitName, BusinessUnitState state)
        {
            this.InitializeCrmService();
            // check for existing
            bool buexist = this.DoesBusinessUnitExist(businessUnitID: businessUnitID, businessUnitName: businessUnitName);
            if (!buexist)
            {
                string errorMessage = string.Format("Update Error: There is no BusinessUnit with the same Business Unit Name ({0}) or BusinessUnitID ({1}) in the target organization ({2})"
                    , businessUnitName
                    , businessUnitID
                    , this.OrganizationName);
                throw new Exception(errorMessage);
            }
            else
            {
                SetStateBusinessUnitRequest req = new SetStateBusinessUnitRequest();
                req.BusinessUnitState = state;
                req.EntityId = businessUnitID;
                crmService.Execute(req);
                this.BusinessUnits.Clear();
            }
        }

        /// <summary>
        /// Exports all customizations to the supplied XmlDocument.
        /// </summary>
        /// <remarks>Do not use.  Need to investigate how we determine which customizations to export.</remarks>
        /// <param name="docToExport"></param>
        private XmlDocument ExportCustomizations()
        {
            this.InitializeCrmService();
            // Create the request.
            ExportAllXmlRequest request = new ExportAllXmlRequest();
            // Execute the request.
            ExportAllXmlResponse response = (ExportAllXmlResponse)crmService.Execute(request);
            XmlDocument docToExport = new XmlDocument();
            docToExport.LoadXml(response.ExportXml);
            return docToExport;
        }

        /// <summary>
        /// Initializes the CrmDiscoveryService class.
        /// </summary>
        private void InitializeCrmDiscoveryService()
        {
            if (!CrmDiscoveryServiceInitialized)
            {
                #region disallow null parameters
                if (string.IsNullOrEmpty(this.ServerName))
                {
                    throw new System.ArgumentNullException("ServerName", "Property cannot be null or empty.");
                }
                if (this.Port < 0 || this.Port > 65535)
                {
                    throw new System.ArgumentOutOfRangeException("Port", "Port must be a value between 0 and 65535.  Default is 80.");
                }
                #endregion

                this.crmDiscoveryService = new CrmDiscoveryService.CrmDiscoveryService();
                this.crmDiscoveryService.Url = ServiceUri(this.IsSsl, this.ServerName, this.Port, _MSCrmDiscoveryServicePath).ToString();
                this.crmDiscoveryService.Credentials = System.Net.CredentialCache.DefaultCredentials;
                this.CrmDiscoveryServiceInitialized = true;
            }
        }

        /// <summary>
        /// Initializes the CrmService class.
        /// </summary>
        private void InitializeCrmService()
        {
            if (!CrmServiceInitialized)
            {
                #region disallow null parameters
                if (string.IsNullOrEmpty(this.ServerName))
                {
                    throw new System.ArgumentNullException("ServerName", "Property cannot be null or empty.");
                }
                if (this.OrganizationName == null)
                {
                    throw new System.ArgumentNullException("OrganizationName", "Property cannot be null.");
                }
                if (this.Port < 0 || this.Port > 65535)
                {
                    throw new System.ArgumentOutOfRangeException("Port", "Port must be a value between 0 and 65535.  Default is 80.");
                }
                #endregion

                // Set up the CRM service.
                this.crmToken = new Microsoft.Crm.Sdk.CrmAuthenticationToken();
                // You can use enums.cs from the SDK\Helpers folder to get the enumeration for Active Directory authentication.
                this.crmToken.AuthenticationType = (int)CrmAuthenticationType.AD;
                // variable for project name
                this.crmToken.OrganizationName = OrganizationName;

                this.crmService = new Microsoft.Crm.SdkTypeProxy.CrmService();
                this.crmService.Url = ServiceUri(this.IsSsl, this.ServerName, this.Port, _MSCrmServicePath).ToString();
                this.crmService.CrmAuthenticationTokenValue = crmToken;
                this.crmService.Credentials = System.Net.CredentialCache.DefaultCredentials;

                this.CrmServiceInitialized = true;
                this.BusinessUnits = null;
            }
        }

        /// <summary>
        /// Returns an URI to attach the the CRMService.
        /// </summary>
        /// <param name="isSecure"></param>
        /// <param name="serverName"></param>
        /// <param name="port"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private System.Uri ServiceUri(bool isSecure, string serverName, int port, string path)
        {
            string url = string.Format("http{0}://{1}{2}/{3}",
                ((isSecure) ? "s" : string.Empty),
                serverName,
                ((port == 80 && !IsSsl || port == 443 && IsSsl) ? string.Empty : string.Concat(":", port)),
                (path.StartsWith("/") ? path : string.Concat("/", path)));
            return new Uri(url);
            //return retUri;
        }

        #endregion Methods
    }
}