using MyDeal.WebApi.Models;
using System.Collections;

namespace MyDeal.WebApi.PassengerService
{
    public interface IPassengerLocator
    {
        IList GetPassengers(PassengerLocator passengerList);
    }
}
