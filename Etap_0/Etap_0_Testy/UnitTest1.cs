using Microsoft.VisualStudio.TestTools.UnitTesting;
using Etap_0;
using System.Collections.Generic;

namespace Etap_0_Testy
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AverageTest()
        {
            BasicMath basicMath = new BasicMath();
            List<float> testList = new List<float>() { 2.0f, 5.5f, 1.75f, 6.25f, 4.5f };
            float avg = basicMath.Average(testList);
            Assert.AreEqual(4.0f, avg);
        }

        [TestMethod]
        public void MaxTest()
        {
            BasicMath basicMath = new BasicMath();
            List<float> testList = new List<float>() { 2.0f, 5.5f, 1.75f, 6.25f, 4.5f };
            float max = basicMath.Max(testList);
            Assert.AreEqual(6.25f, max);
        }
    }
}
