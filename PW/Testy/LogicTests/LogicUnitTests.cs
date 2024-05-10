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
            ball.Velocity = new System.Numerics.Vector2(0.5f, 1.0f);
            ball.Speed = 2.5f;
            Logic.MoveBall(ref ball);
            Assert.AreNotEqual(0.0f, ball.Top);
            Assert.AreNotEqual(0.0f, ball.Left);
        }
    }
}