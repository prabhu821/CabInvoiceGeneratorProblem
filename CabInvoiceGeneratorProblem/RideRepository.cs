using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorProblem
{
    public class RideRepository
    {
        private readonly Dictionary<string, List<Ride>> userRides;

        public RideRepository()
        {
            userRides = new Dictionary<string, List<Ride>>();
        }
        public void Add(string userID, Ride[] rides)
        {
            if (rides == null)
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides list is empty");
            if (userRides.ContainsKey(userID))
                foreach (var ride in rides)
                    userRides[userID].Add(ride);
            else
                userRides.Add(userID, rides.ToList());
        }
        public Ride[] GetRides(string userID)
        {
            if (!userRides.ContainsKey(userID))
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, $"{userID} does not exist");
            return userRides[userID].ToArray();
        }
    }
}
