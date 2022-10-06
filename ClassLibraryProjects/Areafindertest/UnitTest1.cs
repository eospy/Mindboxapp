using Easyareafinder;

namespace Areafindertest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Testtriangle()
        {
            double expectedresult = 6;
            Triangle triangle = new("triangle1",3,4,5);
            double result=triangle.Calcmethod();
            Assert.AreEqual(expectedresult, result);
            
        }
        [TestMethod]
        public void Testcircle()
        {
            double expectedresult = 78.5;
            Circle circle = new("circle1", 5);
            double result = circle.Calcmethod();
            Assert.AreEqual(expectedresult, result);
        }
        [TestMethod]
        public void Testanyfigure()
        {
            double expectedresult = 25;
            double[,] dots = new double[,] { { 1, 1 }, { 1, 6 }, { 6, 6 }, { 6, 1 } };
            double result = dots.Universalareafinder();
            Assert.AreEqual(expectedresult, result);
        }
    }
}