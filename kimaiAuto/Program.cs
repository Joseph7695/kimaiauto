// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

List<DateTime> dates = new List<DateTime>()
{
    DateTime.Parse("2023-01-1"),
DateTime.Parse("2023-01-2"),
DateTime.Parse("2023-01-22"),
DateTime.Parse("2023-01-23"),
DateTime.Parse("2023-02-1"),
DateTime.Parse("2023-02-5"),
DateTime.Parse("2023-02-6"),
DateTime.Parse("2023-04-8"),
DateTime.Parse("2023-04-21"),
DateTime.Parse("2023-04-22"),
DateTime.Parse("2023-04-23"),
DateTime.Parse("2023-04-24"),
DateTime.Parse("2023-05-1"),
DateTime.Parse("2023-05-4"),
DateTime.Parse("2023-06-29"),
DateTime.Parse("2023-07-19"),
DateTime.Parse("2023-08-31"),
DateTime.Parse("2023-09-16"),
DateTime.Parse("2023-09-28"),
DateTime.Parse("2023-11-12"),
DateTime.Parse("2023-11-13"),
DateTime.Parse("2023-12-25"),
DateTime.Parse("2024-01-01"),


DateTime.Parse("2023-12-1"), // AL

DateTime.Parse("2023-04-19"), // MC
DateTime.Parse("2023-01-25"), // AL
DateTime.Parse("2023-01-26"),// AL
DateTime.Parse("2023-01-27"),// AL
DateTime.Parse("2023-01-30")// AL
};

Console.WriteLine("Hello, World!");
IWebDriver driver = new ChromeDriver();

//driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
driver.Navigate().GoToUrl("redacted");

var title = driver.Title;
//Assert.AreEqual("Web form", title);

driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

var textBox = driver.FindElement(By.Name("_username"));
var passwordBox = driver.FindElement(By.Name("_password"));
//var submitButton = driver.FindElement(By.TagName("button"));
var submitButton = driver.FindElement(By.TagName("button"));

textBox.SendKeys("redacted");
passwordBox.SendKeys("redacted");
submitButton.Click();

//var message = driver.FindElement(By.Id("message"));
//var value = message.Text;
//Assert.AreEqual("Received!", value);

var daysToCheck = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
var startDate = new DateTime(2024, 1, 05);
var endDate = DateTime.Now;
var totalDays = (int)endDate.Subtract(startDate).TotalDays;                                                              
var allDatesQry = from d in Enumerable.Range(1, totalDays)
                  select new DateTime(
                                startDate.AddDays(d).Year,
                                startDate.AddDays(d).Month,
                                startDate.AddDays(d).Day);
var selectedDatesQry = from d in allDatesQry
                       where daysToCheck.Contains(d.DayOfWeek)
                       && !dates.Contains(d)
                       select d;

foreach (var item in selectedDatesQry)
{
    //Thread.Sleep(3000);
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
    while (true)
    {
        try
        {
            var elementToBeDisplayed = driver.FindElement(By.CssSelector(".btn-create"));
            elementToBeDisplayed.Click();
            break;
        }
        catch (StaleElementReferenceException)
        {
        }
        catch (NoSuchElementException)
        {
        }
        catch { }
    }
    //driver.FindElement(By.CssSelector(".btn-create")).Click();
    //Thread.Sleep(2000);
    while (true)
    {
        try
        {
            var elementToBeDisplayed = driver.FindElement(By.Id("form_modal_label"));
            elementToBeDisplayed.Click();
            break;
        }
        catch (StaleElementReferenceException)
        {
        }
        catch (NoSuchElementException)
        {
        }
        catch { }
    }

    while (true)
    {
        try
        {
            var elementToBeDisplayed = driver.FindElement(By.Id("timesheet_edit_form_begin"));
            elementToBeDisplayed.Click();
            break;
        }
        catch (StaleElementReferenceException)
        {
        }
        catch (NoSuchElementException)
        {
        }
        catch { }
    }
    //driver.FindElement(By.Id("timesheet_edit_form_begin")).Click();
    driver.FindElement(By.Id("timesheet_edit_form_begin")).Clear();
    driver.FindElement(By.Id("timesheet_edit_form_begin")).SendKeys(item.ToString("yyyy-MM-dd 09:00")); // "2023-08-29 09:00") ; ;
    driver.FindElement(By.Id("form_modal_label")).Click();
    driver.FindElement(By.Id("timesheet_edit_form_end")).Click();
    driver.FindElement(By.Id("timesheet_edit_form_end")).Clear();
    driver.FindElement(By.Id("timesheet_edit_form_end")).SendKeys(item.ToString("yyyy-MM-dd 18:00"));
    driver.FindElement(By.Id("form_modal_label")).Click();

    var customerText = driver.FindElement(By.CssSelector(".select2-container"));
    //var projectText = driver.FindElement(By.Id("timesheet_edit_form_customer"));
    customerText.Click();
    var customerSelection = driver.FindElement(By.CssSelector(".select2-search--dropdown > .select2-search__field"));
    customerSelection.SendKeys("redacted");
    customerSelection.SendKeys(Keys.Enter);

    var projectText = driver.FindElements(By.CssSelector(".select2-container"));
    //var projectText = driver.FindElement(By.Id("timesheet_edit_form_project"));
    projectText[1].Click();
    var projectSelection = driver.FindElement(By.CssSelector(".select2-search--dropdown > .select2-search__field"));
    projectSelection.SendKeys("redacted");
    projectSelection.SendKeys(Keys.Enter);


    var activityText = driver.FindElements(By.CssSelector(".select2-container"));
    //var activityText = driver.FindElement(By.Id("timesheet_edit_form_activity"));
    activityText[2].Click();
    var activitySelection = driver.FindElement(By.CssSelector(".select2-search--dropdown > .select2-search__field"));
    activitySelection.SendKeys("Development");
    activitySelection.SendKeys(Keys.Enter);

    driver.FindElement(By.Id("timesheet_edit_form_description")).Click();
    if (item > new DateTime(2023, 7, 25))
    {
        driver.FindElement(By.Id("timesheet_edit_form_description")).SendKeys("[redacted System Portal] Development & Enhancement, [redacted] Issues Bugfix");
    }
    else if (item > new DateTime(2023, 6, 26))
    {
        driver.FindElement(By.Id("timesheet_edit_form_description")).SendKeys("[redactedMigration] IIT Testing");
    }
    else
    {
        driver.FindElement(By.Id("timesheet_edit_form_description")).SendKeys("[redactedMigration] Development");
    }
    driver.FindElement(By.Id("timesheet_edit_form_tags")).Click();
    driver.FindElement(By.Id("timesheet_edit_form_tags")).SendKeys("redacted, ");

    driver.FindElement(By.XPath("//*[text()='Save']")).Click();
}
//driver.Quit();