
using OpenQA.Selenium.Chrome;

namespace TestProject2;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method",
    Justification = "Reason...")]
public class Tests
{
    private SauceDemoPom _sauceDemoPom;
    private ChromeDriver _driver;
    
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _sauceDemoPom = new SauceDemoPom(_driver);
        _sauceDemoPom.NavigateToSauceDemoSite();
    }

    [Test]
    public void Test1()
    {
       _sauceDemoPom.Login("standard_user","secret_sauce");
       _sauceDemoPom.AddItemToCart();
    }


    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}