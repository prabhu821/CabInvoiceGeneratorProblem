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
        public (int noOfRides, double totalFare, double averageFare) CalculateFare(Ride[] rides)
        {
            try
            {
                if (rides == null)
                    throw new ArgumentNullException(nameof(rides));
                double totalFare = 0;
                foreach (Ride ride in rides)
                    totalFare += CalculateFare(ride.Distance, ride.Time);
                return (rides.Length, totalFare, totalFare / rides.Length);
            }
            catch (ArgumentNullException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "No Rides was passed in argument");
            }
        }
    }
}