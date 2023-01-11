namespace CabInvoiceGeneratorProblem
{
    public class InvoiceGenerator
    {
        private readonly double minFare;
        private readonly double costPerDistance;
        private readonly double costPerMinute;

        public InvoiceGenerator()
        {
            minFare = 5;
            costPerDistance = 10;
            costPerMinute = 1;
        }

        public double CalculateFare(double distance, double time)
        {
            double totalFare = (distance * costPerDistance) + (time * costPerMinute);
            return Math.Max(totalFare, minFare);
        }
    }
}