using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TryCoordinate;

namespace UnitTests
{
    [TestClass]
    public class PointTests
    {
   
        [TestMethod]
        public void TestFirstCorrectToPoint()
        {
            var startPoint = new Point(0, 0);
            var endPoint = new Point(0, 1);
            var actual = startPoint.DistanceBetweenToPoints(endPoint);

            Assert.AreEqual(expected: 111, actual: actual, delta: 0.3);
        }

        [TestMethod]
        public void TestSecondCorrectToPoint()
        {
            var startPoint = new Point(89.9, 0);
            var endPoint = new Point(89.9, 1);
            var actual = startPoint.DistanceBetweenToPoints(endPoint);

            Assert.AreEqual(expected: 0.19, actual: actual, delta: 0.3);
        }

        [TestMethod]
        public void TestNotCorrectstartPoints()
        {
            var startPoint = new Point(1000.5, 3000.5);
            var endPoint = new Point(-33.857, 9.526);
            var actual = startPoint.DistanceBetweenToPoints(endPoint);

            Assert.AreEqual(expected: 0, actual: actual, message: "Not correct startPoint point");
        }

        [TestMethod]
        public void TestNotCorrectendPoints()
        {
            var startPoint = new Point(33.857, 9.526);
            var endPoint = new Point(-1000.5, 300.5);
            var actual = startPoint.DistanceBetweenToPoints(endPoint);

            Assert.AreEqual(expected: 0, actual: actual, message: "Not correct endPoint point");
        }

        [TestMethod]
        public void TestDistanceToPointMinValue()
        {
            var startPoint = new Point(double.MinValue, double.MinValue);
            var endPoint = new Point(double.MinValue, double.MinValue);
            var actual = startPoint.DistanceBetweenToPoints(endPoint);

            Assert.AreEqual(expected: 0, actual: actual, message: "Minimum value point");
        }

        [TestMethod]
        public void TestDistanceToPointMaxValue()
        {
            var startPoint = new Point(double.MaxValue, double.MaxValue);
            var endPoint = new Point(double.MaxValue, double.MaxValue);
            var actual = startPoint.DistanceBetweenToPoints(endPoint);

            Assert.AreEqual(expected: 0, actual: actual, message: "Maximum value point");
        }

        [TestMethod]
        public void TestDistanceToPointZeroValue()
        {
            var startPoint = new Point(0d, 0d);
            var endPoint = new Point(0d, 0d);
            var actual = startPoint.DistanceBetweenToPoints(endPoint);

            Assert.AreEqual(expected: 0d, actual: actual, message: "Zero value point");
        }

        [TestMethod]
        public void DistanceBetweenToPointsNull()
        {
            var startPoint = new Point(0d, 0d);

            var actual = startPoint.DistanceBetweenToPoints(null);

            Assert.AreEqual(expected: 0, actual: actual, message: "Null value point");
        }

        [TestMethod]
        public void TestDistanceBetweenToMoscowToWashington()
        {
            var moscow = new Point(55.752890, 37.617308);
            var washington = new Point(38.89511, -77.03637);
            var actual = moscow.DistanceBetweenToPoints(washington);

            Assert.AreEqual(expected: 7822.190, actual: actual, delta: 0.3);
        }

        [TestMethod]
        public void TestDistanceBetweenToNovosibirskToDenver()
        {
            var novosibirsk = new Point(55.0415, 82.9346);
            var denver = new Point(39.73915, -104.9847);
            var actual = novosibirsk.DistanceBetweenToPoints(denver);

            Assert.AreEqual(expected: 9449.09, actual: actual, delta: 0.3);
        }

        [TestMethod]
        public void TestStaticDistanceBetweenToMoscowToWashington()
        {
            double moscowLatitude = 55.752890;
            double moscowLongitude = 37.617308;
            double washingtonLatitude = 38.89511;
            double washingtonLongitud = -77.03637;
            var actual = Point.DistanceBetweenToPoint(moscowLatitude, moscowLongitude, washingtonLatitude, washingtonLongitud);

            Assert.AreEqual(expected: 7822.190, actual: actual, delta: 0.3);
        }

        [TestMethod]
        public void TestStaticDistanceBetweenToNovosibirskToDenver()
        {
            double nskLatitude = 55.0415;
            double nskLongitude = 82.9346;
            double denverLatitude = 39.73915;
            double denverLongitud = -104.9847;
            var actual = Point.DistanceBetweenToPoint(nskLatitude, nskLongitude, denverLatitude, denverLongitud);

            Assert.AreEqual(expected: 9449.09, actual: actual, delta: 0.3);
        }

    }
}
