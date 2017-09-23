using ASP_MVC_Testing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_Testing.Tests.Models
{
    [TestClass]
    public class StanowiskoModelTest
    {

        [TestMethod]
        public void Test_Stanowisko_Model()
        {
            var stanowisko = new Stanowisko()
            {
                Nazwa="Analityk",
                Pensja=12000
            };

            Assert.AreEqual(0, ValidateModel(stanowisko).Count);
        }

        [TestMethod]
        public void Test_Stanowisko_Model_Wrong_Nazwa()
        {
            var stanowisko = new Stanowisko()
            {
                Nazwa = "An",
                Pensja = 12000
            };

            Assert.AreEqual(1, ValidateModel(stanowisko).Count);
        }

        [TestMethod]
        public void Test_Stanowisko_Model_Null_Pensja()
        {
            var stanowisko = new Stanowisko()
            {
               
                Pensja = 12000
            };

            Assert.AreEqual(1, ValidateModel(stanowisko).Count);
            Assert.AreEqual("Pole Stanowisko jest wymagane.", ValidateModel(stanowisko)[0].ErrorMessage);
        }


        [TestMethod]
        public void Test_Stanowisko_Model_Wrong_Syntax()
        {
            var stanowisko = new Stanowisko()
            {
                Nazwa = "Analityk2@",
                Pensja = 12000
            };

            Assert.AreEqual(1, ValidateModel(stanowisko).Count);
        }


        [TestMethod]
        public void Test_Stanowisko_Model_Wrong_Range_of_Pensja()
        {
            var stanowisko = new Stanowisko()
            {
                Nazwa = "Analityk",
                Pensja = -1000
            };

            Assert.AreEqual(1, ValidateModel(stanowisko).Count);
            Assert.AreEqual("Pole Pensja musi być z zakresu od 1 do 30000.", ValidateModel(stanowisko)[0].ErrorMessage);
        }


        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            if (model is IValidatableObject) (model as IValidatableObject).Validate(ctx);
            return validationResults;
        }

    }
}
