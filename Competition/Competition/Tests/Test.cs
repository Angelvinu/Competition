using Competition.Pages;
using Competition.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

            Thread.Sleep(2000);
            ManageListingObj.ClickOnManageListing();
            Thread.Sleep(2000);
            ManageListingObj.ViewListingOption();
            Thread.Sleep(2000);

            string ViewListXlTitle = ManageListingObj.ViewListXl().ToString();
            string ViewListPageTitle = ManageListingObj.ViewListPage().ToString();
            string ViewListXlCategory = ManageListingObj.ViewListXl2().ToString();
            string ViewListPageCategory = ManageListingObj.ViewListPage2().ToString();

            Assert.That(ViewListXlTitle == ViewListPageTitle, "Viewed Category doesnot match");
            Assert.That(ViewListXlCategory == ViewListPageCategory, "Viewed Title doesnot match");
        }
        [Test, Order(3)]
        public void EditManageListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ManageListing ManageListingObj = new ManageListing(driver);

            Thread.Sleep(2000);
            ManageListingObj.ClickOnManageListing();
            ManageListingObj.EditList();
            Thread.Sleep(2000);

            string EditListXlTitle = ManageListingObj.EditListXl().ToString();
            string EditListPage = ManageListingObj.EditListPage().ToString();

            Assert.That(EditListXlTitle == EditListPage, "Edit Title doesnot match");

        }
        [Test, Order(4)]
        public void DeleteManageListing()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            ManageListing ManageListingObj = new ManageListing(driver);

            Thread.Sleep(2000);
            ManageListingObj.ClickOnManageListing();
            Thread.Sleep(2000);
            ManageListingObj.DeleteList();
            Thread.Sleep(1000);

            string DeletedList = ManageListingObj.Deleted().ToString();

            Assert.That(DeletedList != "Selenium" || DeletedList != "Java", "Skill is not deleted successfully");

        }

    }
}


