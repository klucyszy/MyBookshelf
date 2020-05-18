using AutoMapper;
using Elibrary.Application.Common.Mappings;
using System.Collections.Generic;

namespace Elibrary.Application.GoogleBooks.Models
{
    public class Volume : IMapFrom<Google.Apis.Books.v1.Data.Volume>
    {
        public Volume()
        {
            UserBookshelfs = new List<BookshelfBase>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Language { get; set; }

        public IList<string> Authors { get; set; }

        public double? AverageRating { get; set; }  

        public IList<string> Categories { get; set; }

        public IList<BookshelfBase> UserBookshelfs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Google.Apis.Books.v1.Data.Volume, Volume>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.VolumeInfo.Title))
                .ForMember(dest => dest.Subtitle, opts => opts.MapFrom(src => src.VolumeInfo.Subtitle))
                .ForMember(dest => dest.Language, opts => opts.MapFrom(src => src.VolumeInfo.Language))
                .ForMember(dest => dest.Authors, opts => opts.MapFrom(src => src.VolumeInfo.Authors))
                .ForMember(dest => dest.AverageRating, opts => opts.MapFrom(src => src.VolumeInfo.AverageRating))
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(src => src.VolumeInfo.Categories))
                .ForMember(dest => dest.UserBookshelfs, opts => opts.Ignore());
        }
    }
}
