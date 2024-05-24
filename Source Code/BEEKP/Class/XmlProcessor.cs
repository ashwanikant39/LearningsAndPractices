using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BEEKP.Class
{
    public class XmlProcessor
    {
        Dictionary<string, string> dict;

        public XmlProcessor()
        {
            dict = new Dictionary<string, string>();
        }

        public void AddElement(string key, string value)
        {
            dict.Add(key, value);
        }

        public string GetXML()
        {
            XDocument doc = new XDocument
                (
                   new XElement("documentelement",
                    new XElement("Table1",
                            from keyValue in dict
                            select new XElement(keyValue.Key, keyValue.Value)
                                )
                               )
               );

            return doc.ToString();
        }

        public string GetXML(String TableName)
        {
            XDocument doc = new XDocument
                (
                   new XElement("documentelement",
                    new XElement(TableName,
                            from keyValue in dict
                            select new XElement(keyValue.Key, keyValue.Value)
                                )
                               )
               );

                return doc.ToString();
        }

    }
}