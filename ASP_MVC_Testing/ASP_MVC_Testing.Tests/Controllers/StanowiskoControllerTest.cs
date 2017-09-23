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
    public class StanowiskoControllerTest
    {

        [TestMethod]
        public void Test_Stanowisko_Index_Return_View()
        {
            var context = new FakeWypoContext();
            var controller = new StanowiskaController(context);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("Add", result.ViewName);
        }

        [TestMethod]
        public void Test_Stanowisko_Display_Type()
        {
            var context = new FakeWypoContext();
            context.Stanowiska = new[] {
                 new Stanowisko { Nazwa= "sprzatacz", Pensja = 2000 , StanowiskoId =1},
                 new Stanowisko { Nazwa= "manager", Pensja = 3000 , StanowiskoId =2},
                 new Stanowisko { Nazwa= "szef", Pensja = 23300 , StanowiskoId =3},
            }.AsQueryable();

            var controller = new StanowiskaController(context);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(typeof(List<Stanowisko>), result.Model.GetType());
        }

        [TestMethod]
        public void Test_Stanowisko_Detalis_Return()
        {

            var context = new FakeWypoContext();
            context.Stanowiska = new[] {
                 new Stanowisko { Nazwa= "sprzatacz", Pensja = 2000 , StanowiskoId =1},
                 new Stanowisko { Nazwa= "manager", Pensja = 3000 , StanowiskoId =2},
                 new Stanowisko { Nazwa= "szef", Pensja = 23300 , StanowiskoId =3},
            }.AsQueryable();

            var controller = new StanowiskaController(context);
            var result = controller.Details(3) as ViewResult;
            var stanowisko = (Stanowisko)result.Model;
            Assert.AreEqual("szef", stanowisko.Nazwa);
            Assert.AreEqual(23300, stanowisko.Pensja);
        }

        [TestMethod]
        public void Test_Stanowisko_DeleteView()
        {
            var context = new FakeWypoContext();
            context.Stanowiska = new[] {
                 new Stanowisko { Nazwa= "sprzatacz", Pensja = 2000 , StanowiskoId =1},
                 new Stanowisko { Nazwa= "manager", Pensja = 3000 , StanowiskoId =2},
                 new Stanowisko { Nazwa= "szef", Pensja = 23300 , StanowiskoId =3},
            }.AsQueryable();

            var controller = new StanowiskaController(context);
            var result = controller.Delete(3) as ViewResult;
            var stanowisko = (Stanowisko)result.Model;
            Assert.AreEqual("szef", stanowisko.Nazwa);
            Assert.AreEqual(23300, stanowisko.Pensja);
        }

        [TestMethod]
        public void Test_Stanowisko_IndexView()
        {
            var context = new FakeWypoContext();
            context.Stanowiska = new[] {
                 new Stanowisko { Nazwa= "sprzatacz", Pensja = 2000 , StanowiskoId =1},
                 new Stanowisko { Nazwa= "manager", Pensja = 3000 , StanowiskoId =2},
                 new Stanowisko { Nazwa= "szef", Pensja = 23300 , StanowiskoId =3},
            }.AsQueryable();

            var controller = new StanowiskaController(context);
            var result = controller.Index() as ViewResult;
            var stanowisko = (IEnumerable<Stanowisko>)result.Model;
            Assert.AreEqual("sprzatacz", stanowisko.First().Nazwa);
            Assert.AreEqual(2000, stanowisko.First().Pensja);
        }

        [TestMethod]
        public void Test_Stanowisko_Index_Return_Count()
        {
            var context = new FakeWypoContext();
            context.Stanowiska = new[] {
                 new Stanowisko { Nazwa= "sprzatacz", Pensja = 2000 , StanowiskoId =1},
                 new Stanowisko { Nazwa= "manager", Pensja = 3000 , StanowiskoId =2},
                 new Stanowisko { Nazwa= "szef", Pensja = 23300 , StanowiskoId =3},
            }.AsQueryable();

            var controller = new StanowiskaController(context);
            var result = controller.Index() as ViewResult;
            var stanowisko = (IEnumerable<Stanowisko>)result.Model;
            Assert.AreEqual(3, stanowisko.Count());
        }

        [TestMethod]
        public void Test_Route_StanowiskoId()
        {
            // Arrange
            var context = new FakeHttpContextForRouting(requestUrl: "~/Stanowiska/Details/1");
            var routes = new RouteCollection();
            ASP_MVC_Testing.RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Stanowiska", routeData.Values["controller"]);
            Assert.AreEqual("Details", routeData.Values["action"]);
            Assert.AreEqual("1", routeData.Values["id"]);
        }


        [TestMethod]
        public void Test_Route_StanowiskoId_Edit()
        {
            // Arrange
            var context = new FakeHttpContextForRouting(requestUrl: "~/Stanowiska/Edit/1");
            var routes = new RouteCollection();
            ASP_MVC_Testing.RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Stanowiska", routeData.Values["controller"]);
            Assert.AreEqual("Edit", routeData.Values["action"]);
            Assert.AreEqual("1", routeData.Values["id"]);
        }

        [TestMethod]
        public void Test_def_Route()
        {
            // Arrange
            var context = new FakeHttpContextForRouting(requestUrl: "~/Stanowiska");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Stanowiska", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_Details_Exception()
        {
            var context = new FakeWypoContext();
            context.Stanowiska = new[] {
                 new Stanowisko { Nazwa= "sprzatacz", Pensja = 2000 , StanowiskoId =1},
                 new Stanowisko { Nazwa= "manager", Pensja = 3000 , StanowiskoId =2},
                 new Stanowisko { Nazwa= "szef", Pensja = 23300 , StanowiskoId =3},
            }.AsQueryable();


            var controller = new StanowiskaController(context);
            var result = controller.Details(4) as ViewResult;
            Assert.AreEqual(typeof(Exception), result.GetType());

        }

    }
}
