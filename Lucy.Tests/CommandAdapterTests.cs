using Lucy.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lucy.Tests
{
    [TestClass]
    public class CommandAdapterTests
    {
        [TestMethod]
        public void EmptyMessageShouldRespondWithError()
        {
            const string message = "";
            var commandAdapter = new CommandAdapter();
            try
            {
                var command = commandAdapter.Translate(message);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(101, ex.ErrorCode);
            }
        }

        [TestMethod]
        public void NullMessageShouldRespondWithError()
        {
            const string message = null;
            var commandAdapter = new CommandAdapter();

            try
            {
                var command = commandAdapter.Translate(message);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(102, ex.ErrorCode);
            }
        }

        [TestMethod]
        public void MessageWithWrongCommandShouldRespondWithError()
        {
            const string message = "abc args 10";
            var commandAdapter = new CommandAdapter();
            try
            {
                var command = commandAdapter.Translate(message);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(103, ex.ErrorCode);
            }
        }

        [TestMethod]
        public void MessageWithCommandSpecifiedShouldRespondCorrect()
        {
            const string message = "execute join";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            Assert.AreEqual("sql", command.Type);
        }

        [TestMethod]
        public void MessageWithCommandAndParameterShouldRespondCorrect()
        {
            const string message = "execute join gid 1 pid 2";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            Assert.AreEqual("sql", command.Type);
            if (command.Arguments.ContainsKey("gid"))
            {
                var value = command.Arguments["gid"];
                Assert.AreEqual("1", value);
            }
        }

        [TestMethod]
        public void SqlSelectCommandWithProperFormatShouldRespondCorrect()
        {
            const string message = "execute select All from Employee";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            Assert.AreEqual("sql", command.Type);
            if (command.Arguments.ContainsKey("query_name"))
            {
                var value = command.Arguments["query_name"];
                Assert.AreEqual("select All from Employee", value);
            }
        }

        [TestMethod]
        public void SqlSelectCommandWithRunCommandShouldRespondCorrect()
        {
            const string message = "run select All from Employee";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            Assert.AreEqual("sql", command.Type);
            if (command.Arguments.ContainsKey("query_name"))
            {
                var value = command.Arguments["query_name"];
                Assert.AreEqual("select All from Employee", value);
            }
        }

        [TestMethod]
        public void SqlSelectCommandWithImproperFormatShouldRespondWithError()
        {
            const string message = "select All from Employee";
            var commandAdapter = new CommandAdapter();
            try
            {
                var command = commandAdapter.Translate(message);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(103, ex.ErrorCode);
            }
        }

        [TestMethod]
        public void SqlStoredProcedureCommandWithRunScriptShouldRespondCorrect()
        {
            const string message = "runscript play gid 1 pid 6";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            Assert.AreEqual("sql", command.Type);
            if (command.Arguments.ContainsKey("gid"))
            {
                var value = command.Arguments["gid"];
                Assert.AreEqual("1", value);
            }
            if (command.Arguments.ContainsKey("pid"))
            {
                var value = command.Arguments["pid"];
                Assert.AreEqual("6", value);
            }
        }

        [TestMethod]
        public void GoIntegrationCommandWithSpecifiedFormatShouldRespondCorrect()
        {
            const string message = "build latest pipelinename";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            Assert.AreEqual("GoWithLatest", command.Type);
            if (command.Arguments.ContainsKey("build"))
            {
                var value = command.Arguments["build"];
                Assert.AreEqual("latest", value);
            }

            if (command.Arguments.ContainsKey("pipeline_name"))
            {
                var pipelineName = command.Arguments["pipeline_name"];
                Assert.AreEqual("pipelinename", pipelineName);
            }
        }

        [TestMethod]
        public void GoIntegrationCommandWithImproperFormatShouldThrowError()
        {
            const string message = "abcd latest pipelinename";
            var commandAdapter = new CommandAdapter();
            try
            {
                var command = commandAdapter.Translate(message);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(103, ex.ErrorCode);
            }
        }

        [TestMethod]
        public void GoIntegrationCommandWithSpecifiedCommitIdFormatShouldRespondCorrect()
        {
            const string message = "build commitId 6 pipelinename";
            var commandAdapter = new CommandAdapter();
            var command = commandAdapter.Translate(message);
            Assert.AreEqual("GoWithCommitId", command.Type);
            if (command.Arguments.ContainsKey("commitId"))
            {
                var value = command.Arguments["commitId"];
                Assert.AreEqual("6", value);
            }

            if (command.Arguments.ContainsKey("pipeline_name"))
            {
                var pipelineName = command.Arguments["pipeline_name"];
                Assert.AreEqual("pipelinename", pipelineName);
            }
        }
    }
}
