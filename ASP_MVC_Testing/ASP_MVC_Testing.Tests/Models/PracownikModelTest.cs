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
    public class PracownikModelTest
    {
        [TestMethod]
        public void Test_Pracownik_Model()
        {
            var pracownik = new Pracownik()
            {
                Imie = "Tomasz",
                Nazwisko = "Testowy",
                Pesel = "12345678912"
            };

            Assert.AreEqual(0, ValidateModel(pracownik).Count);
        }

        [TestMethod]
        public void Test_Pracownik_Model_Wrong_Syntax_Name()
        {
            var pracownik = new Pracownik()
            {
                Imie = "Tomasz1",
                Nazwisko = "Testowy",
                Pesel = "12345678912"
            };

            Assert.AreEqual(1, ValidateModel(pracownik).Count);
        }

        [TestMethod]
        public void Test_Pracownik_Model_Wrong_Syntax_Pesel_Wrong_Lenght()
        {
            var pracownik = new Pracownik()
            {
                Imie = "Tomasz",
                Nazwisko = "Testowy",
                Pesel = "123456789141"
            };

            Assert.AreEqual(1, ValidateModel(pracownik).Count);
            Assert.AreEqual("Pesel musi miec 11 znaków", ValidateModel(pracownik)[0].ErrorMessage);
        }

        [TestMethod]
        public void Test_Pracownik_Model_Wrong_Syntax_Pesel_Name_Last_Name()
        {
            var pracownik = new Pracownik()
            {
                Imie = "Tomasz1",
                Nazwisko = "Testowy2",
                Pesel = "123456789112"
            };

            Assert.AreEqual(3, ValidateModel(pracownik).Count);
        }
        [TestMethod]
        public void Test_Pracownik_Model_Null_Pesel()
        {
            var pracownik = new Pracownik()
            {
                Imie = "Tomasz",
                Nazwisko = "Testowy",
                //Pesel = ""
            };

            Assert.AreEqual(1, ValidateModel(pracownik).Count);
            Assert.AreEqual("Pole Pesel jest wymagane.", ValidateModel(pracownik)[0].ErrorMessage);
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
