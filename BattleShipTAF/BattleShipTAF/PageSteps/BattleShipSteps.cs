using System;
using BattleShipTAF.AI;
using BattleShipTAF.PageObjects;
using OpenQA.Selenium;

namespace BattleShipTAF.PageSteps
{
    class BattleShipSteps
    {
        private BasicAI AI;
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
        }

        public void Play()
        {
            AI = new BasicAI(_mainPage.EnemyCellsList(), _mainPage.EnemyBoard());
            bool gameOverFlag = false;
            while (!gameOverFlag)
            {
                gameOverFlag = _mainPage.IsGameOver();
                _mainPage.WaitForStrike();
                AI.StrikeCell();
                Console.WriteLine(_mainPage.GetFinalNotification());
            }
        }

        public string GameOverNotification()
        {
            return _mainPage.GetFinalNotification();
        }
    }
}
