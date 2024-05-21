using PW.Data;
using PW.Logic;
using System.Runtime.Intrinsics.X86;

namespace LogicTests
{
    [TestClass]
    public class LogicUnitTests
    {
        [TestMethod]
        public void BallsCollisionTest()
        {
            Ball ball1 = new Ball(0, 0, 20);
            Ball ball2 = new Ball(5, 10, 15);
            LogicAbstractApi logic = LogicAbstractApi.CreateApi();
            Assert.AreEqual(true, logic.BallsCollide(ball1, ball2));
        }
    }
}