using Lucy.Core.Contracts;
using AIMLbot;
using Lucy.Core.Model;
using System.Json;

namespace Lucy.Core
{
    public class CommandAdapter : ICommandAdapter
    {
        public Command Translate(string message)
        {
            var command = new Command();
            if (message == null)
            {
                throw new CustomException
                {
                    ErrorCode = 102,
                    ErrorDetails = "Message Cannot be Null"
                };
            }

            if (message.Equals(""))
            {
                throw new CustomException
                {
                    ErrorCode = 101,
                    ErrorDetails = "Message Cannot be Empty"
                };
            }

            var translator = new Bot();
            translator.loadSettings();
            var user = new User("saifuddin", translator);
            translator.isAcceptingUserInput = false;
            translator.loadAIMLFromFiles();
            translator.isAcceptingUserInput = true;
            var request = new Request(message, user, translator);
            var result = translator.Chat(request);
            var output = result.Output;
            output = output.Remove(output.Length - 1);
            if (output.Equals("I dont have answer for this question"))
            {
                throw new CustomException
                {
                    ErrorCode = 103,
                    ErrorDetails = "Invalid Message"
                };
            }
            var jsonObj = JsonValue.Parse(output);

            command.Type = (string)jsonObj["type"];

            if (jsonObj.ContainsKey("build"))
            {
                command.Arguments.Add("build", (string)jsonObj["build"]);
            }

            if (jsonObj.ContainsKey("commitId"))
            {
                command.Arguments.Add("commitId", (string)jsonObj["commitId"]);
            }

            if (jsonObj.ContainsKey("pipeline_name"))
            {
                command.Arguments.Add("pipeline_name", (string)jsonObj["pipeline_name"]);
            }

            if (jsonObj.ContainsKey("query_name"))
            {
                command.Arguments.Add("query_name", (string)jsonObj["query_name"]);
                return command;
            }

            if (jsonObj.ContainsKey("sp_name"))
            {
                command.Arguments.Add("sp_name", (string)jsonObj["sp_name"]);
            }

            if (jsonObj.ContainsKey("args"))
            {
                var argumentsString = (string)jsonObj["args"];
                var argumentsList = argumentsString.Split(' ');

                for (var index = 0; index <= argumentsList.Length - 1; index++)
                {
                    command.Arguments.Add(argumentsList[index], argumentsList[++index]);
                }
            }
            return command;
        }
    }
}
