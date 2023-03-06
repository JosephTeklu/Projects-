using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// the library that allows you to webscrape
using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
// allows us to use "File"
using System.IO;
// allows us to take a screenshot
using System.Drawing.Imaging;

namespace CS_WebScraperLearning
{
    class Program
    {            
        static void Main(string[] args)
        {

            // creating a new instance of the chrome driver class
            var _chromeDriver = new ChromeDriver();

            _chromeDriver.Navigate().GoToUrl("https://orteil.dashnet.org/cookieclicker");
            while (true)
            {
                _chromeDriver.FindElementById("bigCookie").Click();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pizza ordering 1.1.1 \nCreated by: Joseph Teklu");

            Console.WriteLine("Press 1 for carryout \nPress 2 for delivery");
            int _orderType = int.Parse(Console.ReadLine());

            // go the url given
            _chromeDriver.Navigate().GoToUrl("https://blackjackpizza.hungerrush.com/order/ordertype");

            // if the order type is carry out find the button and click on it
            if (_orderType == 1)
            {
                _chromeDriver.FindElementByClassName("ui-state-default").Click();
                CarryOut carryOut = new CarryOut();
            }
            // if the order type is delivery find the button and click on it 
            else if (_orderType == 2)
            {
                _chromeDriver.FindElementByClassName("deliveryImg").Click();
                Delivery delivery = new Delivery();
            }

            Console.ReadLine();
        }      
    }

    public class CarryOut
    {
        public CarryOut()
        {
            var chromeDriver = new ChromeDriver();

            var _streetButton = chromeDriver.FindElementById("divStreet");
            _streetButton.SendKeys("1600 Penn Ave");

            var _cityButton = chromeDriver.FindElementById("divCity");
            _cityButton.SendKeys("Aurora");

            var _stateButton = chromeDriver.FindElementById("divState");
            _stateButton.Click();
        }
    }

}
