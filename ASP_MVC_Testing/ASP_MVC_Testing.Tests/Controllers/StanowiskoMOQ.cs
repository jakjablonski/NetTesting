using ASP_MVC_Testing.Controllers;
using ASP_MVC_Testing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ASP_MVC_Testing.Tests.Controllers
{
    [TestClass]
    public class StanowiskoMOQ
    {
        private StanowiskaController controller = null;
        private IWypoContext repository = null;

        [TestInitialize]
        public void SetUp()
        {
            var stanowiska = new List<Stanowisko>
            {

            };
            var repositoryMock = new Mock<IWypoContext>();
            repositoryMock.Setup(x => x.Stanowiska).Returns(stanowiska.AsQueryable());
            repositoryMock.Setup(x => x.Add(It.IsAny<Stanowisko>())).Callback((object stanowisko) => stanowiska.Add(stanowisko as Stanowisko));
            this.repository = repositoryMock.Object;
            this.controller = new StanowiskaController(this.repository);
        }

        [TestMethod]
        public void MOQCheck_View_Name_Index_Stanowisko()
        {
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void MOQCheck_View_Name_Add_Stanowisko()
        {
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("Add", result.ViewName);
        }

        [TestMethod]
        public void MOQChceck_Type_Index_Stanowisko()
        {
            var stanowiska = new List<Stanowisko>();
            stanowiska.Add(new Stanowisko { StanowiskoId = 1, Nazwa = "stanowisko", Pensja = 3000 });
            stanowiska.Add(new Stanowisko { StanowiskoId = 2, Nazwa = "stanowisko2", Pensja = 400 });

            var result = controller.Index() as ViewResult;
            var model = ((ViewResult)result).Model as List<Stanowisko>;
            Assert.AreEqual(typeof(List<Stanowisko>), result.Model.GetType());

        }

        [TestMethod]
        public void MOQCheck_Index_Count_Stanowisko()
        {
            var stanowiska = new List<Stanowisko>();
            stanowiska.Add(new Stanowisko { StanowiskoId = 1, Nazwa = "stanowisko", Pensja = 3000 });
            stanowiska.Add(new Stanowisko { StanowiskoId = 2, Nazwa = "stanowisko2", Pensja = 400 });

            Mock<IWypoContext> context = new Mock<IWypoContext>();
            context.Setup(x => x.Stanowiska).Returns(stanowiska.AsQueryable());
            var controller = new StanowiskaController(context.Object);

            var result = controller.Index() as ViewResult;
            var model = ((ViewResult)result).Model as List<Stanowisko>;
            Assert.AreEqual(typeof(List<Stanowisko>), result.Model.GetType());
            Assert.IsTrue(model.Count == 2);
        }
        [TestMethod]
        public void MOQTest_Details_Stanowisko()
        {
            Stanowisko stanowisko = new Stanowisko();
            stanowisko.StanowiskoId = 1;
            stanowisko.Nazwa = "stanowisko";
            stanowisko.Pensja = 3000;
            Mock<IWypoContext> context = new Mock<IWypoContext>();
            context.Setup(x => x.FindStanowiskoById(1)).Returns(stanowisko);
            var controller = new StanowiskaController(context.Object);

            var result = controller.Details(1) as ViewResult;
            var resultprac = (Stanowisko)result.Model;
            Assert.AreEqual("stanowisko", resultprac.Nazwa);
            Assert.AreEqual(3000, resultprac.Pensja);
        }



        [TestMethod]
        public void MOQTest_Add_Stanowisko()
        {

            var stanowiska = new Stanowisko { Pracownik = new List<Pracownik>(), Nazwa = "stanowiskotest", Pensja = 3000 };
            this.controller.Create(stanowiska);
            Assert.AreEqual(1, this.repository.Stanowiska.Count());

        }

        [TestMethod]
        public void MOQTest_Delete_Stanowisko()
        {
            Stanowisko stanowisko = new Stanowisko();
            stanowisko.StanowiskoId = 1;
            stanowisko.Nazwa = "stanowisko";
            stanowisko.Pensja = 3000;
            Mock<IWypoContext> context = new Mock<IWypoContext>();
            context.Setup(x => x.FindStanowiskoById(1)).Returns(stanowisko);
            var controller = new StanowiskaController(context.Object);

            var result = controller.Delete(1) as ViewResult;
            var resultprac = (Stanowisko)result.Model;
            Assert.AreEqual("stanowisko", resultprac.Nazwa);
            Assert.AreEqual(3000, resultprac.Pensja);
        }


    }
}
