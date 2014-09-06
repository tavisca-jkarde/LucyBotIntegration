using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucy.Core;
using Lucy.Core.Contracts;
using Lucy.Core.Model;
using System.Collections.Generic;
using agsXMPP;

namespace Lucy.Tests
{
    [TestClass]
    public class ChatBotFixtures
    {
        ICommandAdapter _cmdAdapter = new CommandAdapter();

        [TestInitialize]
        public void InitializeChatBotsHashSet()
        {
            HashSet<ICanChat> _chatBots = new HashSet<ICanChat>();
        }

        [TestMethod]
        public void BotWithCorrectAuthenticationDetailsShouldBeLoggedIn()
        {
            string user = "114716_1167039";
            string pwd = "bottheeva";

            ICanChat chatter = new ChatBot(_cmdAdapter, user, pwd);
            Assert.IsTrue(chatter.Login());
        }

        [TestMethod]
        public void BotWithInCorrectAuthenticationDetailsShouldNotBeLoggedIn()
        {
            string user = "114716_1167039";
            string pwd = "bosadsadast";

            ICanChat chatter = new ChatBot(_cmdAdapter, user, pwd);
            Assert.IsFalse(chatter.Login());
        }

        //[TestMethod]
        /*
         * How to assert this test as once bot gets connected bot starts listening to chat and goes in infinite loop
         */
        /*public void AddingValidBotToValidRoomShouldAddBotToRoom()
        {
            string user = "114716_1167039";
            string pwd = "bottheeva";
            Jid room = "114716_tavisca@conf.hipchat.com";
            string nickName = "Lucy Bot";
            ChatRoom chatRoom = new ChatRoom();
            ICanChat chatter = new ChatBot(_cmdAdapter, user, pwd);
            chatter.Login();
            chatter.ConnectToRoom(room,nickName);
            
        }*/

        [TestMethod]
        public void BotShouldQuitAfterGettingQuitMessage()
        {
            string user = "114716_1167039";
            string pwd = "bottheeva";
            Jid room = "114716_tavisca@conf.hipchat.com";
            string nickName = "Lucy Bot";
            ChatRoom chatRoom = new ChatRoom();
            ICanChat chatter = new ChatBot(_cmdAdapter, user, pwd);
            chatter.Login();
            chatter.ConnectToRoom(room, nickName);
        }

        /*
         How to assert this test as once bot gets connected bot starts listening to chat and goes in infinite loop
         
        [TestMethod]
        public void ConnectToInvalidChatRoomShouldAddChatterIntoChatRoom()
        {
            string user = "114716_1167039";
            string pwd = "bottheeva";
            Jid room = "114716_taviscasda@conf.hipchat.com";
            string nickName = "Lucy Bot";
            ICanChat chatter = new ChatBot(_cmdAdapter, user, pwd);
            chatter.Login();
            chatter.ConnectToRoom(room, nickName);
            Assert.IsFalse(true);
        }

        [TestMethod]
        public void ConnectTovalidChatRoomShouldAddChatterIntoChatRoom()
        {
            string user = "114716_1167039";
            string pwd = "bottheeva";
            Jid room = "114716_tavisca@conf.hipchat.com";
            string nickName = "Lucy Bot";
            ICanChat chatter = new ChatBot(_cmdAdapter, user, pwd);
            chatter.Login();
            chatter.ConnectToRoom(room, nickName);
            Assert.IsFalse(true);
        }*/

    }
}
