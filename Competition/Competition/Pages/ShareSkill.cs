using AutoItX3Lib;
using Competition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Competition.Utilities.GlobalDefinitions;

namespace Competition.Pages
{
    public class ShareSkill :CommonDriver
    {
        private IWebDriver _driver;
        ShareSkill ShareSkillObj;

        public ShareSkill(IWebDriver driver)
        {
           _driver = driver;
           // PageFactory.InitElements(driver, this);
        }


        //find elements by XPath
        private IWebElement SharedSkill => _driver.FindElement(By.LinkText("Share Skill"));

        //Enter the Title 
        private IWebElement Title => _driver.FindElement(By.Name("title"));

        //Enter the Description 
        private IWebElement Description => _driver.FindElement(By.Name("description"));

        //Click on Category Dropdown
        private IWebElement CategoryDropDown => _driver.FindElement(By.Name("categoryId"));
       

        //Click on SubCategory Dropdown
        private IWebElement SubCategoryDropDown => _driver.FindElement(By.Name("subcategoryId"));

        //Enter Tag names in textbox
        private IWebElement Tags => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

        //Select the Service type
        private IWebElement ServiceType => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]"));
        private IWebElement ServiceTypeOption1 => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
        private IWebElement ServiceTypeOption2 => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));

        //Select the Location Type
        private IWebElement LocationType => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div"));
        private IWebElement LocationTypeOption1 => _driver.FindElement(By.XPath("//label[contains(text(),'On-site')]"));
        private IWebElement LocationTypeOption2 => _driver.FindElement(By.Name("//label[contains(text(),'Online')]"));

        //Click on Start Date dropdown
        private IWebElement StartDateDropDown => _driver.FindElement(By.Name("startDate"));

        //Click on End Date dropdown
        private IWebElement EndDateDropDown => _driver.FindElement(By.Name("endDate"));


        //Storing the table of available days
        private IWebElement Days => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));

        //Storing the starttime
        private IList <IWebElement> StartTime => _driver.FindElements(By.Name("StartTime"));

       

        //Click on EndTime dropdown
        private IList <IWebElement> EndTimeDropDown => _driver.FindElements(By.Name("EndTime"));

        //select the available days 
        private IList <IWebElement> AvailableDays => _driver.FindElements(By.Name("Available"));
        
        //Click on Skill Trade option
        private IWebElement SkillTradeOption => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div"));
        private IWebElement SkillTradeOption1 => _driver.FindElement(By.XPath("//label[contains(text(),'Skill-exchange')]"));
        private IWebElement SkillTradeOption2 => _driver.FindElement(By.XPath("//label[contains(text(),'Credit')]"));

        //Enter Skill Exchange
        private IWebElement SkillExchange => _driver.FindElement(By.XPath("//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[8]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]"));

        //Enter the amount for Credit
        private IWebElement CreditAmount => _driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
        

        //Load the image 
        private IWebElement WorkSamples => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
                                                                         
        //Click on Active/Hidden option
        private IWebElement ActivatedOption => _driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div"));
        private IWebElement SelectActive => _driver.FindElement(By.XPath("//label[contains(text(),'Active')]"));
        private IWebElement SelectHidden => _driver.FindElement(By.XPath("//label[contains(text(),'Hidden')]"));

             
        //Click on Save button
        private IWebElement Save => _driver.FindElement(By.XPath("//input[@value='Save']"));

        //Xpath

        //private string

        public void AddSkill()
        {
            //Click on share skill button
            SharedSkill.Click();

            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");


            //Enter the Title
            Title.SendKeys(ExcelLib.ReadData(2, "Title"));

            //Enter Description
            Description.SendKeys(ExcelLib.ReadData(2, "Description"));

            //Select the category 
            var SelectCategory = new SelectElement(CategoryDropDown);
            SelectCategory.SelectByText(ExcelLib.ReadData(2, "Category"));

            //Select the Subcategory
            var SelectSubCategory = new SelectElement(SubCategoryDropDown);
            SelectSubCategory.SelectByText(ExcelLib.ReadData(2, "SubCategory"));

            //Enter tag
            Tags.Click();
            Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Return);
            Thread.Sleep(1000);

            //Select Service type
            string ServiceTypexl = ExcelLib.ReadData(2, "ServiceType");

            if(ServiceTypexl == "One-off service")
            {
                ServiceTypeOption2.Click();
            }
            else
            {
                ServiceTypeOption1.Click();
            }
            Thread.Sleep(1000);

            //Select Location Type
            string LocationTypexl = ExcelLib.ReadData(2, "LocationType");

            if(LocationTypexl == "On-site")
            {
                LocationTypeOption1.Click();
            }
            else
            {
                LocationTypeOption2.Click();
            }
            Thread.Sleep(1000);

            //enter the start date
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(ExcelLib.ReadData(2, "Startdate"));
            Thread.Sleep(1000);

            //enter the end date
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(ExcelLib.ReadData(2, "Enddate"));
            Thread.Sleep(1000);

            //enter the select day
            for (int j = 2; j < 10; j++)
            {

                string SelectDayxl = ExcelLib.ReadData(j, "Selectday");
                string Days = "";
                switch (SelectDayxl)
                {
                    case "Sun":
                        Days = "0";
                        break;
                    case "Mon":
                        Days = "1";
                        break;
                    case "Tue":
                        Days = "2";
                        break;
                    case "Wed":
                        Days = "3";
                        break;
                    case "Thu":
                        Days = "4";
                        break;
                    case "Fri":
                        Days = "5";
                        break;
                    case "Sat":
                        Days = "6";
                        break;
                }
                // int size = daysInpuSelectdayt.Count();
                for (int i = 0; i < AvailableDays.Count(); i++)
                {
                    string Available = AvailableDays[i].GetAttribute("index").ToString();
                    if (Days == Available)
                    {
                        AvailableDays[i].Click();
                        StartTime[i].SendKeys(ExcelLib.ReadData(j, "Starttime"));
                        EndTimeDropDown[i].SendKeys(ExcelLib.ReadData(j, "Endtime"));
                    }
                }
            }
            
          
            Thread.Sleep(1000);


            //enter skill trade
            string SkillTradexl = ExcelLib.ReadData(2, "SkillTrade");

            if (SkillTradexl == "Skill-exchange")
            {
                SkillTradeOption1.Click();

                //enter skill-exchange
                SkillExchange.Click();
                SkillExchange.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Return);
                Thread.Sleep(1000);

            }
            else
            {
                SkillTradeOption2.Click();

                //enter Credit
                CreditAmount.Click();
                CreditAmount.SendKeys(ExcelLib.ReadData(2, "Credit"));
                CreditAmount.SendKeys(Keys.Return);
                Thread.Sleep(1000);

            }
            Thread.Sleep(1000);

          

            //enter the work samples using AutoIT
            WorkSamples.Click();
            //AutoItX3 autoIt = new AutoItX3();
            //autoIt.WinActivate("Open");
            //Thread.Sleep(1000);
            //autoIt.Send(@"F:\Competition2022\July2022\Competition\Competition\FileUpload\selenium-webdriver.png");
            //Thread.Sleep(1000);
            //autoIt.Send("{ENTER}");
            using (Process exeProcess = Process.Start(CommonDriver.AutoScriptPath))
            {
                exeProcess.WaitForExit();
            }



            //select the active radio button
            string ActiveSelectionxl = ExcelLib.ReadData(2, "Active");

            if (ActiveSelectionxl == "Active")
            {
                SelectActive.Click();
            }
            else
            {
                SelectHidden.Click();
            }

            //click on save option
            Save.Click();


        }

    }
}
