using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCEulerProjectSolutions.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CircularBufferSimpleImp<int> test = new CircularBufferSimpleImp<int>(5);

            test.Write(1);
            test.Write(2);
            test.Write(3);
            test.Write(4);
            test.Write(5);
            test.Write(6);

            Assert.IsTrue(test._backingArray[0] == 1);
            Assert.IsTrue(test._backingArray[1] == 2);
            Assert.IsTrue(test._backingArray[2] == 3);
            Assert.IsTrue(test._backingArray[3] == 4);
            Assert.IsTrue(test._backingArray[4] == 5);

            Assert.IsTrue(test.size == 5);
            Assert.IsTrue(test.capacity == 5);
            
            Console.WriteLine("T");
        }
    }
}
