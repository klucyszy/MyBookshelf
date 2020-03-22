using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Elibrary.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromCurrentAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromCurrentAssembly(Assembly assembly)
        {
            var mappingsTypes = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (Type mappingType in mappingsTypes)
            {
                var instance = Activator.CreateInstance(mappingType);

                var mappingMethod = mappingType.GetMethod("Mapping")
                    ?? mappingType.GetInterface("IMapFrom`1").GetMethod("Mapping");

                mappingMethod?.Invoke(instance, new object[] { this });
            }
        }
    }
}
