using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucy.Core.Contracts;
using Lucy.Core;
using Moq;

namespace Lucy.Tests
{
    [TestClass]
    public class ChatRoomFixtures
    {
        [TestMethod]
        public void IfRoomIsNotAvailableThenThrowException()
        {
        }
        private ChatRoom _chatRoom;
        private Mock<ICanChat> _chatterMock;

        [TestInitialize]
        public void InitializeChatRoom()
        {
            _chatRoom = new ChatRoom();
            _chatterMock = new Mock<ICanChat>();
        }

        [TestCleanup]
        public void CloseChatRoom()
        {
            _chatRoom = null;
            _chatterMock = null;
        }
        
        [TestMethod]
        public void EnterIntoRoomOnceShouldAddUserToTheRoom()
        {
            _chatRoom.Join(_chatterMock.Object);
        }

        [TestMethod]
        public void EnterIntoRoomMultipleTimesShouldAddUserToTheChatRoomOnlyOnce()
        {
            _chatRoom.Join(_chatterMock.Object);
            _chatRoom.Join(_chatterMock.Object);
        }

        [TestMethod]
        public void ExitFromRoomOnceShouldRemoveUserFromTheRoom()
        {
            throw new NotImplementedException();
        }


        [TestMethod]
        public void ExitFromRoomMultipleTimesShouldRemoveUserFromTheRoomOnce()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SendMessageToAvailableUserInChatRoomShouldReturnTrue()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SendMessageToUnavailableUserInChatRoomShouldReturnFalse()
        {
            throw new NotImplementedException();
        }
    }
}
