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
        private IWebDriver driver;
        ShareSkill ShareSkillObj;

        public ShareSkill(IWebDriver driver)
        {
            this.driver = driver;
            // PageFactory.InitElements(driver, this);
        }


        //find elements by XPath
        private IWebElement SharedSkill => driver.FindElement(By.LinkText("Share Skill"));

        //Enter the Title 
        private IWebElement Title => driver.FindElement(By.Name("title"));

        //Enter the Description 
        private IWebElement Description => driver.FindElement(By.Name("description"));

        //Click on Category Dropdown
        private IWebElement CategoryDropDown => driver.FindElement(By.Name("categoryId"));
       

        //Click on SubCategory Dropdown
        private IWebElement SubCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));

        //Enter Tag names in textbox
        private IWebElement Tags => driver.FindElement(By.XPath(TagsXpath));

        //Select the Service type
        private IWebElement ServiceType => driver.FindElement(By.XPath(ServiceTypeXpath));
        private IWebElement ServiceTypeOption1 => driver.FindElement(By.XPath(ServiceTypeOption1Xpath));
        private IWebElement ServiceTypeOption2 => driver.FindElement(By.XPath(ServiceTypeOption2Xpath));

        //Select the Location Type
        private IWebElement LocationType => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div"));
        private IWebElement LocationTypeOption1 => driver.FindElement(By.XPath("//label[contains(text(),'On-site')]"));
        private IWebElement LocationTypeOption2 => driver.FindElement(By.Name("//label[contains(text(),'Online')]"));

        //Click on Start Date dropdown
        private IWebElement StartDateDropDown => driver.FindElement(By.Name("startDate"));

        //Click on End Date dropdown
        private IWebElement EndDateDropDown => driver.FindElement(By.Name("endDate"));


        //Storing the table of available days
        private IWebElement Days => driver.FindElement(By.XPath(DaysXpath));

        //Storing the starttime
        private IList <IWebElement> StartTime => driver.FindElements(By.Name("StartTime"));

       

        //Click on EndTime dropdown
        private IList <IWebElement> EndTimeDropDown => driver.FindElements(By.Name("EndTime"));

        //select the available days 
        private IList <IWebElement> AvailableDays => driver.FindElements(By.Name("Available"));
        
        //Click on Skill Trade option
        private IWebElement SkillTradeOption => driver.FindElement(By.XPath(SkillTradeOptionXpath));
        private IWebElement SkillTradeOption1 => driver.FindElement(By.XPath(SkillTradeOption1Xpath));
        private IWebElement SkillTradeOption2 => driver.FindElement(By.XPath(SkillTradeOption2Xpath));

        //Enter Skill Exchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath(SkillExchangeXpath));

        //Enter the amount for Credit
        private IWebElement CreditAmount => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
        

        //Load the image 
        private IWebElement WorkSamples => driver.FindElement(By.XPath(WorkSamplesXpath));
                                                                         
        //Click on Active/Hidden option
        private IWebElement ActivatedOption => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div"));
        private IWebElement SelectActive => driver.FindElement(By.XPath("//label[contains(text(),'Active')]"));
        private IWebElement SelectHidden => driver.FindElement(By.XPath("//label[contains(text(),'Hidden')]"));

             
        //Click on Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));

        //Xpath

        private string TagsXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input";
        private string SkillTradeOptionXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div";
        private string SkillTradeOption1Xpath = "//label[contains(text(),'Skill-exchange')]";
        private string SkillTradeOption2Xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input";
        private string SkillExchangeXpath = "//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[8]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]";
        private string WorkSamplesXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i";
        private string LocationTypeXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div";
        private string ServiceTypeXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]";
        private string ServiceTypeOption1Xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input";
        private string ServiceTypeOption2Xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input";
        private string DaysXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input";
        //private string

        public void AddSkill()
        {
            //Click on share skill button
            SharedSkill.Click();

            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            string title = ExcelLib.ReadData(2, "Title");
            string description = ExcelLib.ReadData(2, "Description");
            string category = ExcelLib.ReadData(2, "Category");
            string subcategory = ExcelLib.ReadData(2, "SubCategory");
            string tags = ExcelLib.ReadData(2, "Tags");
            string servicetype = ExcelLib.ReadData(2, "ServiceType");
            string locationtype = ExcelLib.ReadData(2, "LocationType");
            string startdate = ExcelLib.ReadData(2, "Startdate");
            string enddate = ExcelLib.ReadData(2, "Enddate");
            string skilltrade = ExcelLib.ReadData(2, "SkillTrade");
            string radiobutton = ExcelLib.ReadData(2, "Active");

            //Enter the Title
            Title.SendKeys(title);

            //Enter Description
            Description.SendKeys(description);

            //Select the category 
            var SelectCategory = new SelectElement(CategoryDropDown);
            SelectCategory.SelectByText(category);

            //Select the Subcategory
            var SelectSubCategory = new SelectElement(SubCategoryDropDown);
            SelectSubCategory.SelectByText(subcategory);

            //Enter tag
            Tags.Click();
            Tags.SendKeys(tags);
            Tags.SendKeys(Keys.Return);
            GlobalDefinitions.wait(driver, 2);
           

            //Select Service type
            string ServiceTypexl = servicetype;

            if(ServiceTypexl == "One-off service")
            {
                ServiceTypeOption2.Click();
            }
            else
            {
                ServiceTypeOption1.Click();
            }
            

            //Select Location Type
            string LocationTypexl = locationtype;

            if(LocationTypexl == "On-site")
            {
                LocationTypeOption1.Click();
            }
            else
            {
                LocationTypeOption2.Click();
            }
          

            //enter the start date
            StartDateDropDown.Click();
            StartDateDropDown.SendKeys(startdate);
            wait(driver, 1);

            //enter the end date
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(enddate);
            wait(driver, 1);

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


            wait(driver, 1);


            //enter skill trade
            string SkillTradexl = skilltrade;

            if (SkillTradexl == "Skill-exchange")
            {
                SkillTradeOption1.Click();

                //enter skill-exchange
                SkillExchange.Click();
                SkillExchange.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Return);
                wait(driver, 1);

            }
            else
            {
                SkillTradeOption2.Click();

                //enter Credit
                CreditAmount.Click();
                CreditAmount.SendKeys(ExcelLib.ReadData(2, "Credit"));
                CreditAmount.SendKeys(Keys.Return);
                wait(driver, 1);

            }
            wait(driver, 1);



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
            string ActiveSelectionxl = radiobutton;

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
