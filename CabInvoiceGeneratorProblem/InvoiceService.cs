using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorProblem
{
    public class InvoiceService
    {
        private static RideRepository rideRepository;

        static InvoiceService()
        {
            rideRepository = new RideRepository();
        }

        public static Invoice GetInvoice(string userID)
        {
            InvoiceGenerator invoiceGenerator = new();
            return invoiceGenerator.CalculateFare(rideRepository.GetRides(userID));
        }

        public static void AddRides(string userID, Ride[] rides)
        {
            rideRepository.Add(userID, rides);
        }
    }
}
