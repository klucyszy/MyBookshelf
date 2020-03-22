using AutoMapper;

namespace Elibrary.Application.Common.Mappings
{
    public interface IMapFrom<TModel>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TModel), GetType());
    }
}
