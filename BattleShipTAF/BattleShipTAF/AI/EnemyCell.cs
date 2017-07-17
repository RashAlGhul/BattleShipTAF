using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BattleShipTAF.AI
{
    internal class EnemyCell
    {
        public IWebElement Cell { get; set; }
        public string Status { get; set; }

        public EnemyCell(IWebElement cell, string cellStatus = "Empty")
        {
            this.Cell = cell;
            this.Status = cellStatus;
        }
    }
}
