namespace HelperLibrary.GeoCoding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Sample console application that uses the GeoCode classes
    /// </summary>
    /// <remarks>HelperLibrary.GeoCoding.GeoCodeSample.ResolveAddress()</remarks>
    public static class GeoCodeSample
    {
        #region Methods

        public static void ResolveAddress()
        {
            GeoPosition StartAddress = GeoCode.GeoCodeUSStreetAddress("One Microsoft Way", "Redmond", "WA");
            GeoPosition EndAddress = GeoCode.GeoCodeUSStreetAddress("1271 Avenue of the Americas ", "New York", "NY");

            Console.Write("Distance\r\n from {0}\r\n to {1} is {2}\r\n\r\n{3}\r\n\r\n{4}"
                , StartAddress.Address
                , EndAddress.Address
                , String.Format("{0} Miles", GeoCode.Distance(StartAddress, EndAddress, DistanceType.Mile))
                , WritePosition(StartAddress)
                , WritePosition(EndAddress));
        }

        static string WritePosition(GeoPosition GeoPoint)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Address: {0}{1}{2}{3}\r\n"
                    , (!GeoPoint.Address.IsNullOrEmpty() ? string.Format("{0}, ", GeoPoint.Address) : string.Empty)
                    , (!GeoPoint.City.IsNullOrEmpty() ? string.Format("{0}, ", GeoPoint.City) : string.Empty)
                    , (!GeoPoint.State.IsNullOrEmpty() ? string.Format("{0} ", GeoPoint.State) : string.Empty)
                    , GeoPoint.Zip
                    , GeoPoint.Precision);
            sb.AppendFormat("Lat:{0}; Long:{1};\r\n"
                , GeoPoint.Latitude
                , GeoPoint.Longitude);
            sb.AppendFormat("Precision: {0}\r\n", GeoPoint.Precision);
            if (!GeoPoint.APIResponse.IsNullOrEmpty())
            {
                sb.AppendFormat("Response from API: {0}\r\n", GeoPoint.APIResponse);
            }
            return sb.ToString();
        }

        #endregion Methods
    }
}