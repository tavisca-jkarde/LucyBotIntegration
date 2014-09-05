using Lucy.Core.Contracts;
using Lucy.Core.Model;
using Lucy.Handlers.MySql.CustomException;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Lucy.Infrastructure;

namespace Lucy.Handlers.MySql
{
    public class MySqlHandler : ICanRecieveMessage
    {
        public IDatabase Database { get; private set; }

        public QueryDataSource QuerySource { get; set; }
        DependencyContainer _dependencyContainerObject = null;
        public MySqlHandler()
        {
            //This needs to be called from somewhere else... 
            //This will register MySqlHandler with MEF
           /* _dependencyContainerObject = new DependencyContainer();
            var SqlHandler = _dependencyContainerObject.Register<ICanRecieveMessage>("Lucy.Handlers.MySql.MySqlHandler,Lucy.Handlers.MySql");
            * Also get Channel Object and call Subscribe on that to register it with Dispatcher
            */
        }
        public XmlDocument Execute(Command command)
        {
            var query = this.QuerySource.GetQuery(command.Arguments);
            var result = this.Database.ExecuteCommand(query);
            return new TableAdapter().ToXml(result);
          
        }


        public void Notify(Message message)
        {
            Command command = (Command)message.Payload;
            XmlDocument xmlDocument = Execute(command);
           //To get IChannel's object...
           // var ChannelObject = _dependencyContainerObject.Create(typeof(IChannel), null);
            Message messageToBeReturned = new Message();
            messageToBeReturned.Topic = "Lucy";
            messageToBeReturned.Payload = xmlDocument;
            //Will work when IChannnel object will be registered...
           // ChannelObject.Send(message, this);
        }
    }

    public class QueryDataSource
    {
        public IDatabase Database { get; private set; }
        private Dictionary<string, string> _commandMapper = new Dictionary<string, string>();

        public QueryDataSource()
        {
            InitialiseCommandMapper();
        }
        private void InitialiseCommandMapper()
        {
            string _configPath = Path.Combine(Environment.CurrentDirectory, "CommandMapper.xml");
            try
            {
                XmlReader reader = XmlReader.Create(_configPath);
                string commandName = null;
                string parameters = null;
                while (reader.Read())
                {

                    if (reader.Name.ToString().Equals("CommandName"))
                        commandName = reader.ReadString();
                    if (reader.Name.ToString().Equals("Parameters"))
                        parameters = reader.ReadString();
                    if (commandName != null && parameters != null)
                    {
                        _commandMapper.Add(commandName, parameters);
                        commandName = null;
                        parameters = null;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public DbCommand GetQuery(Dictionary<string, string> dictionary)
        {
            string Parameters = null;
            string type = null;
            if (dictionary.ContainsKey("query_name"))
                type = "Query";
            else if (dictionary.ContainsKey("sp_name"))
                type = "SP";
            string[] ParameterList = _commandMapper[dictionary["query"]].Split(',');
            for (int i = 0; i < ParameterList.Length; i++)
                Parameters = dictionary[ParameterList[i]] + " ";
            string query = dictionary["query"] + " " + Parameters;
            return this.Database.CreateCommand(query, type);
        }
    }

}
