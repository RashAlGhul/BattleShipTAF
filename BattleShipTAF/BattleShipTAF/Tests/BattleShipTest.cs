using BattleShipTAF.PageSteps;
using NUnit.Framework;

namespace BattleShipTAF.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    class BattleShipTest : BaseTest
    {
        [Test]
        public void StartGameCheck()
        {
            BattleShipSteps steps = new BattleShipSteps(Driver);
            steps.Start();
        }
    }
}
