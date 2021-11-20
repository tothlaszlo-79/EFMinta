using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using DataAccessLayer.Controller;
using DataAccessLayer.AdditionalModels;
using System.Linq;

namespace EFMinta
{
    [TestClass]
     public class UnitTest2
    {
        [TestMethod]
        public void GetAll_linkedTest()
        {
            TableWithForigenKeyController controller = new TableWithForigenKeyController();
            var result = controller.GetAll_linked();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTableWithForeignKey()
        {
            TableWithForigenKeyController controller = new TableWithForigenKeyController();
            var result = controller.DeleteTableWithForigenKeyRecord(4);
            Assert.IsTrue(result);
        
        }

        [TestMethod]
        public void GetAllTableWithForeignKey()
        {
            TableWithForigenKeyController controller = new TableWithForigenKeyController();
            var result = controller.GetAll();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByIdTableWithForeignKey()
        {
            TableWithForigenKeyController controller = new TableWithForigenKeyController();
            var result = controller.GetById(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllWithLinkedTableWithForeignKey()
        {
            TableWithForigenKeyController controller = new TableWithForigenKeyController();
            var result = controller.GetAll_linked();
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void GetByIdWithLinkedTableWithForeignKey()
        //{
        //    TableWithForigenKeyController controller = new TableWithForigenKeyController();
        //    var result = controller.GetAll_linked_ID(1);
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void CreateTableWithForeignKey()
        {
           TableWithForigenKeyController controller = new TableWithForigenKeyController();
           var result = controller.CreateTableWithForigenKeyRecord(
                new DataAccessLayer.TableWithForigenKey
                {
                    SajatAdat1 = "Teszt12",
                    SajatAdat2 = DateTime.Now,
                    SajatAdat3 = 123
                },
                1 //Külső tábla kulcs
                );

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ModifyTableWithForeignKey()
        {

            TableWithForigenKeyController controller = new TableWithForigenKeyController();
            var result = controller.ModifyTableWithForigenKeyRecord(
                new DataAccessLayer.TableWithForigenKey
                {
                    nid = 1,
                    SajatAdat1 = "Módosított adat",
                    SajatAdat2 = DateTime.Now,
                    SajatAdat3 = 1979,
                    ForigenKeyTable_id = 2,
                    Active = true
                });

            Assert.IsTrue(result);
        }
    }
}
