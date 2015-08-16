using System;

namespace TrafficAvoider.Exceptions
{

    [Serializable]
    public class RouteException : Exception
    {
        public RouteException() { }
        public RouteException(string message) : base(message) { }
        public RouteException(string message, Exception inner) : base(message, inner) { }
        protected RouteException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
