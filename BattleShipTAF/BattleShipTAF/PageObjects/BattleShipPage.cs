using System;
using System.Collections.Generic;
using System.Linq;
using BattleShipTAF.DriverUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BattleShipTAF.PageObjects
{
    class BattleShipPage : BasePage
    {
        #region Page Object XPathese
        private readonly By _randomShipsPosition = By.XPath(@"//span[contains(text(),'Случайным образом')]");
        private readonly By _playGAme = By.XPath(@"//div[contains(text(),'Играть')]");
        private readonly By _enemyBoard = By.XPath(@"//div[@class='battlefield battlefield__rival']");
        private readonly By _enemyCells = By.XPath(@"//div[@class='battlefield battlefield__rival battlefield__wait']//td");
        private readonly By _selectorRandomEnemy = By.XPath(@"//a[contains(text(),'случайный')]");
        private readonly By _restartButton = By.XPath(@"//input[@class='notification-submit restart'][@type='submit']");
        private readonly By _gameOverMessage = By.XPath(@"//div[@class='notifications']//div[@class='notification-message']");
        #endregion

        public BattleShipPage(IWebDriver driver) : base(driver) { }

        public void ChangeShipsPositionRandomTimes(int countTimes)
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(countTimes)+1; i++)
            {
                Driver.FindElement(_randomShipsPosition).Click();
            }
        }

        public void StarGame()
        {
            if (!IsRandomEnemySelected())
            {
                Driver.FindElement(_selectorRandomEnemy).Click();
            }
            Driver.FindElement(_playGAme).Click();
        }

        private bool IsRandomEnemySelected()
        {
            return !Driver.FindElement(_selectorRandomEnemy).Enabled;
        }

        public void WaitForStrike()
        {
            if (!IsGameOver())
                Driver.Wait(ExpectedConditions.ElementToBeClickable(_enemyBoard));
        }

        public List<IWebElement> EnemyCellsList()
        {
            return Driver.FindElements(_enemyCells).ToList();
        }

        public IWebElement EnemyBoard()
        {
            return Driver.FindElement(_enemyBoard);
        }

        public bool IsGameOver()
        {
            IWebElement restartButton = Driver.FindElement(_restartButton);
            return restartButton != null && restartButton.Displayed && restartButton.Enabled;
        }

        public string GetFinalNotification()
        {
            return Driver.FindElement(_gameOverMessage).Text;
        }
    }
}
