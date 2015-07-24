namespace HelperLibrary
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Xml;

    #region Enumerations

    /// <summary>
    /// Unit of measurement
    /// </summary>
    public enum DistanceType
    {
        /// <summary>
        /// Miles
        /// </summary>
        Mile,
        /// <summary>
        /// Nautical Miles
        /// </summary>
        NauticalMile,
        /// <summary>
        /// Kilometers
        /// </summary>
        Kilometer
    }

    #endregion Enumerations

    /// <summary>
    /// Stores the latitude and longitude for a location.
    /// </summary>
    public struct GeoPosition
    {
        #region Fields

        /// <summary>
        /// The Address
        /// </summary>
        public string Address;

        /// <summary>
        /// The API Response
        /// </summary>
        public string APIResponse;

        /// <summary>
        /// The City
        /// </summary>
        public string City;

        /// <summary>
        /// The Country
        /// </summary>
        public string Country;

        /// <summary>
        /// The latitude
        /// </summary>
        public double Latitude;

        /// <summary>
        /// The longitude
        /// </summary>
        public double Longitude;

        /// <summary>
        /// The precision
        /// </summary>
        public string Precision;

        /// <summary>
        /// The State
        /// </summary>
        public string State;

        /// <summary>
        /// The Zip
        /// </summary>
        public string Zip;

        #endregion Fields
    }

    /// <summary>
    /// Logic to submit and receive geocoding requests using the yahoo geocoding api
    /// </summary>
    public static partial class GeoCode
    {
        #region Fields

        private static string _appIDLocation = "yahoo.geoCode.appid";

        #endregion Fields

        #region Properties

        private static string appID
        {
            get
            {
                if (ConfigurationManager.AppSettings[_appIDLocation] != null
                    && !String.IsNullOrEmpty(ConfigurationManager.AppSettings[_appIDLocation].ToString()))
                {
                    return ConfigurationManager.AppSettings[_appIDLocation].ToString();
                }
                else
                {
                    return System.Guid.NewGuid().ToString();
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns the distance between two points given the latitude, longitude, and unit of measurement.
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <param name="type"></param>
        /// <returns>The distance in whatever unit of measurement specified between the two positions</returns>
        public static double Distance(GeoPosition pos1, GeoPosition pos2, DistanceType type)
        {
            const double R_kilo = 6378.137;//6367.0;//
            const double R_mile = 3963.191;//3956.0;//
            const double R_naut = 3443.918;//3437.7;//
            double R = R_mile;
            switch (type)
            {
                case DistanceType.Mile:
                default:
                    {
                        R = R_mile;
                        break;
                    }
                case DistanceType.NauticalMile:
                    {
                        R = R_naut;
                        break;
                    }
                case DistanceType.Kilometer:
                    {
                        R = R_kilo;
                        break;
                    }
            }

            double dLat = Radius(pos2.Latitude - pos1.Latitude);
            double dLon = Radius(pos2.Longitude - pos1.Longitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                + Math.Cos(Radius(pos1.Latitude))
                * Math.Cos(Radius(pos2.Latitude))
                * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            // double d = R * c;
            return R * c;
        }

        /// <summary>
        /// Returns the position in latitude and longitude for known location's street address.
        /// </summary>
        /// <param name="street"></param>
        /// <param name="cityName"></param>
        /// <param name="state"></param> 
        /// <returns></returns>
        public static GeoPosition GeoCodeUSStreetAddress(string street, string cityName, string state)
        {
            //Yahoo! Map Application ID
            //string appID = "HWpxHKXV34FlsQPeXGwtRkk7A6eSLkOhGIxxhS5QjOWegTjqd1fEHvqERK3y";
            //string appID = System.Guid.NewGuid().ToString();
            street = street.Replace(" ", "+");
            cityName = cityName.Replace(" ", "+");
            Uri serviceLocation = new Uri(string.Format("http://local.yahooapis.com/MapsService/V1/geocode?appid={0}&street={1}&city={2}&state={3}", appID, street, cityName, state));
            string response = string.Empty;

            HttpWebRequest trans = (HttpWebRequest)WebRequest.Create(serviceLocation);
            using (StreamReader parseXml = new StreamReader(trans.GetResponse().GetResponseStream()))
            {
                response = parseXml.ReadToEnd();
            }
            return StringToGeoPosition(response);
        }

        /// <summary>
        /// Returns the radian of the specified angle
        /// </summary>
        public static double Radius(double val)
        {
            return (Math.PI / 180) * val;
        }

        static GeoPosition StringToGeoPosition(string response)
        {
            XmlDocument ResponseXml = new XmlDocument();
            ResponseXml.LoadXml(response);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(ResponseXml.NameTable);
            nsmgr.AddNamespace("yahoo", "urn:yahoo:maps");

            string ApiResponse = (ResponseXml.SelectSingleNode("//yahoo:Result/@warning", nsmgr) != null ? ResponseXml.SelectSingleNode("//yahoo:Result/@warning", nsmgr).InnerText : string.Empty);
            string ReqPrecision = ResponseXml.SelectSingleNode("//yahoo:Result/@precision", nsmgr).InnerText;

            return new GeoPosition()
            {
                Latitude = Convert.ToDouble(ResponseXml.SelectSingleNode("//yahoo:Latitude", nsmgr).InnerText),
                Longitude = Convert.ToDouble(ResponseXml.SelectSingleNode("//yahoo:Longitude", nsmgr).InnerText),
                Address = ResponseXml.SelectSingleNode("//yahoo:Address", nsmgr).InnerText,
                City = ResponseXml.SelectSingleNode("//yahoo:City", nsmgr).InnerText,
                State = ResponseXml.SelectSingleNode("//yahoo:State", nsmgr).InnerText,
                Zip = ResponseXml.SelectSingleNode("//yahoo:Zip", nsmgr).InnerText,
                Country = ResponseXml.SelectSingleNode("//yahoo:Country", nsmgr).InnerText,
                APIResponse = ApiResponse,
                Precision = ReqPrecision
            };
        }

        #endregion Methods
    }
}