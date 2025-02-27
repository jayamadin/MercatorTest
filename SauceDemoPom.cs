using OpenQA.Selenium;


namespace TestProject2;

public class SauceDemoPom
{
    private IWebDriver _driver;

    public SauceDemoPom(IWebDriver driver)
    {
            _driver = driver;
    }
    IWebElement UserNameTextField => _driver.FindElement(By.Id("user-name"));
    IWebElement PasswordTextField => _driver.FindElement(By.Id("password"));
    IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
    IList<IWebElement> ListedItemPrices => _driver.FindElements(By.XPath("//*[@data-test='inventory-item-price']"));
    private IWebElement AddToCartButton => _driver.FindElement(By.XPath("..//button[text()='Add to cart']"));
    private By AddToCartButtonByXpath = By.XPath("..//button[text()='Add to cart']");

    public void Login(string username , String password)
    {
        UserNameTextField.SendKeys(username);
        PasswordTextField.SendKeys(password);
        LoginButton.Click();
    }
    
    public void NavigateToSauceDemoSite () => _driver.Navigate().GoToUrl("https://www.saucedemo.com/");


    public void AddItemToCart()
    {
        var value = "$" + FindHighestPricedItem();
        ListedItemPrices
            .First(item => item.Text.Equals(value))
            .FindElement(AddToCartButtonByXpath).Click();
    }

    private String FindHighestPricedItem()
    {
        var highestItem = 0.00;
        foreach (var listedItemPrice in ListedItemPrices)
        {
            var itemPrice = Double.Parse(listedItemPrice.Text.Replace("$", String.Empty));
            if (itemPrice > highestItem)
            {
                highestItem = itemPrice;
            }
            
        } 
        return highestItem.ToString();
    }
    
}