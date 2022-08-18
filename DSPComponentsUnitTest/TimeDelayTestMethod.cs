using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DSPAlgorithms.Algorithms;
using DSPAlgorithms.DataStructures;

namespace DSPComponentsUnitTest
{
     [TestClass]
    class TimeDelayTestMethod
    {
        [TestMethod]
        public void TimeDelayTestMethod1()
        {
            TimeDelay t = new TimeDelay();
            t.InputSignal1 = new Signal(new List<float>() {1, 0, 0, 1}, true);
            t.InputSamplingPeriod = 0.25f;
            var expectedOutput = 7;
            t.Run();
            Assert.IsTrue(UnitTestUtitlities.TwovaluesEqual(expectedOutput, t.OutputTimeDelay));
    

        }
    }
}
