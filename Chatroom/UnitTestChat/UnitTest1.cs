using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chatroom;
namespace UnitTestChat
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_LoginMethod()
        {
            Usuarios  usuarios = new Usuarios();
            string res = usuarios.Login("julian","12345123");
            Assert.AreEqual(res, "julian");
        }
    }
}
