using System;
using System.Collections;
using System.Text.RegularExpressions;
using BitlyDotNET.Interfaces;
using MyDeal.WebApi.Models;
using MyDeal.WebApi.PassengerService;

namespace MyDeal.WebApi.ControllerHelper
{
    public class ControllerHelper : IControllerHelper
    {
        private IBitlyService _bitlyService;
        private IPassengerLocator _passLocator;

        public ControllerHelper(IBitlyService bitlyService, IPassengerLocator passLocator)
        {
            _bitlyService = bitlyService;
            _passLocator = passLocator;
        }

        public IList GetPassengers(PassengerLocator passengerList)
        {
            return _passLocator.GetPassengers(passengerList);
        }

        public string GetShortenedUrl(string longUrl)
        {
            //server side check in case a user/hacker is able to bypass the client side validation
            if (!IsValidurl(longUrl))
                throw new Exception("please enter a valid url");
            return _bitlyService.Shorten(longUrl);
        }

        private bool IsValidurl(string longUrl)
        {
            var pattern = @"^http(s?)\:\/\/(www\.mydeal\.com\.au)(/?)";
            return Regex.IsMatch(longUrl, pattern);
        }
    }
}