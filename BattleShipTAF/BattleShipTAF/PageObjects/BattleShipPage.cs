using System;
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

        public void WaitForStart()
        {
            Driver.Wait(ExpectedConditions.ElementToBeClickable(_enemyBoard));
        }

        public int EnemyCellsList()
        {
            return Driver.FindElements(_enemyCells).Count;
        }
    }
}
