using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Field mars = new Field(5, 5);
            RoboticRover robot = new RoboticRover(1, 2, Direction.N, "LMLMLMLMM");
            mars.RoverList = new List<RoboticRover> { robot };

            string expectedValue = "1 3 N";

            Assert.AreEqual(expectedValue, mars.SearchArea());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Field mars = new Field(5, 5);
            RoboticRover robot = new RoboticRover(3, 3, Direction.E, "MMRMMRMRRM");
            mars.RoverList = new List<RoboticRover> { robot };

            string expectedValue = "5 1 E";

            Assert.AreEqual(expectedValue, mars.SearchArea());
        }

        [TestMethod]
        public void TestMethod3()
        {
            Field mars = new Field(5, 5);
            RoboticRover robot1 = new RoboticRover(1, 2, Direction.N, "LMLMLMLMM");
            RoboticRover robot2 = new RoboticRover(3, 3, Direction.E, "MMRMMRMRRM");
            mars.RoverList = new List<RoboticRover> { robot1, robot2 };

            string expectedValue = "1 3 N" + Environment.NewLine + "5 1 E";

            Assert.AreEqual(expectedValue, mars.SearchArea());
        }

        [TestMethod]
        public void TestMethod4()
        {
            Field mars = new Field(5, 5);
            RoboticRover robot1 = new RoboticRover(1, 2, Direction.N, "LMLMLMLMM");
            RoboticRover robot2 = new RoboticRover(3, 3, Direction.E, "MMRMMRMRRMMMMMM");
            mars.RoverList = new List<RoboticRover> { robot1, robot2 };

            string expectedValue = "1 3 N" + Environment.NewLine + RoboticRover.OutOfAreaException;

            Assert.AreEqual(expectedValue, mars.SearchArea());
        }

        [TestMethod]
        public void TestMethod5()
        {
            Field mars = new Field(1, 1);
            RoboticRover robot1 = new RoboticRover(1, 2, Direction.N, "LMLMLMLMM");
            RoboticRover robot2 = new RoboticRover(3, 3, Direction.E, "MMRMMRMRRM");
            mars.RoverList = new List<RoboticRover> { robot1, robot2 };

            string expectedValue = RoboticRover.OutOfAreaException + Environment.NewLine + RoboticRover.OutOfAreaException;

            Assert.AreEqual(expectedValue, mars.SearchArea());
        }

        [TestMethod]
        public void TestMethod6()
        {
            Field mars = new Field(5, 5);
            RoboticRover robot1 = new RoboticRover(1, 2, Direction.N, "LMLMLMLMM");
            RoboticRover robot2 = new RoboticRover(3, 3, Direction.E, "MMRMMRMRRM");
            RoboticRover robot3 = new RoboticRover(3, 3, Direction.E, "MMRMMRMRRM");
            RoboticRover robot4 = new RoboticRover(3, 3, Direction.E, "MMRMMRMRRM");
            mars.RoverList = new List<RoboticRover> { robot1, robot2, robot3, robot4 };

            string expectedValue = "1 3 N" + Environment.NewLine + "5 1 E" + Environment.NewLine + "5 1 E" + Environment.NewLine + "5 1 E";

            Assert.AreEqual(expectedValue, mars.SearchArea());
        }
    }
}
