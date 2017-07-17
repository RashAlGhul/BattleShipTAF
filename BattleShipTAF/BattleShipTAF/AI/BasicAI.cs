using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BattleShipTAF.AI
{
    class BasicAI
    {
        private EnemyCell[,] _enemyCells;
        private IWebElement _enemyBoard;
        public BasicAI(List<IWebElement> enemyCellsList, IWebElement enemyBoard)
        {
            this._enemyBoard = enemyBoard;
            _enemyCells = new EnemyCell[enemyCellsList.Count / 2,enemyCellsList.Count / 2];
            for (var i = 0; i < _enemyCells.GetLength(0); i++)
            {
                for (var j = 0; j < _enemyCells.GetLength(1); j++)
                {
                    _enemyCells[i, j] = new EnemyCell(enemyCellsList[i + j], CellStatus.Empty.ToString());
                }
            }
        }

        public void StrikeCell()
        {
            Console.WriteLine($@"{_enemyCells.GetLength(0)},{_enemyCells.GetLength(1)}");
            Random random = new Random();
            int i = random.Next(_enemyCells.GetLength(0));
            int j = random.Next(_enemyCells.GetLength(1));
            if ((_enemyCells[i, j].Status == "Empty") && (_enemyCells[i, j].Cell.Enabled))
            {
                _enemyCells[i, j].Cell.Click();
                if (_enemyBoard.Enabled)
                    HitCell(i, j);
                else
                    _enemyCells[i, j].Status = CellStatus.Miss.ToString();
            }
        }

        private void HitCell(int i, int j)
        {
            _enemyCells[i, j].Status = CellStatus.Hit.ToString();
            if ((i != 0) && (j != 0) && (i != _enemyCells.GetLength(0)-1) && (j != _enemyCells.GetLength(1)-1))
            {
                _enemyCells[i + 1, j + 1].Status = CellStatus.Miss.ToString();
                _enemyCells[i + 1, j - 1].Status = CellStatus.Miss.ToString();
                _enemyCells[i - 1, j + 1].Status = CellStatus.Miss.ToString();
                _enemyCells[i - 1, j - 1].Status = CellStatus.Miss.ToString();
            }
            
            if ((i == 0) && (j == 0))
                _enemyCells[i + 1, j + 1].Status = CellStatus.Miss.ToString();

            if ((i == 0) && (j == _enemyCells.GetLength(1)-1))
                _enemyCells[i + 1, j - 1].Status = CellStatus.Miss.ToString();

            if ((i == _enemyCells.GetLength(0)-1) && (j == 0))
                _enemyCells[i - 1, j + 1].Status = CellStatus.Miss.ToString();

            if ((i == _enemyCells.GetLength(0)-1) && (j == _enemyCells.GetLength(1)-1))
                _enemyCells[i - 1, j - 1].Status = CellStatus.Miss.ToString();
            
            if ((i == 0) && (j != 0) && (j != _enemyCells.GetLength(1)-1))
            {
                _enemyCells[i + 1, j + 1].Status = CellStatus.Miss.ToString();
                _enemyCells[i + 1, j - 1].Status = CellStatus.Miss.ToString();
            }

            if ((i == _enemyCells.GetLength(0)-1) && (j != 0) && (j != _enemyCells.GetLength(1)-1))
            {
                _enemyCells[i - 1, j + 1].Status = CellStatus.Miss.ToString();
                _enemyCells[i - 1, j - 1].Status = CellStatus.Miss.ToString();
            }

            if ((i != 0) && (i != _enemyCells.GetLength(0)) && (j == 0))
            {
                _enemyCells[i + 1, j + 1].Status = CellStatus.Miss.ToString();
                _enemyCells[i - 1, j + 1].Status = CellStatus.Miss.ToString();
            }

            if ((i != 0) && (i != _enemyCells.GetLength(0)) && (j == _enemyCells.GetLength(1)))
            {
                _enemyCells[i + 1, j - 1].Status = CellStatus.Miss.ToString();
                _enemyCells[i - 1, j - 1].Status = CellStatus.Miss.ToString();
            }
        }
    }
}
