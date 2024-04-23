using PW.Data;

namespace DataTests
{
    [TestClass]
    public class DataUnitTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            DataAbstractApi data = DataAbstractApi.CreateApi();
            Assert.IsNotNull(data);
        }
    }
}