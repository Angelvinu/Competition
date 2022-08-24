using Competition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Competition.Utilities.GlobalDefinitions;

namespace Competition.Pages
{
    public class LoginPage: CommonDriver
    {
      
      
        public LoginPage(IWebDriver _driver)
        {
            _driver = driver;
          //  PageFactory.InitElements(driver, this);
        }
        //find elements by XPath
        private IWebElement SignIn => driver.FindElement(By.XPath(SignInXpath));
        private IWebElement UserName => driver.FindElement(By.XPath(UserNameXpath));
        private IWebElement Password => driver.FindElement(By.XPath(PasswordXpath));
        private IWebElement LoginIn => driver.FindElement(By.XPath(LoginInXpath));


        //Xpath
        private string SignInXpath = "//*[@id='home']/div/div/div[1]/div/a";
        private string UserNameXpath = "/html/body/div[2]/div/div/div[1]/div/div[1]/input";
        private string PasswordXpath = "/html/body/div[2]/div/div/div[1]/div/div[2]/input";
        private string LoginInXpath = "/html/body/div[2]/div/div/div[1]/div/div[4]/button";

        public void LoginSteps()
        {


            //maximise the browser
            driver.Manage().Window.Maximize();

            //launch the turn up portal
            //  
            Thread.Sleep(2000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "SignIn");
            driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            try
            {
                Thread.Sleep(2000);
                //Identify the sign in button
                SignIn.Click();

                //identify username and enter the user name.
                UserName.SendKeys(ExcelLib.ReadData(2, "Username"));


                //identify password and enter the password.
                Password.SendKeys(ExcelLib.ReadData(2, "Password"));

                //identify login button and click on it.
                LoginIn.Click();
                Thread.Sleep(3000);



            }

            catch (Exception)

            {
                Assert.Fail("turnup portal was not sucessfully lunched.");
            }
        }


    }
}
