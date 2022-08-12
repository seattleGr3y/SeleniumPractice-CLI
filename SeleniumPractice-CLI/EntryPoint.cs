using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


Console.Write("enter the full web address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string siteUrl = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
Console.Write("enter the name of the elemtent you want to click on: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string elemantName = Console.ReadLine();

if (elemantName != null && siteUrl != null)
{
    FirstClass.TrySomeSelenium(elemantName, siteUrl);
}
else { Console.WriteLine("what the heck are ya doin?"); }

public static class FirstClass
{
    public static bool eNameExists = false;
    public static IWebDriver ChromeDriver = new ChromeDriver($@"{Environment.CurrentDirectory}\..\..\..\Drivers");


    public static void TrySomeSelenium(string elementName, string siteUrl)
    {
        ChromeDriver.Navigate().GoToUrl(siteUrl);

        if (CheckForElementByName(elementName))
        {
            ChromeDriver.FindElement(By.ClassName(elementName)).Click();
        }
        
        Thread.Sleep(30000);
        ChromeDriver.Quit();
    }

    public static bool CheckForElementByName(string elementName)
    {
        try
        {
            IWebElement webElement = ChromeDriver.FindElement(By.Name(elementName));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("oops am I looking for the wrong thing?");
            Thread.Sleep(5000);
            return false;
        }
        return true;
    }
}
