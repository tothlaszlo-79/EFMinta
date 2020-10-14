using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using DataAccessLayer.Controller;
using DataAccessLayer.AdditionalModels;
using System.Linq;


namespace MintaUnitTest
{
    [TestClass]
    public class UnitTest3
    {
        TesztClass teszt = new TesztClass();

        [TestMethod]
        public void TestMethod1()
        {
            var valami = teszt.GetAll();
            Assert.IsNotNull(valami);
        }
    }
}
