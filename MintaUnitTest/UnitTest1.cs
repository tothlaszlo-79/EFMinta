using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using DataAccessLayer.Controller;
using System.Linq;

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
            Assert.IsTrue(eredmeny.Count() > 0);
        }
        
        [TestMethod]
        public void SingleTableGetById()
        {
            SingleTableController singleTableController = new SingleTableController();
            var eredmeny = singleTableController.GetById(1);
            Assert.IsNotNull(eredmeny);
        }

        [TestMethod]
        public void SingleTableAdd()
        {
            SingleTableController singleTableController = new SingleTableController();
            for (int i = 0; i < 2000; i++)
            {

                var result = singleTableController.CreateSingleTableRecord(new SingleTable
                {
                    Adat1 = "Kérdés " + i.ToString(),
                    //Adat1 = "Kérdés",
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
            var result = singleTableController.DeleteSingleTableRecord(1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SingleTableModify()
        {
            SingleTableController singleTableController = new SingleTableController();
            var result = singleTableController.ModifySingleTableRecord( 
                new SingleTable {
                    nid = 2,
                    Adat1 = "Teszt 201024",
                    Adat2 = 123.0m,
                    Adat3 = DateTime.Now,
                    Adat4 = 1234,
                    Active = true
                });
            Assert.IsTrue(result);
        }
    }
}
