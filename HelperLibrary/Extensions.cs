//----------------------------------------------------------------
// <copyright file="Extensions.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Extension methods class.
    /// </summary>
    public static partial class Extensions
    {
        #region Fields

        public const long gbyte = 1073741824;
        public const long kbyte = 1024;
        public const long mbyte = 1048576;
        public const long pbyte = 1125899906842624;
        public const long tbyte = 1099511627776;

        #endregion Fields

        #region Enumerations

        public enum FileSizeFormat
        {
            SizeBytes,
            SizeBits,
            SpeedBytes,
            SpeedBits
        }

        public enum fsBaseline
        {
            Petabyte,
            Terabyte,
            Gigabyte,
            Megabyte,
            Kilobyte,
            Unassigned
        }

        #endregion Enumerations

        #region Methods

        /// <summary>
        /// Creates and appends a new attribute with the specified name to the current xml node.
        /// </summary>
        public static XmlAttribute AddAttribute(this XmlNode node, string attributeName)
        {
            return node.AddAttribute(attributeName, string.Empty);
        }

        /// <summary>
        /// Creates and appends a new attribute with the specified name and value to the current xml node.
        /// </summary>
        public static XmlAttribute AddAttribute(this XmlNode node, string attributeName, string attributeValue)
        {
            attributeName = attributeName.Replace(" ", "_");
            XmlAttribute attr = node.OwnerDocument.NewAttribute(attributeName, attributeValue);
            node.Attributes.Append(attr);
            return attr;
        }

        /// <summary>
        /// Appends a new node to the current node.
        /// </summary>
        /// <param name="node">XmlNode</param>
        /// <param name="tagName">Name of the new node</param>
        /// <returns></returns>
        public static XmlNode AddNode(this XmlNode node, string tagName)
        {
            return node.AddNode(tagName, string.Empty);
        }

        /// <summary>
        /// Appends a new node to the current node.
        /// </summary>
        /// <param name="node">XmlNode</param>
        /// <param name="tagName">Name of the new node</param>
        /// <param name="innerText">Inner text value (use String.Empty if null)</param>
        /// <returns></returns>
        public static XmlNode AddNode(this XmlNode node, string tagName, string innerText)
        {
            XmlNode newNode = node.OwnerDocument.NewNode(tagName, innerText);
            node.AppendChild(newNode);
            return newNode;
        }

        /// <summary>
        /// Converts the given controlcollection to an IEnumerable collection of controls.
        /// </summary>
        /// <returns>IEnumerable collection of Control objects.</returns>
        public static IEnumerable<System.Web.UI.Control> All(this System.Web.UI.ControlCollection controls)
        {
            foreach (System.Web.UI.Control control in controls)
            {
                foreach (System.Web.UI.Control child in control.Controls.All())
                {
                    yield return child;
                }
                yield return control;
            }
        }

        public static IEnumerable<System.Windows.Forms.Control> All(this System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (System.Windows.Forms.Control control in controls)
            {
                foreach (System.Windows.Forms.Control child in control.Controls.All())
                {
                    yield return child;
                }
                yield return control;
            }
        }

        /// <summary>
        /// Because I wanted an AppendLine function that uses format strings.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="formatString"></param>
        /// <param name="args"></param>
        /// <remarks>:P</remarks>
        public static void AppendLine(this StringBuilder sb, string formatString, params object[] args)
        {
            if (args.Count() > 0)
            {
                sb.AppendFormat(formatString, args);
            }
            else
            {
                sb.Append(formatString);
            }
            sb.AppendLine();
        }

        public static void asyncAssignText(this System.Windows.Forms.Control ctrl, string value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                {
                    ctrl.Text = value;
                }));
                return;
            }
            ctrl.Text = value;
        }

        public static string asyncGetText(this System.Windows.Forms.Control ctrl)
        {
            if (ctrl.InvokeRequired)
            {
                string retVal = string.Empty;
                ctrl.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                {
                    retVal = ctrl.Text;
                }));
                return retVal;
            }
            return ctrl.Text;
        }

        /// <summary>
        /// Capitalizes the first letter of each word.
        /// </summary>
        /// <returns>This string with the first letter of each word capitalized.</returns>
        public static string CapEachWord(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            string[] arr = value.Replace(Environment.NewLine, " ").Split(' ');
            if (arr.Length == 1)
            {
                return value.CapFirst();
            }
            else
            {
                return string.Join(" ", arr.Select(p => p.CapFirst()).ToArray());
            }
        }

        /// <summary>
        /// Capitalizes the first character of a string.
        /// </summary>
        /// <returns>This string with the first letter capitalized.</returns>
        public static string CapFirst(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return (value.Length == 1)
                        ? value.ToUpper()
                        : string.Concat(value.Substring(0, 1).ToUpper(), value.Substring(1, value.Length - 1));
            }
            return value;
        }

        /// <summary>
        /// Creates a CData section
        /// </summary>
        public static XmlCDataSection CData(this XmlDocument xmlDoc, string data)
        {
            return xmlDoc.CreateCDataSection(data);
        }

        /// <summary>
        /// Clones an object.
        /// </summary>
        /// <typeparam name="T"><paramref name="source"/>'s type.</typeparam>
        /// <param name="source">The object to copy.</param>
        /// <returns>A clone of the object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                StringBuilder ex = new StringBuilder();
                ex.Append("The source type must be serializable.");
                throw new Exception(ex.ToString());
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Copies the properties from one object to another.
        /// </summary>
        /// <param name="dst">The object you're copying to.</param>
        /// <param name="src">The object you're copying from.</param>
        public static void CopyProperties(object dst, object src)
        {
            System.Reflection.PropertyInfo[] srcProperties = src.GetType().GetProperties();
            Type dstType = dst.GetType();

            if (srcProperties == null || dstType.GetProperties() == null)
            {
                return;
            }
            foreach (PropertyInfo srcProperty in srcProperties)
            {
                PropertyInfo dstProperty = dstType.GetProperty(srcProperty.Name);
                if (dstProperty != null)
                {
                    if (dstProperty.PropertyType.IsAssignableFrom(srcProperty.PropertyType))
                    {
                        dstProperty.SetValue(dst, srcProperty.GetValue(src, null), null);
                    }
                }
            }
        }

        public static TimeSpan DateDiff(this DateTime date, DateTime compareToDate)
        {
            TimeSpan ts = date - compareToDate;
            return ts;
            /*
            public DateDiff(DateTime startdate, DateTime enddate)
            {
                TimeSpan ts = startdate - enddate;

                int d = 0;
                int m = 0;
                int y = 0;

                DateTime testdate = startdate;

                while (testdate < enddate)
                {
                    testdate = testdate.AddYears(1);
                    y++;
                }
                --y;
                testdate = testdate.AddYears(-1);

                while (testdate < enddate)
                {
                    testdate = testdate.AddMonths(1);
                    m++;
                }
                --m;
                testdate = testdate.AddMonths(-1);

                while (testdate < enddate)
                {
                    testdate = testdate.AddDays(1);
                    d++;
                }
                --d;
                testdate = testdate.AddDays(-1);

                m_days = d;
                m_months = m;
                m_years = y;
            }
            */
        }

        public static bool EndsWith(this string thisString, string[] suffixes)
        {
            foreach (string suffix in suffixes)
            {
                if (thisString.EndsWith(suffix, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        ///// <summary>
        ///// Generates a string listing the name, businessunitid, parentbusinessunitid, and isdisabled values
        ///// </summary>
        ///// <param name="bu"></param>
        ///// <returns></returns>
        //public static string DbgString(this businessunit bu)
        //{
        //    return string.Join("\t", new string[] { bu.name, bu.businessunitid.Value.ToString(), (!bu.parentbusinessunitid.IsNull()) ? bu.parentbusinessunitid.Value.ToString() : "null", bu.isdisabled.Value.ToString() });
        //}
        /// <summary>
        /// Escapes "&lt;", "&gt;", "&quot;", "&apos;", and "&amp;" to "&amp;lt;", "&amp;gt;", "&amp;quot;", "&amp;apos;", or "&amp;amp;".
        /// </summary>
        /// <returns>This XML String with "&lt;", "&gt;", "&quot;", "&apos;", and "&amp;" converted to "&amp;lt;", "&amp;gt;", "&amp;quot;", "&amp;apos;", or "&amp;amp;".</returns>
        public static string EscapeXml(this string str)
        {
            return System.Security.SecurityElement.Escape(str);
        }

        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            // argument null checking omitted
            foreach (T item in sequence) action(item);
        }

        public static string FormatFileSize(this long SizeBytes)
        {
            return FormatFileSize(SizeBytes, FileSizeFormat.SizeBytes);
        }

        //public static string FormatFileSize(this long SizeBytes, FileSizeFormat Format)
        //{
        //    string Suffix = "";
        //    string SuffixSingular = "";
        //    long SizeToUse = SizeBytes;
        //    switch (Format)
        //    {
        //        case FileSizeFormat.SizeBytes:
        //            Suffix = "B";
        //            SuffixSingular = "Bytes";
        //            break;
        //        case FileSizeFormat.SizeBits:
        //            Suffix = "b";
        //            SuffixSingular = "bits";
        //            SizeToUse = SizeToUse * 8;
        //            break;
        //        case FileSizeFormat.SpeedBytes:
        //            Suffix = "B/s";
        //            SuffixSingular = "Bytes/s";
        //            break;
        //        case FileSizeFormat.SpeedBits:
        //            Suffix = "b/s";
        //            SuffixSingular = "bits/s";
        //            SizeToUse = SizeToUse * 8;
        //            break;
        //        default:
        //            break;
        //    }
        //    if (SizeToUse >= 1125899906842624)
        //    {
        //        Decimal size = Decimal.Divide(SizeToUse, 1125899906842624);
        //        return String.Format("{0:##.##} P{1}", size, Suffix);
        //    }
        //    if (SizeToUse >= 1099511627776)
        //    {
        //        Decimal size = Decimal.Divide(SizeToUse, 1099511627776);
        //        return String.Format("{0:##.##} T{1}", size, Suffix);
        //    }
        //    if (SizeToUse >= 1073741824)
        //    {
        //        Decimal size = Decimal.Divide(SizeToUse, 1073741824);
        //        return String.Format("{0:##.##} G{1}", size, Suffix);
        //    }
        //    else if (SizeToUse >= 1048576)
        //    {
        //        Decimal size = Decimal.Divide(SizeToUse, 1048576);
        //        return String.Format("{0:##.##} M{1}", size, Suffix);
        //    }
        //    else if (SizeToUse >= 1024)
        //    {
        //        Decimal size = Decimal.Divide(SizeToUse, 1024);
        //        return String.Format("{0:##.##} K{1}", size, Suffix);
        //    }
        //    else if (SizeToUse > 0 & SizeToUse < 1024)
        //    {
        //        Decimal size = SizeToUse;
        //        return String.Format("{0:##.##} {1}", size, SuffixSingular);
        //    }
        //    else
        //    {
        //        return String.Format("0 {0}", SuffixSingular);
        //    }
        //}
        public static string FormatFileSize(this long sizeBytes, FileSizeFormat format = FileSizeFormat.SizeBytes)
        {
            Func<FileSizeFormat, long, long, string> getSuffix = (FileSizeFormat _format, long _size, long _baseline) =>
            {
                string pfx = string.Empty;

                string sfx = string.Empty;

                #region suffix
                switch (_format)
                {
                    case FileSizeFormat.SizeBits:
                        sfx = (_size < 1024) ? "bits" : "b";
                        break;
                    case FileSizeFormat.SpeedBytes:
                        sfx = (_size < 1024) ? "Bytes/s" : "B/s";
                        break;
                    case FileSizeFormat.SpeedBits:
                        sfx = (_size < 1024) ? "bits/s" : "b/s";
                        break;
                    default:
                    case FileSizeFormat.SizeBytes:
                        sfx = (_size < 1024) ? "Bytes" : "B";
                        break;
                }
                #endregion

                #region prefix
                if (_baseline > 0)
                {
                    switch (_baseline)
                    {
                        case pbyte:
                            pfx = "P";
                            break;
                        case tbyte:
                            pfx = "T";
                            break;
                        case gbyte:
                            pfx = "G";
                            break;
                        case mbyte:
                            pfx = "M";
                            break;
                        case kbyte:
                            pfx = "K";
                            break;
                    }
                }
                #endregion

                return string.Format("{0}{1}", pfx, sfx);
            };

            Func<long, long> getBaseUnit = (long sizein) =>
            {
                #region returns the closest base unit

                if (sizein >= pbyte)
                {
                    return pbyte;
                }
                else if (sizein >= tbyte)
                {
                    return tbyte;
                }
                else if (sizein >= gbyte)
                {
                    return gbyte;
                }
                else if (sizein >= mbyte)
                {
                    return mbyte;
                }
                else if (sizein >= kbyte)
                {
                    return kbyte;
                }

                return 0;

                #endregion
            };

            if (sizeBytes <= 0)
            {
                return string.Format("0 {0}", getSuffix(format, 0, 0));
            }

            long SizeToUse = (format == FileSizeFormat.SizeBits || format == FileSizeFormat.SpeedBits)
                ? sizeBytes * 8
                : sizeBytes;

            long baseline = getBaseUnit(SizeToUse);

            string suffix = getSuffix(format, SizeToUse, baseline);

            Decimal size = (baseline > 0) ? Decimal.Divide(SizeToUse, baseline) : SizeToUse;

            return string.Format("{0:##.##} {1}", size, suffix);
        }

        /// <summary>
        /// Uses an XmlTextWriter class to format an Xml string.
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public static string FormattedXml(this XmlDocument xmlDoc)
        {
            string formattedXml = string.Empty;
            using (StringWriter sw = new StringWriter())
            {
                XmlTextWriter writer = new XmlTextWriter(sw);
                writer.Formatting = Formatting.Indented;
                xmlDoc.WriteTo(writer);
                formattedXml = sw.ToString();
            }
            return formattedXml;
        }

        /// <summary>
        /// Formats an eleven or ten digit phone number.
        /// </summary>
        /// <param name="phoneNumber">string with an eleven or ten digit phone number</param>
        /// <returns><example>1-234-567-8900</example></returns>
        public static string FormatUSPhoneNumber(this System.String phoneNumber)
        {
            double result = 0;
            phoneNumber = Regex.Replace(phoneNumber, @"[^0-9]", "");
            phoneNumber = Regex.Replace(phoneNumber, @"/^1?(\d{3})(\d{3})(\d{4})(\d*)$/", "");
            if (double.TryParse(phoneNumber, out result))
            {
                switch (phoneNumber.Length)
                {
                    case 10: return result.ToString("1-###-###-####");
                    case 11: return result.ToString("#-###-###-####");
                    default: return phoneNumber;
                }
            }
            else
            {
                return phoneNumber;
            }
        }

        /// <summary>
        /// Converts the string representation of a Guid to its Guid equivalent. A return value indicates whether the operation succeeded. 
        /// .NET4.0 and later use Guid.TryParse
        /// </summary>
        /// <param name="guid">A <see langword="System.Guid"/> object to receive the converted <see langword="System.Guid"/> value of this string on successful conversion.</param>
        /// <value><see langword="true" /> if <paramref name="value"/> was converted successfully; otherwise, <see langword="false" />.</value>
        /// <exception cref="ArgumentNullException">Thrown if <pararef name="guid"/> is <see langword="null"/>.</exception>
        /// <remarks>From geekswithblogs.net/colinbo/archive/2006/01/18/66307.aspx</remarks>
        public static bool GuidTryParse(this string value, out System.Guid guid)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            Regex format = new Regex(
                "^[A-Fa-f0-9]{32}$|" +
                "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
            Match match = format.Match(value);
            if (match.Success)
            {
                guid = new Guid(value);
                return true;
            }
            else
            {
                guid = Guid.Empty;
                return false;
            }
        }

        /// <summary>
        /// Invokes a function that returns a long value as many times as indicated by timesToRun.
        /// </summary>
        /// <param name="timesToRun">Number of times to run the function.</param>
        /// <returns>IEnumerable of long values returned by the function.</returns>
        public static IEnumerable<long> InvokeIterate(this Func<long> actionToRun, int timesToRun)
        {
            for (int i = 0; i < timesToRun; i++)
            {
                yield return actionToRun.Invoke();
            }
        }

        /// <summary>
        /// Invokes an action as many times as indicated by timesToRun.
        /// </summary>
        /// <param name="actionToRun"></param>
        /// <param name="timesToRun"></param>
        public static void InvokeIterate(this Action actionToRun, int timesToRun)
        {
            for (int i = 0; i < timesToRun; i++)
            {
                actionToRun.Invoke();
            }
        }

        /// <summary>
        /// Determines if a string value can be converted to a System.GUID data type.
        /// </summary>
        /// <returns>Returns true if the string can be converted to a System.Guid data type, otherwise false.</returns>
        public static bool IsGuid(this string value)
        {
            if (value != null)
            {
                Regex guidRegEx = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
                return guidRegEx.IsMatch(value);
            }
            return false;
        }

        /// <summary>
        /// Determines if an object is null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return (obj == null);
        }

        /// <summary>
        /// Returns true if the string is null, empty, or whitespace.
        /// </summary>
        /// <returns>Returns true if the string is null, empty or whitespace, otherwise false.</returns>
        public static bool IsNullEmptyOrWhitespace(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return string.IsNullOrEmpty(value.Trim());
        }

        /// <summary>
        /// Use this in cases when you're too lazy to type "String.IsNullOrEmpty(string)".
        /// </summary>
        /// <param name="inputSentence">this is the string being extended.  it probably contains some very important information</param>
        /// <returns>Returns true if the string is null or empty, otherwise false, indicating that the string is not null or string.Empty.</returns>
        public static bool IsNullOrEmpty(this System.String value)
        {
            if (value != null)
            {
                return (value.Length == 0);
            }
            return true;
        }

        /// <summary>
        /// Determines if a string is a numeric value.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumeric(this System.String s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        /// <summary>
        /// Determines whether or not the string is valid xml.
        /// </summary>
        /// <param name="value">This string to validate.</param>
        /// <returns>True if the string is valid xml, otherwise false.</returns>
        public static bool IsXml(this string value)
        {
            try
            {
                XElement element = XElement.Parse(value);
                return true;
            }
            catch (System.Xml.XmlException)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the number of lines in a string.  Lines are denoted by \\r\\n.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long Lines(this string value)
        {
            List<string> lines = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return lines.Count;
        }

        /// <summary>
        /// Stops, resets the current stopwatch, then gets the amount of time it takes to process an action a given number of times before stopping the stopwatch and returning the Elapsed property.
        /// </summary>
        /// <param name="actionToRun">The action to run.</param>
        /// <param name="timesToRun">Number of times to run the action.</param>
        /// <returns></returns>
        public static TimeSpan MeasureProcess(this Stopwatch sw, Action actionToRun, int timesToRun)
        {
            if (sw.IsRunning)
            {
                sw.Stop();
            }

            sw.Reset();
            sw.Start();

            actionToRun.InvokeIterate(timesToRun);

            sw.Stop();
            return sw.Elapsed;
        }

        /// <summary>
        /// Creates a new xml attribute with the specified name.
        /// </summary>
        public static XmlAttribute NewAttribute(this XmlDocument xmlDoc, string attributeName)
        {
            return xmlDoc.NewAttribute(attributeName, string.Empty);
        }

        /// <summary>
        /// Creates a new xml attribute with the specified name and value.
        /// </summary>
        public static XmlAttribute NewAttribute(this XmlDocument xmlDoc, string attributeName, object attributeValue)
        {
            attributeName = attributeName.Replace(" ", "_");
            XmlAttribute retAttr = xmlDoc.CreateAttribute(attributeName);
            if (!attributeValue.IsNull())
            {
                retAttr.Value = attributeValue.ToString();
            }
            return retAttr;
        }

        /// <summary>
        /// Creates a new xml node.
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public static XmlNode NewNode(this XmlDocument xmlDoc, string tagName)
        {
            return xmlDoc.NewNode(tagName, string.Empty);
        }

        /// <summary>
        /// Creates a new xml node.
        /// </summary>
        public static XmlNode NewNode(this XmlDocument xmlDoc, string tagName, object innerText)
        {
            tagName = tagName.Replace(" ", "_");
            XmlNode newNode = xmlDoc.CreateNode(System.Xml.XmlNodeType.Element, tagName, string.Empty);
            if (!innerText.IsNull())
            {
                newNode.InnerText = innerText.ToString();
            }
            return newNode;
        }

        /// <summary>
        /// Removes all non-numeric characters from a string.
        /// </summary>
        public static string NumericOnly(this System.String toFormat)
        {
            return Regex.Replace(toFormat, "[^0-9]", string.Empty);
        }

        /// <summary>
        ///  Remove all others chars but letters, numbers, and underscores
        /// </summary>
        public static string RemoveIllegalCharacters(this System.String inputStr)
        {
            return Regex.Replace(inputStr, "/[^\\w\\s]/g", string.Empty);
        }

        /// <summary>
        /// Option to format the xml output when saving.
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="filePath"></param>
        /// <param name="asFormattedXml"></param>
        public static void Save(this XmlDocument xmlDoc, string filePath, bool asFormattedXml)
        {
            XmlDocument formattedDoc = new XmlDocument();
            if (asFormattedXml)
            {
                formattedDoc.LoadXml(xmlDoc.FormattedXml());
            }
            else
            {
                formattedDoc.LoadXml(xmlDoc.OuterXml);
            }
            formattedDoc.Save(filePath);
        }

        public static bool StartsWith(this string thisString, string[] prefixes)
        {
            foreach (string prefix in prefixes)
            {
                if (thisString.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Strips HTML formatting from a string.
        /// </summary>
        /// <param name="inputString">string to format</param>
        /// <returns>sanitized string</returns>
        public static string StripHtml(this System.String inputString)
        {
            //string HTML_TAG_PATTERN = "<.*?>";
            return Regex.Replace(inputString, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Removes the leading HTML BR tags from a string.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string StripLeadBreaks(this System.String inputString)
        {
            //string LEAD_BR_PATTERN = @"^(\s*<[Bb][Rr]\s?/?>)+";
            return System.Text.RegularExpressions.Regex.Replace(inputString, @"^(\s*<[Bb][Rr]\s?/?>)+", string.Empty).Trim();
        }

        /// <summary>
        /// Invokes the function the number of times indicated in the present value.
        /// </summary>
        /// <param name="timesToExecute"></param>
        /// <param name="actionToRun"></param>
        /// <returns></returns>
        public static IEnumerable<long> Times(this int timesToExecute, Func<long> actionToRun)
        {
            for (int i = 0; i < timesToExecute; i++)
            {
                yield return actionToRun.Invoke();
            }
        }

        /// <summary>
        /// Invokes a given action the number of times indicated in the present value.
        /// </summary>
        /// <param name="timesToExecute"></param>
        /// <param name="actionToRun"></param>
        public static void Times(this int timesToExecute, Action actionToRun)
        {
            for (int i = 0; i < timesToExecute; i++)
            {
                actionToRun.Invoke();
            }
        }

        //public static string Spew(this TimeSpan ts)
        //{
        //}
        public static string ToString(this DateTime? dateTime, string format)
        {
            return dateTime.ToString(format, string.Empty);
        }

        public static string ToString(this DateTime? dateTime, string format, string returnIfNull)
        {
            return dateTime.HasValue ? ((DateTime) dateTime).ToString(format) : returnIfNull;
        }

        /// <summary>
        /// Truncates a sentence to the first space before the given length.
        /// </summary>
        /// <param name="inputSentence">the sentence to truncate</param>
        /// <param name="length">maximum length of the truncated string</param>
        /// <returns></returns>
        public static string TruncateSentence(this System.String inputSentence, int length)
        {
            return inputSentence.TruncateSentence(length, true, false);
        }

        /// <summary>
        /// Truncates a sentence and appends an ellipsis.
        /// </summary>
        /// <param name="inputSentence">the sentence to truncate</param>
        /// <param name="length">maximum length of the truncated string</param>
        /// <returns></returns>
        public static string TruncateSentence(this System.String inputSentence, int length, bool showEllipsis)
        {
            return inputSentence.TruncateSentence(length, showEllipsis, false);
        }

        /// <summary>
        /// Truncates a sentence and appends an ellipsis.
        /// </summary>
        /// <param name="inputSentence">sentence to truncate</param>
        /// <param name="length">max length</param>
        /// <param name="showEllipsis">show a trailing ellipsis if the string was truncated</param>
        /// <param name="breakAfterWord">prevent truncation in the middle of a word by stopping at the last available whitespace area</param>
        /// <returns></returns>
        public static string TruncateSentence(this System.String inputSentence, int length, bool showEllipsis, bool breakAfterWord)
        {
            if (inputSentence.Length > length)
            {
                inputSentence = inputSentence.Substring(0, length);
                if (inputSentence.LastIndexOf(" ") > 0)
                {
                    inputSentence = inputSentence.Substring(0, inputSentence.LastIndexOf(" "));
                }
                if (breakAfterWord)
                {
                }
                if (showEllipsis)
                {
                    inputSentence = string.Concat(inputSentence, "...");
                }
            }
            return inputSentence;
        }

        /// <summary>
        /// Unescapes "&amp;lt;", "&amp;gt;", "&amp;quot;", "&amp;apos;", and "&amp;amp;" to "&lt;", "&gt;", "&quot;", "&apos;", or "&amp;".
        /// </summary>
        /// <returns>This string with "&amp;lt;", "&amp;gt;", "&amp;quot;", "&amp;apos;", and "&amp;amp;" converted to "&lt;", "&gt;", "&quot;", "&apos;", or "&amp;".</returns>
        public static string UnescapeXml(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            StringBuilder sb = null;
            int length = str.Length;
            int startIndex = 0;
            while (true)
            {
                int index = str.IndexOf('&', startIndex);
                if (index == -1)
                {
                    if (sb == null)
                    {
                        return str;
                    }
                    sb.Append(str, startIndex, length - startIndex);
                    return sb.ToString();
                }

                if (sb == null)
                {
                    sb = new StringBuilder();
                }

                sb.Append(str, startIndex, index - startIndex);
                sb.Append(GetUnescapeSequence(str, index, out startIndex));
            }
        }

        /// <summary>
        /// Returns the number of words in a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Words(this string value)
        {
            MatchCollection collection = Regex.Matches(value, @"[\S]+");
            return collection.Count;
        }

        /// <summary>
        /// Gets the next instance of "&amp;lt;", "&amp;gt;", "&amp;quot;", "&amp;apos;", or "&amp;amp;" and returns the unescaped value ("&lt;", "&gt;", "&quot;", "&apos;", or "&amp;").
        /// </summary>
        /// <param name="str">The xml string to check for escape characters.</param>
        /// <param name="index">The index to start checking.</param>
        /// <param name="newIndex">The new index after the escaped sequence is replaced by the unescaped sequence.</param>
        /// <returns>The unescape sequence for the corresponding string.</returns>
        private static string GetUnescapeSequence(string str, int index, out int newIndex)
        {
            string[] escapePairs = new string[] { "<", "&lt;", ">", "&gt;", "\"", "&quot;", "'", "&apos;", "&", "&amp;" };
            int num = str.Length - index;
            int length = escapePairs.Length;

            for (int i = 0; i < length; i += 2)
            {
                string val = escapePairs[i];
                string esc = escapePairs[i + 1];
                int len = esc.Length;
                if (len <= num && string.Compare(esc, 0, str, index, len, StringComparison.Ordinal) == 0)
                {
                    newIndex = index + esc.Length;
                    return val;
                }
            }

            newIndex = index + 1;
            char ch = str[index];
            return ch.ToString();
        }

        private static string TruncateString(string value, int max)
        {
            if (!string.IsNullOrEmpty(value) && max > 0)
            {
                value = value.Length > max
                    ? value.Substring(0, max)
                    : value;
            }
            return value;
        }

        #endregion Methods
    }
}