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
    public class MoqPracownikTest
    {
        private StanowiskaController controller = null;
        private IWypoContext repository = null;

        [TestMethod]
        public void MOQCheck_View_Name_Index()
        {
            Mock<IWypoContext> context = new Mock<IWypoContext>();
            var controller = new PracownicyController(context.Object);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void MOQCheck_View_Name_Add()
        {
            Mock<IWypoContext> context = new Mock<IWypoContext>();
            var controller = new PracownicyController(context.Object);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("Add", result.ViewName);
        }
        [TestMethod]
        public void MOQChceck_Type_Index()
        {
            var pracownicy = new List<Pracownik>();
            pracownicy.Add(new Pracownik { PracownikId = 1, Imie = "jan", Nazwisko = "Kowalski", Pesel = "115" });
            pracownicy.Add(new Pracownik { PracownikId = 2, Imie = "janEK", Nazwisko = "KowalskiII", Pesel = "1152" });

            Mock<IWypoContext> context = new Mock<IWypoContext>();
            context.Setup(x => x.Pracownicy).Returns(pracownicy.AsQueryable());
            var controller = new PracownicyController(context.Object);

            var result = controller.Index() as ViewResult;
            var model = ((ViewResult)result).Model as List<Pracownik>;
            Assert.AreEqual(typeof(List<Pracownik>), result.Model.GetType());

        }

        [TestMethod]
        public void MOQCheck_Index_Count()
        {
            var pracownicy = new List<Pracownik>();
            pracownicy.Add(new Pracownik { PracownikId = 1, Imie = "jan", Nazwisko = "Kowalski", Pesel = "115" });
            pracownicy.Add(new Pracownik { PracownikId = 2, Imie = "janEK", Nazwisko = "KowalskiII", Pesel = "1152" });

            Mock<IWypoContext> context = new Mock<IWypoContext>();
            context.Setup(x => x.Pracownicy).Returns(pracownicy.AsQueryable());
            var controller = new PracownicyController(context.Object);

            var result = controller.Index() as ViewResult;
            var model = ((ViewResult)result).Model as List<Pracownik>;
            Assert.AreEqual(typeof(List<Pracownik>), result.Model.GetType());
            Assert.IsTrue(model.Count == 2);
        }

        [TestMethod]
        public void MOQTest_Details_Pracownik()
        {
            Pracownik pracownik = new Pracownik();
            pracownik.PracownikId = 1;
            pracownik.Imie = "Jan";
            pracownik.Nazwisko = "Kowalski";
            Mock<IWypoContext> context = new Mock<IWypoContext>();
            context.Setup(x => x.FindPracownikById(1)).Returns(pracownik);
            var controller = new PracownicyController(context.Object);

            var result = controller.Details(1) as ViewResult;
            var resultprac = (Pracownik)result.Model;
            Assert.AreEqual("Jan", resultprac.Imie);
            Assert.AreEqual("Kowalski", resultprac.Nazwisko);
        }
        [TestMethod]
        public void MOQTest_Delete_View()
        {
            Pracownik pracownik = new Pracownik();
            pracownik.PracownikId = 1;
            pracownik.Imie = "Jan";
            pracownik.Nazwisko = "Kowalski";
            Mock<IWypoContext> context = new Mock<IWypoContext>();
            context.Setup(x => x.FindPracownikById(1)).Returns(pracownik);
            var controller = new PracownicyController(context.Object);

            var result = controller.Delete(1) as ViewResult;
            var resultprac = (Pracownik)result.Model;
            Assert.AreEqual("Jan", resultprac.Imie);
            Assert.AreEqual("Kowalski", resultprac.Nazwisko);
        }

        [TestMethod]
        public void MOQTest_Edit_Pracownik()
        {
            Pracownik pracownik = new Pracownik();
            pracownik.PracownikId = 1;
            pracownik.Imie = "Jan";
            pracownik.Nazwisko = "Kowalski";
            Mock<IWypoContext> context = new Mock<IWypoContext>(); ;
            context.Setup(x => x.FindPracownikById(2)).Returns(pracownik);
            var controller = new PracownicyController(context.Object);
            var result = controller.Edit(2) as ViewResult;
            ViewResult p = (ViewResult)controller.Edit(2);
            var view = p.ViewName;
            Assert.AreEqual("Edit", view);
        }

        [TestMethod]
        public void MOQTest_Delete_NotNull()
        {
            Pracownik pracownik = new Pracownik();
            pracownik.PracownikId = 2;
            pracownik.Imie = "Jan";
            pracownik.Nazwisko = "Kowalski";
            Mock<IWypoContext> context = new Mock<IWypoContext>();
            context.Setup(x => x.FindPracownikById(2)).Returns(pracownik);
            var controller = new PracownicyController(context.Object);

            var result = controller.Delete(2) as ViewResult;
            Assert.IsNotNull(result);
        }




    }
}
