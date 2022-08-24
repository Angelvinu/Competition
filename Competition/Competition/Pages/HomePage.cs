using Competition.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Pages
{
    public  class HomePage
    {
        //Define class with two objects
        public IWebDriver driver;


        //Form constructor 

        public HomePage(IWebDriver driver)
        {
            //initialising driver object
            this.driver = driver;
        }

        //find elements by XPath
        private IWebElement message => driver.FindElement(By.XPath(xpValue));


        //XPath
        private string xpValue = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span";

        public string GetWelcomeText()
        {
            //get the message as Hii Angel Mary
            WaitHelpers.WaitToBeVisible(driver, "XPath", xpValue, 3);

            //item ui dropdown link 
            return message.Text;
            Thread.Sleep(1500);

        }
    }
}
