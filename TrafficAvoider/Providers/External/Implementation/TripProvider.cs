using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrafficAvoider.Exceptions;
using TrafficAvoider.Models;
using TrafficAvoider.Providers.External.Models;
using TrafficAvoider.Services;

namespace TrafficAvoider.Providers.External.Implementation
{
    public class TripProvider : ITripProvider
    {
        public async Task<TripDto> GetRouteAsync(EndPoint startingPoint, EndPoint endingPoint)
        {
            TripDto trip;
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(APIUrl) })
            {                
                var response = await client.GetAsync($"{APIVersion}/Routes/Driving?o=json&optmz=timeWithTraffic&wp.0={startingPoint.Waypoint}&wp.1={endingPoint.Waypoint}&key={APIKey}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new RouteException($"Unable to retreive route for {startingPoint.Waypoint} to {endingPoint.Waypoint} : external service returned {response.StatusCode} ({response.ReasonPhrase})");
                }
                trip = new TripDto(JsonSerializer.Deserialize<RootObject>(await response.Content.ReadAsStringAsync()));
            }
            return trip;
        }

        public TripProvider(IJsonSerializer jsonSerializer)
        {
            JsonSerializer = jsonSerializer;
        }
        private readonly IJsonSerializer JsonSerializer;
        private const string APIKey = "AiZOe81hVqgbfEU_bBASIF8UoJcWnWKVUhqr_eZhlQ_eUjnnAtff1lGrLrbGXzZl";
        private const string APIUrl = @"https://dev.virtualearth.net/REST/";
        private const string APIVersion = "V1";

    }
}
