using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASP_MVC_Testing;
using ASP_MVC_Testing.Controllers;
using System.Web.Routing;
using ASP_MVC_Testing.Models;
using Moq;
//using Microsoft.EntityFrameworkCore;
using ASP_MVC_Testing.Data;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace ASP_MVC_Testing.Tests.Controllers
{
    
    public class HomeControllerTest
    {
        

       


        

        //[TestMethod]
        //[Ignore]
        //public void Index()
        //{
        //    var data = new List<Pracownik>
        //    {
        //        new Pracownik {Imie="Koles1", Nazwisko="Kol1", Pesel="123456789",StanowiskoId=1 },
        //        new Pracownik {Imie="Koles2", Nazwisko="Kol2", Pesel="122456789",StanowiskoId=1 },
        //        new Pracownik {Imie="Koles3", Nazwisko="Kol3", Pesel="121456789",StanowiskoId=2 }
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<Pracownik>>();
        //    mockSet.As<IQueryable<Pracownik>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<Pracownik>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<Pracownik>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<Pracownik>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //    var mockContext = new Mock<WypoContext>();
        //    mockContext.Setup(c => c.Pracownik).Returns(mockSet.Object);


        //    var controller = new PracownicyController(mockContext.Object);
        //    // Act
        //    var result = controller.Index() as ViewResult;

        //    // Assert
        //    var viewModel = result.ViewData.Model as Pracownik;
        //    Assert.IsTrue(viewModel.Pesel.Count() > 1);
        //    //Assert.IsTrue(viewModel.NewArrivals.Count() == 3);
        //}
        //// Checking View name
        [TestMethod]
        public void Mock_WithViewNamePassed_ReturnsViewWithTheSameName()
        {
            // Arrange
            var mockContext = new Mock<WypoContext>();
            var controller = new HomeController(mockContext.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Test View Bag Index", result.ViewBag.Message);
        }

        
    }
}
