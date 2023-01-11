using CabInvoiceGeneratorProblem;

namespace CabInvoiceTest
{
    public class Tests
    {
        private InvoiceGenerator invoice;
        
        [Test]
        [TestCase(2.0, 5, 25)]
        [TestCase(0.2, 1, 5)]
        [TestCase(0.1, 0.5, 5)]
        public void TestingCalculateFare(double distance, double time, double expected)
        {
            invoice = new InvoiceGenerator();
            double fare = invoice.CalculateFare(distance, time);
            Assert.AreEqual(expected, fare);
        }
    }
}