using CabInvoiceGeneratorProblem;

namespace CabInvoiceTest
{
    public class Tests
    {
        private InvoiceGenerator? invoice;
        Ride ride = new(2.0, 5);

        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<TestCaseData> MultipleRideTestCases()
        {
            Ride[] rides1 = { new Ride(2.0, 5), new Ride(0.2, 1), new Ride(0.1, 0.5) };
            Ride[] rides2 = { new Ride(2.0, 5), new Ride(0.2, 1) };

            yield return new TestCaseData(35, rides1);
            yield return new TestCaseData(30, rides2);
        }

        private static IEnumerable<TestCaseData> MultipleRideExceptionTestCases()
        {
            yield return new TestCaseData(InvoiceException.ExceptionType.NULL_RIDES, null);
        }

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

        [Test]
        [TestCaseSource("MultipleRideTestCases")]
        public void TestMultipleRides(double expected, Ride[] rides)
        {
            invoice = new InvoiceGenerator();
            double fare = invoice.CalculateFare(rides);
            Assert.AreEqual(expected, fare);
        }

        [Test]
        [TestCaseSource("MultipleRideExceptionTestCases")]
        public void TestInvoiceExcception(InvoiceException.ExceptionType expectedType, Ride[] rides)
        {
            bool exceptionThrown = false;
            try
            {
                invoice = new InvoiceGenerator();
                invoice.CalculateFare(rides);
            }
            catch (InvoiceException ex)
            {
                if (ex.ErrorType == expectedType)
                {
                    exceptionThrown = true;
                    Assert.Pass();
                }
            }
            if (exceptionThrown is false)
                Assert.Fail();
        }
    }
}