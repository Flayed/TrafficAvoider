using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TrafficAvoider.Lib.Helpers
{
    public static class AutoMapper
    {
        public static TDestination Map<TDestination, TSource>(TSource source, TDestination destination, Action<TSource, TDestination> customMapper = null) where TDestination : class where TSource : class
        {
            foreach (var property in typeof(TSource).GetRuntimeProperties())
            {
                var destProp = typeof(TDestination).GetRuntimeProperties().FirstOrDefault(p => p.Name.Equals(property.Name) && 
                    (p.PropertyType.Equals(property.PropertyType) || 
                    (p.PropertyType.IsGenericParameter && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && Nullable.GetUnderlyingType(p.PropertyType).Equals(property.PropertyType)) ||
                    (property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && p.PropertyType.Equals(Nullable.GetUnderlyingType(property.PropertyType)))
                    ));
                if (destProp == null) continue;
                if (property.PropertyType == typeof(Nullable<>) && property.GetValue(source) == null) continue;
                destProp.SetValue(destination, property.GetValue(source));
            }
            if (customMapper != null)
                customMapper(source, destination);
            return destination;
        }

        public static TDestination Map<TDestination, TSource>(TSource source, Action<TSource, TDestination> customMapper = null) where TDestination : class, new() where TSource : class, new()
        {
            TDestination destination = new TDestination();
            return Map(source, destination, customMapper);
        }
    }
}
