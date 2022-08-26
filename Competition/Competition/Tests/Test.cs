using Competition.Pages;
using Competition.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Competition.Utilities.GlobalDefinitions;


[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(2)]
namespace Competition.Tests // Note: actual namespace depends on the project name.
{
    

    [TestFixture]
    [Parallelizable]
    public class Test : CommonDriver
    {
        
        


        [Test, Order(1)]
        public void AddSkill()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ShareSkill ShareSkillObj = new ShareSkill(driver);
            Thread.Sleep(2000);
            ShareSkillObj.AddSkill();

        }
        [Test, Order(2)]
        public void ViewManageListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ManageListing ManageListingObj = new ManageListing(driver);

            wait(driver, 3);
            ManageListingObj.ClickOnManageListing();
            wait(driver, 2);
            ManageListingObj.ViewListingOption();
            wait(driver, 2);

            string ViewListXlTitle = ManageListingObj.ViewListXl();
            string ViewListPageTitle = ManageListingObj.ViewListPage();
            string ViewListXlCategory = ManageListingObj.ViewListXl2();
            string ViewListPageCategory = ManageListingObj.ViewListPage2();
            string ViewListXlDescription = ManageListingObj.ViewDescriptionXl2();
            string ViewListPageDescription = ManageListingObj.ViewDescriptionPage();
            string ViewListXlSubCategory = ManageListingObj.ViewSubCategoryXl2();
            string ViewListPageSubCategory = ManageListingObj.ViewSubCategoryPage();

            Assert.That(ViewListXlTitle == ViewListPageTitle, "Viewed Category doesnot match");
            Assert.That(ViewListXlCategory == ViewListPageCategory, "Viewed Title doesnot match");
            Assert.That(ViewListXlDescription == ViewListPageDescription, "Viewed Description doesnot match");
            Assert.That(ViewListXlSubCategory == ViewListPageSubCategory, "Viewed SubCategory doesnot match");
        }
        [Test, Order(3)]
        public void EditManageListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ManageListing ManageListingObj = new ManageListing(driver);

            wait(driver, 2);
            ManageListingObj.ClickOnManageListing();
            ManageListingObj.EditList();
            wait(driver, 2);


            string EditListXlTitle = ManageListingObj.EditListXl();
            string EditListPage = ManageListingObj.EditListPage();
            string EditListXlDescription = ManageListingObj.EditDescriptionXl();
            string EditListPageDescription = ManageListingObj.EditDescriptionPage();
            string EditListXlCategory = ManageListingObj.EditCategoryXl();
            string EditListPageCategory = ManageListingObj.EditCategoryPage();
           

            Assert.That(EditListXlTitle == EditListPage, "Edit Title doesnot match");
            Assert.That(EditListXlDescription == EditListPageDescription, "Edit Description doesnot match");
            Assert.That(EditListXlCategory == EditListPageCategory,"Edit Category doesnot match");
           

        }
        [Test, Order(4)]
        public void DeleteManageListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ManageListing ManageListingObj = new ManageListing(driver);

            wait(driver, 2);
            ManageListingObj.ClickOnManageListing();
            wait(driver, 2);
            ManageListingObj.DeleteList();
            wait(driver, 2);

            string DeletedList = ManageListingObj.Deleted();

            Assert.That(DeletedList != "Selenium" || DeletedList != "Java", "Skill is not deleted successfully");

        }

    }
}


