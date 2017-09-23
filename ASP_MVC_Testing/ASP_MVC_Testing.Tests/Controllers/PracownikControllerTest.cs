using ASP_MVC_Testing.Controllers;
using ASP_MVC_Testing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP_MVC_Testing.Tests.Controllers
{
    [TestClass]
   public  class PracownikControllerTest
    {

        [TestMethod]
        public void Test_Index_Return_View()
        {
            var context = new FakeWypoContext();
            var controller = new PracownicyController(context);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("Add", result.ViewName);
        }

        [TestMethod]
        public void Test_Display_Type()
        {
            var context = new FakeWypoContext();
            context.Pracownicy = new[] {
                new Pracownik { Imie = "jan",Nazwisko = "Kowalski", Pesel = "115", StanowiskoId = 1 },
                 new Pracownik { Imie = "jan2",Nazwisko = "Kowalski2", Pesel = "185", StanowiskoId = 2 },
                  new Pracownik { Imie = "jan3",Nazwisko = "Kowalski3", Pesel = "915", StanowiskoId = 3 },
            }.AsQueryable();

            var controller = new PracownicyController(context);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(typeof(List<Pracownik>), result.Model.GetType());
        }

        [TestMethod]
        public void Test_Detalis_Return()
        {
            var context = new FakeWypoContext();
            context.Pracownicy = new[] {
                new Pracownik {PracownikId = 1, Imie = "jan",Nazwisko = "Kowalski", Pesel = "115"},
                 new Pracownik { PracownikId = 2,Imie = "jan2",Nazwisko = "Kowalski2", Pesel = "185" },
                  new Pracownik {PracownikId = 3, Imie = "jan3",Nazwisko = "Kowalski3", Pesel = "915" },
            }.AsQueryable();

            var controller = new PracownicyController(context);
            var result = controller.Details(2) as ViewResult;
            var prac = (Pracownik)result.Model;
            Assert.AreEqual("185", prac.Pesel);
        }

        [TestMethod]
        public void Test_DeleteView()
        {
            var context = new FakeWypoContext();
            context.Pracownicy = new[] {
                new Pracownik {PracownikId = 1, Imie = "jan",Nazwisko = "Kowalski", Pesel = "115"},
                 new Pracownik { PracownikId = 2,Imie = "jan2",Nazwisko = "Kowalski2", Pesel = "185" },
                  new Pracownik {PracownikId = 3, Imie = "jan3",Nazwisko = "Kowalski3", Pesel = "915" },
            }.AsQueryable();


            var controller = new PracownicyController(context);
            var result = controller.Delete(2) as ViewResult;
            var prac = (Pracownik)result.Model;
            Assert.AreEqual("185", prac.Pesel);
        }

        [TestMethod]
        public void Test_Pracownik_Index_Return_Count()
        {
            var context = new FakeWypoContext();
            context.Pracownicy = new[] {
                new Pracownik { Imie = "jan",Nazwisko = "Kowalski", Pesel = "115", StanowiskoId = 1 },
                 new Pracownik { Imie = "jan2",Nazwisko = "Kowalski2", Pesel = "185", StanowiskoId = 2 },
                  new Pracownik { Imie = "jan3",Nazwisko = "Kowalski3", Pesel = "915", StanowiskoId = 3 },
            }.AsQueryable();

            var controller = new PracownicyController(context);
            var result = controller.Index() as ViewResult;
            var pracownik = (IEnumerable<Pracownik>)result.Model;
            Assert.AreEqual(3, pracownik.Count());
        }

        [TestMethod]
        public void Test_Pracownik_IndexView()
        {
            var context = new FakeWypoContext();
            context.Pracownicy = new[] {
                new Pracownik { Imie = "jan",Nazwisko = "Kowalski", Pesel = "115", StanowiskoId = 1 },
                 new Pracownik { Imie = "jan2",Nazwisko = "Kowalski2", Pesel = "185", StanowiskoId = 2 },
                  new Pracownik { Imie = "jan3",Nazwisko = "Kowalski3", Pesel = "915", StanowiskoId = 3 },
            }.AsQueryable();

            var controller = new PracownicyController(context);
            var result = controller.Index() as ViewResult;
            var stanowisko = (IEnumerable<Pracownik>)result.Model;
            Assert.AreEqual("jan", stanowisko.First().Imie);
            Assert.AreEqual("Kowalski", stanowisko.First().Nazwisko);
            Assert.AreEqual("115", stanowisko.First().Pesel);
            Assert.AreEqual(1, stanowisko.First().StanowiskoId);
        }

        

        [TestMethod]
        public void Test_Route_PracownikId_Edit()
        {
            // Arrange
            var context = new FakeHttpContextForRouting(requestUrl: "~/Pracownicy/Edit/2");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Pracownicy", routeData.Values["controller"]);
            Assert.AreEqual("Edit", routeData.Values["action"]);
            Assert.AreEqual("2", routeData.Values["id"]);
        }

        [TestMethod]
        public void Test_def_Route()
        {
            // Arrange
            var context = new FakeHttpContextForRouting(requestUrl: "~/Pracownicy");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Pracownicy", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
        }

        [TestMethod]
        public void Test_Route_PracownikId()
        {
            // Arrange
            var context = new FakeHttpContextForRouting(requestUrl: "~/Pracownicy/Details/2");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Pracownicy", routeData.Values["controller"]);
            Assert.AreEqual("Details", routeData.Values["action"]);
            Assert.AreEqual("2", routeData.Values["id"]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_Details_Exception()
        {
            var context = new FakeWypoContext();
             context.Pracownicy = new[] {
                new Pracownik {PracownikId = 1, Imie = "jan",Nazwisko = "Kowalski", Pesel = "115"},
                 new Pracownik { PracownikId = 2,Imie = "jan2",Nazwisko = "Kowalski2", Pesel = "185" },
                  new Pracownik {PracownikId = 3, Imie = "jan3",Nazwisko = "Kowalski3", Pesel = "915" }
            }.AsQueryable();

            var controller = new PracownicyController(context);
            var result = controller.Details(4);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

    }
}
