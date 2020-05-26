using AutoMapper;
using Elibrary.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Elibrary.Application.GoogleBooks.Models
{
    public class Volume : IMapFrom<Google.Apis.Books.v1.Data.Volume>, IEquatable<Volume>
    {
        public Volume()
        {
            UserBookshelfs = new List<BookshelfBase>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int? PageCount { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public IList<string> Authors { get; set; }
        public double? AverageRating { get; set; }
        public Review Review { get; set; }
        public IList<string> Categories { get; set; }
        public string MainCategory { get; set; }
        public ImageLinks ImageLinks { get; set; }
        public bool IsFavorite => UserBookshelfs.Any(x => x.Title == "Favorites");

        public IList<BookshelfBase> UserBookshelfs { get; set; }

        public void AddToUserBookshelfs(int bookshelfId, string bookshelfTitle)
        {
            UserBookshelfs.Add(new BookshelfBase(bookshelfId, bookshelfTitle));
        }

        public bool Equals([AllowNull] Volume other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            int id = Id.GetHashCode();
            int title = Title.GetHashCode();

            return id ^ title;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Google.Apis.Books.v1.Data.Volume, Volume>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.VolumeInfo.Title))
                .ForMember(dest => dest.Subtitle, opts => opts.MapFrom(src => src.VolumeInfo.Subtitle))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.VolumeInfo.Description))
                .ForMember(dest => dest.PageCount, opts => opts.MapFrom(src => src.VolumeInfo.PageCount))
                .ForMember(dest => dest.Publisher, opts => opts.MapFrom(src => src.VolumeInfo.Publisher))
                .ForMember(dest => dest.Language, opts => opts.MapFrom(src => src.VolumeInfo.Language))
                .ForMember(dest => dest.Authors, opts => opts.MapFrom(src => src.VolumeInfo.Authors))
                .ForMember(dest => dest.AverageRating, opts => opts.MapFrom(src => src.VolumeInfo.AverageRating))
                .ForMember(dest => dest.Review, opts => opts.MapFrom(src => src.UserInfo.Review))
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(src => src.VolumeInfo.Categories))
                .ForMember(dest => dest.MainCategory, opts => opts.MapFrom(src => src.VolumeInfo.MainCategory))
                .ForMember(dest => dest.ImageLinks, opts => opts.MapFrom(src => src.VolumeInfo.ImageLinks))
                .ForMember(dest => dest.IsFavorite, opts => opts.Ignore())
                .ForMember(dest => dest.UserBookshelfs, opts => opts.Ignore());
        }
    }
}
