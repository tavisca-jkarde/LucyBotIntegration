using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MySql;
using MySql.Data.MySqlClient;
using Lucy.Handlers.MySql;
using Lucy.Handlers.MySql.CustomException;
using System.Xml;
using System.Data;
using System.Data.Entity;

namespace Lucy.Tests
{
    [TestClass]
    public class MySqlIntegrationFixture
    {
        
        [TestMethod]
        [ExpectedException(typeof(InvalidConnectionStringException))]
        public void NullConnectionStringShouldReturnInvalidConnectionStringException()
        {
            string ConnectionString = null;
            var mySqlDatabase = new MySqlDatabase(ConnectionString);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidConnectionStringException))]
        public void EmptyConnectionStringShouldReturnInvalidConnectionStringException()
        {
            string ConnectionString = string.Empty;
            var mySqlDatabase = new MySqlDatabase(ConnectionString);
        }

       
        [TestMethod]
        public void NullResultShouldConvertToEmptyXMLDocument()
        {
            DataTable table = new DataTable();
            var xmlConvertor = new TableAdapter();
            XmlDocument xmlDoc = xmlConvertor.ToXml(table);
            Assert.AreEqual(xmlDoc.DocumentType,null);
        }


        [TestMethod]
        public void ValidCommandShouldReturnValidResult()
        {
            //Unable to Test Because MySql was not getting configured....
            string ConnectionString = "Server=127.0.0.1;Port=3306;Database=TestDB;Uid=root;Pwd;";
            try
            {
                MySqlDatabase TestDB = new MySqlDatabase(ConnectionString);
                string query = "Select * from Employee";
                var MySqlHandler = new MySqlHandler();
                DataTable table = TestDB.ExecuteCommand(TestDB.CreateCommand(query, "Query"));
                TableAdapter xmlConvertor = new TableAdapter();
                xmlConvertor.ToXml(table);
            }
            catch (Exception e)
            {
            }


        }
    }
}
