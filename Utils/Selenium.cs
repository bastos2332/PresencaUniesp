using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PRESENCA_FACIL.Utils
{
    public class Selenium
    {
        IWebDriver _driver;


        public Selenium()
        {
            string path = HttpContext.Current.Server.MapPath("~/");
            _driver = new ChromeDriver(path + @"\driver\");

        }


        public void RealizarLogin(string usuario, string senha)
        {
            _driver.Navigate().GoToUrl("https://sistemas.iesp.edu.br/iesponline/Login");

            _driver.FindElement(By.Id("login")).SendKeys(usuario);
            _driver.FindElement(By.Id("senha")).SendKeys(senha);
            _driver.FindElement(By.ClassName("btn-success")).Click();


            _driver.Quit();
        }

    }
}