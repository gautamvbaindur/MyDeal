using MyDeal.WebApi.Models;
using System.Collections;

namespace MyDeal.WebApi.ControllerHelper
{
    public interface IControllerHelper
    {
        string GetShortenedUrl(string longUrl);
        IList GetPassengers(PassengerLocator passengerList);
    }
}
