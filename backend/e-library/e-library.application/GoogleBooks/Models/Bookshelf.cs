using AutoMapper;
using Elibrary.Application.Common.Mappings;
using System;

namespace Elibrary.Application.GoogleBooks.Models
{
    public class BookshelfBase
    {
        public BookshelfBase()
        {

        }

        public BookshelfBase(int? id, string title)
        {
            Id = id;
            Title = title;
        }

        public int? Id { get; set; }
        public string Title { get; set; }
    }


    public class Bookshelf : BookshelfBase, IMapFrom<Google.Apis.Books.v1.Data.Bookshelf>
    {
        public string Access { get; set; }

        public DateTime? Created { get; set; }

        public string Description { get; set; }

        public string Kind { get; set; }

        public DateTime? Updated { get; set; }

        public int VolumeCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Google.Apis.Books.v1.Data.Bookshelf, Bookshelf>()
                .ForMember(dest => dest.VolumeCount, opts => opts.MapFrom(src => src.VolumeCount ?? 0));
        }
    }
}
