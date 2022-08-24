using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Competition.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver { get; set; }

        HomePage HomePageObj;
        LoginPage LoginPageObj;
        public static string excelsheetpath = @"F:\Competition2022\July2022\Competition\Competition\ExcelData\TestDataShareSkill.xlsx";
        public static string AutoScriptPath = @"F:\Competition2022\July2022\Competition\Competition\FileUpload\FileUploadScript.exe";
        public static string AutoScriptPathEdit = @"F:\Competition2022\July2022\Competition\Competition\FileUpload\FileUploadScriptEdit.exe";
        public static string ScreenshotPath = @"F:\Competition2022\July2022\Competition\Competition\Screenshots\";
        public static string ReportPath = @"F:\Competition2022\July2022\Competition\Competition\Reports\";
        public static AventStack.ExtentReports.ExtentReports extent;
        public static AventStack.ExtentReports.ExtentTest test;
        public static string ExcelPath { get => excelsheetpath; set => excelsheetpath = value; }
       
        #region setup and teardown
        [OneTimeSetUp]
        protected void ExtentStart()
        {
            //Initialize report
            string reportName = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "TestLibrary/TestReports"
            + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("_dd-MM-yyyy_HHmm") + Path.DirectorySeparatorChar;
            //start reporters
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportName);
            htmlReporter.Config.DocumentTitle = "Automation Report";//Title of the report
            htmlReporter.Config.ReportName = "Functional Report"; //Name of the report.
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;//Backgroud theme
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Information need to be displayed on the report
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "Test Environment");
            extent.AddSystemInfo("USerName", "Angel");
            extent.AddSystemInfo("Browser", "Chrome");

        }

        [SetUp]
        public void LoginAction()
        {
            driver = new ChromeDriver();
            LoginPageObj = new LoginPage(driver);
            HomePageObj = new HomePage(driver);
            LoginPageObj.LoginSteps();
            HomePageObj.GetWelcomeText();


        }
       

        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = GlobalDefinitions.Screenshot.SaveScreenshot(driver, "ScreenShots");
            // log with snapshot
            var exec_status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            string TC_Name = TestContext.CurrentContext.Test.Name;
            string base64 = GlobalDefinitions.Screenshot.GetScreenshot(driver);

            Status logStatus = Status.Pass;
            switch (exec_status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    test.Log(Status.Fail, exec_status + errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    test.Log(Status.Skip, errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    test.Log(Status.Warning, "Test ");
                    break;
                case TestStatus.Passed:
                    logStatus = Status.Pass;
                    test.Log(Status.Pass, "Test Passed");
                    break;
                default:
                    break;
            }
            // Close the driver
            driver.Close();
            driver.Quit();
        }


        [OneTimeTearDown]

        public void TestClose()
        {
            Thread.Sleep(5000);
            extent.Flush();
        }
         #endregion
    }
}
