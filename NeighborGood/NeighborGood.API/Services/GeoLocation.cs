using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using OpenCage.Geocode;
using ServiceStack.Text;

namespace NeighborGood.API.Services
{
    public class GeoLocation
    {
        
        public string GetCurrentTown(double latitude, double longitude)
        {
            var gc = new Geocoder("56b83564d8cf4d7b8c3b9fe148677ab8");
            var resp = gc.ReverseGeocode(latitude, longitude);
           
            return resp.Results[0].Components.City;
        } 
    }
}
