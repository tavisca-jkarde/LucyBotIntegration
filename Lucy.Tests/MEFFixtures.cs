using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lucy.Infrastructure;

namespace Lucy.Tests
{
    [TestClass]
    public class MEFFixtures
    {
        DependencyContainer client = new DependencyContainer();

        [TestMethod]
        public void OnRegisterShouldAddToDictionary()
        {
            var objectRegistered = client.Register<IDependencyContainer, DependencyContainer>("test");
            Assert.AreEqual(1, client.DictionaryCount());
        }

        [TestMethod]
        public void OnRegisterWithNullArgumentShouldThrow()
        {
            try
            {
                client.Register(null, null, "test");
            }
            catch(Exception ex)
            {
               // Assert.AreEqual(ex,);
            }
        }

        [TestMethod]
        public void OnRegisterWithNullName()
        {
            client.Register<IDependencyContainer, DependencyContainer>();
            Assert.AreEqual(2, client.DictionaryCount());
        }

        [TestMethod]
        public void OnCreateShouldReturnObject()
        {
            var i = client.Register<IDependencyContainer, DependencyContainer>("test");

            var j = client.Create(typeof(DependencyContainer), "test");
        }

        [TestMethod]
        public void OnCreateWithNullArgument()
        {
            try
            {
              var objectRegistered = client.Register<IDependencyContainer, DependencyContainer>("test");
           
              var createObject = client.Create(typeof(DependencyContainer),"test");
            }
            catch (Exception )
            {
                
              
            }
        }

        [TestMethod]
        public void CreatingObjectOfAnUnregisteredImplementationShouldThrow()
        {
            try
            {
                var objectRegistered = client.Register<IDependencyContainer, DependencyContainer>("test");

                var createObject = client.Create(typeof(TypeKey), "testFail");
            }
            catch(Exception)
            {
 
            }
        }


    }
}
