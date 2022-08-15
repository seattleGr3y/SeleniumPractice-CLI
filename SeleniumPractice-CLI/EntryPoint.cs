using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


Console.WriteLine("FOR THIS EXAMPLE I AM DOING A GOOGLE SEARCH");
Console.WriteLine("FOR THE NEXT PROMPT PLEASE JUST ENTER: https://www.google.com/");
Console.Write("enter the full web address: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string siteUrl = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
Console.WriteLine("THE ELEMENT NAME TO ENTER IS: q");
Console.Write("enter the name of the elemtent where you want to enter text to search: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string elemantName = Console.ReadLine();
Console.Write("enter text you want to search: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string txtToSearch = Console.ReadLine();

if (elemantName != null && siteUrl != null && txtToSearch != null)
{
    FirstClass.TrySomeSelenium(elemantName, txtToSearch, siteUrl);
}
else { Console.WriteLine("what the heck are ya doin?"); }

public static class FirstClass
{
    public static IWebDriver ChromeDriver = new ChromeDriver($@"{Environment.CurrentDirectory}\..\..\..\Drivers");
    public static IWebElement? webElement;
    public static IWebElement? textBox;

    public static void TrySomeSelenium(string elementName, string txtToSearch, string siteUrl)
    {
        ChromeDriver.Navigate().GoToUrl(siteUrl);

        if (CheckForElementByName(elementName))
        {
            textBox = ChromeDriver.FindElement(By.Name(elementName));
            textBox.SendKeys(txtToSearch);
            textBox.Submit();
        }
        Thread.Sleep(30000);
        ChromeDriver.Quit();
    }

    public static bool CheckForElementByName(string elementName)
    {
        try
        {
            webElement = ChromeDriver.FindElement(By.Name(elementName));
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
