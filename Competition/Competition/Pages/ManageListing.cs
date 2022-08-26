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
    public class ManageListing : CommonDriver
    {
        public IWebDriver driver;
        ManageListing ManageListingObj;

        public ManageListing(IWebDriver driver)
        {
            this.driver = driver;
           // PageFactory.InitElements(driver, this);
        }

        //Click on Manage Listings Link
        private IWebElement ManageListingTab => driver.FindElement(By.XPath(ManageListingTabValue));


        //View listing
        private IWebElement ViewListing => driver.FindElement(By.XPath(ViewListingValue));

        private IWebElement ViewCategory => driver.FindElement(By.XPath(CategoryValue));
        private IWebElement ViewTitle => driver.FindElement(By.XPath(TitleValue));
        private IWebElement ViewDescription => driver.FindElement(By.XPath(ViewDescriptionValue));
        private IWebElement ViewSubCategory => driver.FindElement(By.XPath(ViewSubCategoryValue));
        private IWebElement ViewServiceType => driver.FindElement(By.XPath(ServiceTypeValue));

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
        private IWebElement RemoveTag => driver.FindElement(By.XPath("//a[contains(text(),'×')]"));
        //Select the Service type
        private IWebElement ServiceType => driver.FindElement(By.XPath(ServiceTypeXpath));
        private IWebElement ServiceTypeOption1 => driver.FindElement(By.XPath(ServiceTypeOption1Xpath));
        private IWebElement ServiceTypeOption2 => driver.FindElement(By.XPath(ServiceTypeOption2Xpath));

        //Select the Location Type
        private IWebElement LocationType => driver.FindElement(By.XPath(LocationTypeXpath));
        private IWebElement LocationTypeOption1 => driver.FindElement(By.XPath("//label[contains(text(),'On-site')]"));
        private IWebElement LocationTypeOption2 => driver.FindElement(By.XPath("//label[contains(text(),'Online')]"));
        
        //Click on Start Date dropdown
        private IWebElement StartDateDropDown => driver.FindElement(By.Name("startDate"));

        //Click on End Date dropdown
        private IWebElement EndDateDropDown => driver.FindElement(By.Name("endDate"));

        //Storing the starttime
        private IList<IWebElement> StartTime => driver.FindElements(By.Name("StartTime"));



        //Click on EndTime dropdown
        private IList<IWebElement> EndTime => driver.FindElements(By.Name("EndTime"));

        //select the available days 
        private IList<IWebElement> AvailableDays => driver.FindElements(By.Name("Available"));

        //Click on Skill Trade option
        private IWebElement SkillTradeOption => driver.FindElement(By.XPath(SkillTradeOptionXpath));
        private IWebElement SkillTradeOption1 => driver.FindElement(By.XPath(SkillTradeOption1Xpath));
        private IWebElement SkillTradeOption2 => driver.FindElement(By.XPath(SkillTradeOption2Xpath));

        
        //Enter Skill Exchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath(SkillExchangeXpath));

        //Load the image 
        private IWebElement WorkSamples => driver.FindElement(By.XPath(WorkSamplesXpath));
        //Enter the amount for Credit
        private IWebElement CreditAmount => driver.FindElement(By.XPath(CreditAmountXpath));

    
        //Delete listing
        private IWebElement DeleteListing => driver.FindElement(By.XPath(DeleteListingValue));

        //select yes or no
        private IWebElement ClickAction => driver.FindElement(By.XPath(ClickActionsValue));

        private IWebElement SelectActive => driver.FindElement(By.XPath("//label[contains(text(),'Active')]"));
        private IWebElement SelectHidden => driver.FindElement(By.XPath("//label[contains(text(),'Hidden')]"));
        //Click on Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));

        //select the last element to delete
        private IWebElement Delete => driver.FindElement(By.XPath("//tbody/tr[1]/td[3]"));


        //Edit listing
        private IWebElement EditListing => driver.FindElement(By.XPath(EditListingValue));
        private IWebElement EditTitle => driver.FindElement(By.XPath(EditTitle1));
        private IWebElement EditDescription => driver.FindElement(By.XPath(EditDescriptionValue));
        private IWebElement EditCategory => driver.FindElement(By.XPath(EditCategoryValue));
       



        //Xpath

        private string TagsXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input";
        private string SkillTradeOptionXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div";
        private string SkillTradeOption1Xpath = "//label[contains(text(),'Skill-exchange')]";
        private string SkillTradeOption2Xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input";
        private string SkillExchangeXpath = "//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[8]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]";
        private string WorkSamplesXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i";
        private string CreditAmountXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input";
        private string LocationTypeXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div";
        private string ServiceTypeXpath = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]";
        private string ServiceTypeOption1Xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input";
        private string ServiceTypeOption2Xpath = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input";
        private string ManageListingTabValue = "//div/section[1]/div/a[3]";
        private string ViewListingValue = "//tbody/tr[1]/td[8]/div[1]/button[1]";
        private string EditListingValue = "//tbody/tr[1]/td[8]/div[1]/button[2]";
        private string DeleteListingValue = "//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]";
        private string ClickActionsValue = "//div[@class='actions']";
        private string CategoryValue = "//div[contains(text(),'Programming & Tech')]";
        private string TitleValue = "//span[contains(text(),'Selenium')]";
        private string ViewDescriptionValue = "//div[contains(text(),'Would like to provide selenium training for beginn')]";
        private string ViewSubCategoryValue = "//div[contains(text(),'QA')]";
        private string ServiceTypeValue = "//div[contains(text(),'One-off')]";
        private string EditTitle1 = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]";
        private string EditDescriptionValue = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]";
        private string EditCategoryValue = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]";
       





        public void ClickOnManageListing()
        {
            //identify the Manage listing and click on it
            //wait(3);
            ManageListingTab.Click();
            wait(driver, 1);

        }
        //View Details of a selected row
        public void ViewListingOption()
        {

            //identify the view listing and click on it
           // wait(3);
            ViewListing.Click();
            wait(driver, 1);
        }
        //Get the Title from excel to check assertion
        public string ViewListXl()
        {
            //take the Title from excel
            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            string Title = ExcelLib.ReadData(2, "Title");
            return Title;

        }

        //Get the Title from list to check assertion
        public string ViewListPage()
        {
            //take the Title from Page
            return ViewTitle.Text;
        }

        //Get the Category from excel to check assertion
        public string ViewListXl2()
        {
            //take the Category from excel
            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            string Category = ExcelLib.ReadData(2, "Category");
            return Category;
        }
        //Get the Category from list to check assertion
        public string ViewListPage2()
        {
            //take the Category from Page
            return ViewCategory.Text;
        }

        
        //Get the view description from excel to check assertion
        public string ViewDescriptionXl2()
        {
            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            string Description = ExcelLib.ReadData(2, "Description");
            return Description;
        }
        //Get the view description from list to check assertion
        public string ViewDescriptionPage()
        {
            //take the description from page
            return ViewDescription.Text;
        }
        //Get the view SubCategory from excel to check assertion
        public string ViewSubCategoryXl2()
        {
            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            string SubCategory = ExcelLib.ReadData(2, "SubCategory");
            return SubCategory;
        }
        public string ViewSubCategoryPage()
        {
            //take subcategory from page
            return ViewSubCategory.Text;
        }



        //Edit Details of a selected row
        public void EditList()
        {
            //identify the edit option and click on it
            wait(driver, 2);
            EditListing.Click();
            wait(driver, 2);
            //Fetch Title from excelsheet
            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            TitleEnter();
            DescriptionEnter();
            SelectCategory();
            SubCategory();
            TagsEnter();
            ServiceTypeSelect();
            LocationSelect();
            StartDateselection();
            dateTimeSelect();
            SkillTrade();
            FileUpload();
            Active();
            //click on save option
            Save.Click();
            wait(driver, 2);
            ManageListingTab.Click();
            wait(driver, 2);


        }

       
               
        //Enter Title
        public void TitleEnter()
        {
            //Enter the Title
            string TitleXl = ExcelLib.ReadData(3, "Title").ToString();
            string TitlePage = Title.Text;

            if (TitleXl != null && TitleXl != TitlePage)
            {
                Title.Clear();
                Title.SendKeys(TitleXl);
            }

        }

        //Description 
        public void DescriptionEnter()
        {
            //Enter the description
            string DescriptionXl = ExcelLib.ReadData(3, "Description").ToString();
            string DescriptionPage = Description.Text;

            if (DescriptionXl != null && DescriptionXl != DescriptionPage)
            {
                Description.Clear();
                Description.SendKeys(DescriptionXl);
            }
        }

        //Select Category

        public void SelectCategory()
        {
            //Enter the Category
            string CategoryDropDownXl = ExcelLib.ReadData(3, "Category").ToString();
            string CategoryDropDownPage = CategoryDropDown.Text;

            if (CategoryDropDownXl != null || CategoryDropDownXl != "" && CategoryDropDownXl != CategoryDropDownPage)
            {
                CategoryDropDown.Click();
                //Select the category
                var SelectCategory = new SelectElement(CategoryDropDown);
                SelectCategory.SelectByText(ExcelLib.ReadData(3, "Category"));
                wait(driver, 1);
            }
        }

        //Enter SubCategory
        public void SubCategory()
        {
            //Enter the SubCategory
            string SubCategoryDropDownXl = ExcelLib.ReadData(3, "SubCategory").ToString();
            string SubCategoryDropDownPage = SubCategoryDropDown.Text;

            if (SubCategoryDropDownXl != null || SubCategoryDropDownXl != "" && SubCategoryDropDownXl != SubCategoryDropDownPage)
            {
                SubCategoryDropDown.Click();
                //Select the Subcategory
                var SelectSubCategory = new SelectElement(SubCategoryDropDown);
                SelectSubCategory.SelectByText(ExcelLib.ReadData(3, "SubCategory"));
                wait(driver, 1);
            }

        }

        //Tags 
        public void TagsEnter()
        {
            //Enter Tags
            string TagXl = ExcelLib.ReadData(3, "Tags").ToString();
            string TagPage = Tags.Text;

            if (TagXl != null && TagXl != TagPage)
            {
                Tags.Click();
                RemoveTag.Click();
                //enter Tag
                Tags.SendKeys(ExcelLib.ReadData(3, "Tags"));
                Tags.SendKeys(Keys.Return);
                wait(driver, 1);
            }
        }

        public void ServiceTypeSelect()
        {
            //    //Enter Service type 

            string ServiceTypexl = ExcelLib.ReadData(3, "ServiceType").ToString();
            string ServiceTypePage = ServiceType.Text;

            if (ServiceTypexl != null && ServiceTypexl != ServiceTypePage)
            {
                if (ServiceTypexl == "One-off service")
                {
                    ServiceTypeOption2.Click();
                }
                else
                {
                    ServiceTypeOption1.Click();
                }
                wait(driver, 1);
            }
        }

        public void LocationSelect()
        {
            //    //Select Location Type
            string LocationTypexl = ExcelLib.ReadData(3, "LocationType").ToString();
            string LocationTypePage = LocationType.Text;

            if (LocationTypexl != null && LocationTypexl != LocationTypePage)
            {
                if (LocationTypexl == "On-site")
                {
                    LocationTypeOption1.Click();
                }
                else
                {
                    LocationTypeOption2.Click();
                }
                wait(driver, 1);

            }
        }

        //Start and End Date 
        public void StartDateselection()
        {
            //    //enter the start date
            string StartDateDropDownXl = ExcelLib.ReadData(3, "Startdate").ToString();
            string StartDateDropDownPage = StartDateDropDown.Text;

            if (StartDateDropDownXl != null && StartDateDropDownXl != StartDateDropDownPage)
            {
                StartDateDropDown.Click();
                StartDateDropDown.SendKeys(ExcelLib.ReadData(3, "Startdate"));
                wait(driver, 1);
            }


            //enter the end date
            string EndDateDropDownXl = ExcelLib.ReadData(3, "Enddate").ToString();
            string EndDateDropDownPage = EndDateDropDown.Text;

            if (EndDateDropDownXl != null && EndDateDropDownXl != EndDateDropDownPage)
            {
                EndDateDropDown.Click();
                EndDateDropDown.SendKeys(ExcelLib.ReadData(3, "Enddate"));
                wait(driver, 1);
            }
        }


        //Days selection with time
        public void dateTimeSelect()
        {

            // Clear all the existing timings 

            string daysInput = ExcelLib.ReadData(2, "AvailableDays");
            if (daysInput != null || daysInput != "")
            {
                for (int j = 0; j < AvailableDays.Count; j++)
                {
                    if (StartTime[j].Text != null || StartTime[j].Text != "")
                    {

                        if (AvailableDays[j].Selected)
                        {
                            AvailableDays[j].Click();
                            StartTime[j].SendKeys(Keys.Delete);
                            StartTime[j].SendKeys(Keys.Tab);
                            StartTime[j].SendKeys(Keys.Delete);
                            StartTime[j].SendKeys(Keys.Tab);
                            StartTime[j].SendKeys(Keys.Delete);
                            StartTime[j].SendKeys(Keys.Tab);
                            EndTime[j].SendKeys(Keys.Delete);
                            EndTime[j].SendKeys(Keys.Tab);
                            EndTime[j].SendKeys(Keys.Delete);
                            EndTime[j].SendKeys(Keys.Tab);
                            EndTime[j].SendKeys(Keys.Delete);
                            EndTime[j].SendKeys(Keys.Tab);
                        }
                    }
                }
            }
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
                //enter the timings 
                for (int i = 0; i < AvailableDays.Count(); i++)
                {
                    string Available = AvailableDays[i].GetAttribute("index").ToString();
                    if (Days == Available)
                    {
                        AvailableDays[i].Click();
                        StartTime[i].SendKeys(ExcelLib.ReadData(j, "Starttime"));
                        EndTime[i].SendKeys(ExcelLib.ReadData(j, "Endtime"));
                    }
                }
            }


            wait(driver, 1);
        }

        //Skill Trade Selection
        public void SkillTrade()
        {

            //enter skill trade

            string SkillTradeExcel = ExcelLib.ReadData(3, "SkillTrade").ToString();
          

            if (SkillTradeExcel != null || SkillTradeExcel != "")
            {
                if (SkillTradeExcel == "Skill-exchange")
                {
                    
                    SkillTradeOption1.Click();

                    //enter skill-exchange
                    SkillExchange.Click();
                    SkillExchange.SendKeys(ExcelLib.ReadData(3, "Skill-Exchange"));
                    SkillExchange.SendKeys(Keys.Return);
                   

                }
                else
                {
                    SkillTradeOption2.Click();

                    //enter Credit
                    CreditAmount.Click();
                    CreditAmount.SendKeys(ExcelLib.ReadData(3, "Credit"));
                    CreditAmount.SendKeys(Keys.Return);
                    
                }
            }
        }

        //Active Radio button selection
        public void Active()
        {
            //select the active radio button
            string ActiveSelectionxl = ExcelLib.ReadData(3, "Active").ToString();
            string ActiveSelection = SkillTradeOption.Text;


            if (ActiveSelectionxl != null && ActiveSelectionxl == "Active")
            {
                SelectActive.Click();
            }
            else
            {
                SelectHidden.Click();
            }
        }

        //File Upload
        public void FileUpload()
        {
            //file upload

            WorkSamples.Click();

            using (Process exeProcess = Process.Start(CommonDriver.AutoScriptPathEdit))
            {
                exeProcess.WaitForExit();
                wait(driver, 1);
            }

        }
        public string EditListXl()
        {
            //check the Title from excel
            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            string Title = ExcelLib.ReadData(3, "Title");
            return Title;

        }

        public string EditListPage()
        {
            return EditTitle.Text;
        }
        public string EditDescriptionXl()
        {
            //check the Description from excel
            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            string Description = ExcelLib.ReadData(3, "Description");
            return Description;
        }

        public string EditDescriptionPage()
        {
            return EditDescription.Text;
        }
        public string EditCategoryXl()
        {
            //check the category from excel
            ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "ShareSkill");
            string Category = ExcelLib.ReadData(3, "Category");
            return Category;
        }
        public string EditCategoryPage()
        {
            return EditCategory.Text;
        }


        //Delete Details of a selected row
        public void DeleteList()
        {
            //identify the delete option and click on it
            wait(driver, 1);
            DeleteListing.Click();
            wait(driver, 1);
            ClickAction.Click();
        }



        public string Deleted()
        {
            return Delete.Text;
        }


       

    }
   


}

