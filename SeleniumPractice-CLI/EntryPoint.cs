using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


Console.Write("enter the full web address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string siteUrl = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
Console.Write("enter the name of the elemtent where you want to enter text to search: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string elemantName = Console.ReadLine();
Console.Write("enter text you want to search: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string txtToSearch = Console.ReadLine();
// Console.Write("enter the name of the elemtent you want to click on to start the search: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
// string elementName2 = Console.ReadLine();

if (elemantName != null && siteUrl /* != null && elementName2 */ != null && txtToSearch != null)
{
    FirstClass.TrySomeSelenium(elemantName /* elementName2 */, txtToSearch, siteUrl);
}
else { Console.WriteLine("what the heck are ya doin?"); }

public static class FirstClass
{
    public static IWebDriver ChromeDriver = new ChromeDriver($@"{Environment.CurrentDirectory}\..\..\..\Drivers");
    public static IWebElement? webElement;
    public static IWebElement? webElement2;
    public static IWebElement? textBox;

    public static void TrySomeSelenium(string elementName /*, string elementName2 */, string txtToSearch, string siteUrl)
    {
        ChromeDriver.Navigate().GoToUrl(siteUrl);

        if (CheckForElementByName(elementName /*, elementName2 */))
        {
            textBox = ChromeDriver.FindElement(By.Name(elementName)); // .SendKeys(txtToSearch))
            textBox.SendKeys(txtToSearch);
            textBox.Submit();
            #region CANNOT USE THIS FOR GOOGLE SEARCH
            // though this should work I am testing just trying to do a google search
            // when google.com comes up in the Selenium driver it is slightly different than normal
            // the button is using different code and is not interactible
            // I am able though to use .Submit() in the text box and this works just fine
            // IWebElement searchButton = ChromeDriver.FindElement(By.Name(elementName2));
            // searchButton.Click();
            #endregion
        }
        Thread.Sleep(30000);
        ChromeDriver.Quit();
    }

    public static bool CheckForElementByName(string elementName /*, string elementName2 */)
    {
        try
        {
            webElement = ChromeDriver.FindElement(By.Name(elementName));
            // webElement2 = ChromeDriver.FindElement(By.Name(elementName2));
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
