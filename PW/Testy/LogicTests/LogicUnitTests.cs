using PW.Logic;
using System.Runtime.Intrinsics.X86;

namespace LogicTests
{
    [TestClass]
    public class LogicUnitTests
    {
        [TestMethod]
        public void MoveBallTest()
        {
            Ball ball = new Ball(0, 0);
            ball.Velocity = new System.Numerics.Vector2(0.5f, 1);
            ball.Speed = 2.5f;
            Logic.MoveBall(ref ball);
            Assert.AreEqual(ball.Left, 1.25f);
            Assert.AreEqual(ball.Top, 2.5f);
        }
    }
}