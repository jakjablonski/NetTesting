using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_Testing.Tests.Selenium
{
    [TestClass]
    public class PracownikSeleniumTest
    {

        [TestMethod]
        public void SeleniumTest()
        {
            TestAddStanowisko();
            TestDetalis();
            TestEditStanowisko();
            TestDeleteStanowisko();
        }
        public void TestAddStanowisko()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:21867/Stanowiska/Create");
            IWebElement stanowisko = driver.FindElement(By.Name("Nazwa"));
            stanowisko.SendKeys("Testowy");
            IWebElement pensja = driver.FindElement(By.Name("Pensja"));
            pensja.SendKeys("700");
            //driver.TakeScreenshot();
            IWebElement przycisk = driver.FindElement(By.Name("Create"));
            przycisk.Click();
            IWebElement tabelaStanowisk = driver.FindElement(By.ClassName("table"));
            Assert.AreEqual("http://localhost:21867/Stanowiska", driver.Url);
            int ilosc = driver.FindElements(By.XPath("//table/tbody/tr")).Count;
            List<String> lista = new List<String>();
            for (int i = 2; i <= ilosc; i++)
            {
                lista.Add(driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[2]")).Text + driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[1]")).Text);
            };
            var match = lista.FirstOrDefault(stringToCheck => stringToCheck.Contains("700,00Testowy"));
            Assert.IsTrue(match != null);
            driver.Close();
        }
        public void TestEditStanowisko()
        {

            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:21867/Stanowiska");
            int ilosc = driver.FindElements(By.XPath("//table/tbody/tr")).Count;
            for (int i = 2; i <= ilosc; i++)
            {
                String cos = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[2]")).Text + driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[1]")).Text;
                if (cos == "700,00Testowy")
                {
                    IWebElement row = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[3]"));
                    IWebElement przycisk = row.FindElement(By.Name("edycja"));
                    przycisk.Click();
                    break;
                }
            };
            IWebElement stanowisko = driver.FindElement(By.Name("Nazwa"));
            stanowisko.Clear();
            stanowisko.SendKeys("TestowyEdit");
            IWebElement pensja = driver.FindElement(By.Name("Pensja"));
            pensja.Clear();
            pensja.SendKeys("1700");
            IWebElement przycisksave = driver.FindElement(By.Name("save"));
            przycisksave.Click();
            Assert.AreEqual("http://localhost:21867/Stanowiska", driver.Url);
            int ilosc2 = driver.FindElements(By.XPath("//table/tbody/tr")).Count;
            List<String> lista = new List<String>();
            for (int i = 2; i <= ilosc2; i++)
            {
                lista.Add(driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[2]")).Text + driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[1]")).Text);
            };
            var match = lista.FirstOrDefault(stringToCheck => stringToCheck.Contains("1700,00TestowyEdit"));
            Assert.IsTrue(match != null);
            driver.Close();


        }
        public void TestDeleteStanowisko()
        {

            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:21867/Stanowiska");
            int ilosc = driver.FindElements(By.XPath("//table/tbody/tr")).Count;
            for (int i = 2; i <= ilosc; i++)
            {
                String cos = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[2]")).Text + driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[1]")).Text;
                if (cos == "1700,00TestowyEdit")
                {
                    IWebElement row = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[3]"));
                    IWebElement przycisk = row.FindElement(By.Name("delete"));
                    przycisk.Click();
                    break;
                }
            };
            IWebElement przycisksave = driver.FindElement(By.Name("delete"));
            przycisksave.Click();
            Assert.AreEqual("http://localhost:21867/Stanowiska", driver.Url);
            int ilosc2 = driver.FindElements(By.XPath("//table/tbody/tr")).Count;
            List<String> lista = new List<String>();
            for (int i = 2; i <= ilosc2; i++)
            {
                lista.Add(driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[2]")).Text + driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[1]")).Text);
            };
            var match = lista.FirstOrDefault(stringToCheck => stringToCheck.Contains("1700,00TestowyEdit"));
            Assert.IsTrue(match == null);
            driver.Close();

        }
        public void TestDetalis()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:21867/Stanowiska");

            int ilosc = driver.FindElements(By.XPath("//table/tbody/tr")).Count;
            for (int i = 2; i <= ilosc; i++)
            {
                String cos = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[2]")).Text + driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[1]")).Text;
                if (cos == "700,00Testowy")
                {
                    IWebElement row = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[3]"));
                    IWebElement przycisk = row.FindElement(By.Name("details"));
                    przycisk.Click();
                    break;
                }
            }
            IWebElement data = driver.FindElement(By.ClassName("dl-horizontal"));
            Assert.AreEqual("Testowy", data.FindElement(By.XPath("//dd")).Text);
            Assert.AreEqual("700,00", data.FindElement(By.XPath("//dd[2]")).Text);
            driver.Close();
        }
    }
}
