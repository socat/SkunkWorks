//using System.Web;
namespace HelperLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class XmlHelper : IDisposable
    {
        #region Constructors

        /// <summary>
        /// Peforms common tasks when working with xml data.
        /// </summary>
        public XmlHelper()
        {
        }

        #endregion Constructors

        #region Methods

        public XmlNode CDataNode(string value, XmlDocument xld)
        {
            return xld.CreateCDataSection(value);
        }

        /// <summary>
        /// Dispose this object
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Writes a script tag to display a javascript alert box.
        /// </summary>
        /// <param name="messageText"></param>
        public void DoMessage(string messageText)
        {
            if (System.Web.HttpContext.Current != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<script language=\"javascript\">");
                sb.AppendLine("    alert('" + messageText + "');");
                sb.AppendLine("</script>");
                System.Web.HttpContext.Current.Response.Write(sb.ToString());
            }
        }

        /// <summary>
        /// Formats an Xml document for readability
        /// </summary>
        /// <param name="xmlDoc">An Xml document object</param>
        /// <returns>Formatted Xml String</returns>
        public string FormatXmlString(XmlDocument xmlDoc)
        {
            string sRetVal = String.Empty;
            StringWriter sw = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;
            xmlDoc.WriteTo(writer);
            sRetVal = sw.ToString();
            return sRetVal;
        }

        /// <summary>
        /// Used to create an Xml attribute that can be added to an Xml node.
        /// </summary>
        /// <param name="Name">Name of the new attribute</param>
        /// <param name="Value">Value of the attribute</param>
        /// <param name="xld">XmlDocument parent of the attribute</param>
        /// <returns>An XmlAttribute object</returns>
        public XmlAttribute NewAttribute(String Name, String Value, XmlDocument xld)
        {
            XmlAttribute xa = xld.CreateAttribute(Name);
            xa.Value = Value;
            return xa;
        }

        /// <summary>
        /// Saves a System.Xml.Linq.XDocument object to an xml file.
        /// </summary>
        /// <param name="xld">XDocument to be exported to the file system.</param>
        /// <param name="fileName">The name of the new xml file.</param>
        /// <param name="parentFolderPath">The folder where the new file will be located.</param>
        public void SaveXDocument(XDocument xld, string fileName, string parentFolderPath)
        {
            try
            {

                StringWriter sw = new StringWriter();
                XmlTextWriter writer = new XmlTextWriter(sw);
                writer.Formatting = Formatting.Indented;
                xld.WriteTo(writer);
                if (parentFolderPath.Substring(parentFolderPath.Length - 1, 1) != @"\")
                {
                    parentFolderPath += @"\";
                }
                //string logDir = parentFolderPath + "\\";
                VerifyFolderPath(parentFolderPath);
                fileName = parentFolderPath + fileName;
                StreamWriter sr = File.CreateText(fileName);
                sr.WriteLine(sw.ToString());
                sr.Flush();
                sr.Close();
                sr.Dispose();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Saves an xml file.
        /// </summary>
        /// <param name="xld">Xml Document to be exported to the file system.</param>
        /// <param name="fileName">The name of the new xml file.</param>
        /// <param name="parentFolderPath">The folder where the new file will be located.</param>
        public void SaveXmlFile(XmlDocument xld, string fileName, string parentFolderPath)
        {
            try
            {

                StringWriter sw = new StringWriter();
                XmlTextWriter writer = new XmlTextWriter(sw);
                writer.Formatting = Formatting.Indented;
                xld.WriteTo(writer);
                if (parentFolderPath.Substring(parentFolderPath.Length - 1, 1) != @"\")
                {
                    parentFolderPath += @"\";
                }
                //string logDir = parentFolderPath + "\\";
                VerifyFolderPath(parentFolderPath);
                fileName = parentFolderPath + fileName;
                StreamWriter sr = File.CreateText(fileName);
                sr.WriteLine(sw.ToString());
                sr.Flush();
                sr.Close();
                sr.Dispose();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Overload for XElement
        /// </summary>
        /// <param name="xld"></param>
        /// <param name="fileName"></param>
        /// <param name="parentFolderPath"></param>
        public void SaveXmlFile(XElement xld, string fileName, string parentFolderPath)
        {
            try
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter writer = new XmlTextWriter(sw);
                writer.Formatting = Formatting.Indented;
                xld.WriteTo(writer);
                if (parentFolderPath.Substring(parentFolderPath.Length - 1, 1) != @"\")
                {
                    parentFolderPath += @"\";
                }
                //string logDir = parentFolderPath + "\\";
                VerifyFolderPath(parentFolderPath);
                fileName = parentFolderPath + fileName;
                StreamWriter sr = File.CreateText(fileName);
                sr.WriteLine(sw.ToString());
                sr.Flush();
                sr.Close();
                sr.Dispose();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Creates an Xml Node
        /// Usage: XmlNode.AppendChild(SimpleNode("ElementName", "value", ref XmlDocumentParent)); 
        /// Returns: &lt;...XmlDocumentParent...&gt;&lt;ElementName&gt;value&lt;/ElementName&gt;&lt;/...XmlDocumentParent...&gt;
        /// </summary>
        /// <param name="tagName">Name of the new node</param>
        /// <param name="innerText">Inner text value (use String.Empty if null)</param>
        /// <param name="xld">XmlDocument parent to which this node belongs</param>
        /// <returns></returns>
        public XmlNode SimpleNode(String tagName, String innerText, XmlDocument xld)
        {
            XmlNode retNode = xld.CreateNode(XmlNodeType.Element, tagName, String.Empty);
            if (!string.IsNullOrEmpty(innerText))
            {
                retNode.InnerText = innerText;
            }
            return retNode;
        }

        /// <summary>
        /// Replaces instances of &, ", ', or = with an html entity.
        /// </summary>
        /// <param name="xmlIn">Xml string to encode.</param>
        /// <returns>An xml string with the symbols encoded.</returns>
        public string xmlEncode(string xmlIn)
        {
            xmlIn = xmlIn.Replace("&", "&#38;");
            //xmlIn = xmlIn.Replace("\"", "&#34;");
            //xmlIn = xmlIn.Replace("'", "&#39;");
            //xmlIn = xmlIn.Replace("=", "&#61;");
            return xmlIn;
        }

        /// <summary>
        /// Creates an XmlNode containing complex content.
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="innerXml"></param>
        /// <param name="xld"></param>
        /// <returns></returns>
        private XmlNode ComplexNode(string tagName, string innerXml, XmlDocument xld)
        {
            XmlNode retNode = xld.CreateNode(XmlNodeType.Element, tagName, String.Empty);
            if (!string.IsNullOrEmpty(innerXml))
            {
                retNode.InnerXml = innerXml;
            }
            return retNode;
        }

        /// <summary>
        /// Verifies that a folder exists.  If the folder does not exist, this will create it.
        /// </summary>
        /// <param name="path">Path of the folder.</param>
        private void VerifyFolderPath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        #endregion Methods
    }
}