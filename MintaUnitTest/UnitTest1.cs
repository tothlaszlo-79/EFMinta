using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using DataAccessLayer.Controller;

namespace MintaUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SingleTableGetAll()
        {
            SingleTableController singleTableController = new SingleTableController();
            var eredmeny = singleTableController.GetAll();
            Assert.IsNotNull(eredmeny);
        }
        
        [TestMethod]
        public void SingleTableGetById()
        {
            SingleTableController singleTableController = new SingleTableController();
            var eredmeny = singleTableController.GetById(2002);
            Assert.IsNotNull(eredmeny);
        }

        [TestMethod]
        public void SingleTableAdd()
        {
            SingleTableController singleTableController = new SingleTableController();
            for (int i = 0; i < 1500; i++)
            {

               var result = singleTableController.CreateSingleTableRecord(new SingleTable
                {
                    Adat1 = "HelgaKérdés",
                    Adat2 = 112.05m,
                    Adat3 = DateTime.Now,
                    Adat4 = 1238,
                    Active = true

                });
                Assert.IsTrue(result);
            }
           
        }

        [TestMethod]
        public void SingleTableGetbyAdat()
        {
            SingleTableController singleTableController = new SingleTableController();
            //rekord számot itt kell megadni
            var result = singleTableController.GetByAdat1("Adat");
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void SingleTableDelete()
        {
            SingleTableController singleTableController = new SingleTableController();
            //rekord számot itt kell megadni
            var result = singleTableController.DeleteSingleTableRecord(2002);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SingleTableModify()
        {
            SingleTableController singleTableController = new SingleTableController();
            var result = singleTableController.ModifySingleTableRecord( 
                new SingleTable {
                    nid = 3,
                    Adat1 = "Teszt 200921",
                    Adat2 = 123.0m,
                    Adat3 = DateTime.Now,
                    Adat4 = 123,
                    Active = true
                });
            Assert.IsTrue(result);
        }
    }
}
