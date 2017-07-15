using System;
using BattleShipTAF.PageObjects;
using OpenQA.Selenium;

namespace BattleShipTAF.PageSteps
{
    class BattleShipSteps
    {
        private readonly BattleShipPage _mainPage;

        public BattleShipSteps(IWebDriver driver)
        {
            _mainPage = new BattleShipPage(driver);
        }
        public void Start()
        {
            _mainPage.NavigateHere();
            _mainPage.ChangeShipsPositionRandomTimes(15);
            _mainPage.StarGame();
            _mainPage.WaitForStart();
            Console.WriteLine(_mainPage.EnemyCellsList());
        }
    }
}
