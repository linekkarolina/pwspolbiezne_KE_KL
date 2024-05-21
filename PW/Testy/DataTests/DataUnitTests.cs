using PW.Data;

namespace DataTests
{
    [TestClass]
    public class DataUnitTests
    {
        [TestMethod]
        public void MoveBallTest()
        {
            Ball ball = new Ball(0, 0, 20);
            ball.Velocity = new System.Numerics.Vector2(0.5f, 1.0f);
            ball.Speed = 2.5f;
            Thread.Sleep(30);
            Assert.AreNotEqual(0.0f, ball.Top);
            Assert.AreNotEqual(0.0f, ball.Left);
        }
    }
}