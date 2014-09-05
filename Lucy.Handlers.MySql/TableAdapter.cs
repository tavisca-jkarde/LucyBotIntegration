using Lucy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lucy.Handlers.MySql
{
    public class TableAdapter
    {
        public XmlDocument ToXml(DataTable table)
        {
            const string START_ROOT_TAG = "<mysqldata>";
            const string END_ROOT_TAG = "</mysqldata>";
            const string START_TABLE_TAG = "<table>";
            const string END_TABLE_TAG = "</table>";
            const string START_ROW_TAG = "<row>";
            const string END_ROW_TAG = "</row>";
            string Data_Row = null;
            string xmlData = START_ROOT_TAG + START_TABLE_TAG;
            foreach (DataRow row in table.Rows)
            {
                xmlData = xmlData + START_ROW_TAG;
                foreach (DataColumn col in table.Columns)
                {
                    Data_Row = "<column name=\"" + col.ColumnName + "\" value=\"" + row[col.ColumnName].ToString() + "\"/>";
                    xmlData = xmlData + Data_Row;
                }
                xmlData = xmlData + END_ROW_TAG;

            }
            xmlData = xmlData + END_TABLE_TAG + END_ROOT_TAG;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlData);
            return xmlDoc;
        }
    }
}
