
using AutoMapper;
using Elibrary.Application.Common.Mappings;

namespace Elibrary.Application.GoogleBooks.Models
{
    public class Review : IMapFrom<Google.Apis.Books.v1.Data.Review>
    {
        private string _rating;

        public string VolumeId { get; set; }        
        public string Content { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }

        public string Date { get; set; }

        public int Rating
        {
            get
            {
                return _rating switch
                {
                    "ONE" => 1,
                    "TWO" => 2,
                    "THREE" => 3,
                    "FOUR" => 4,
                    "FIVE" => 5,
                    _ => 0
                };
            }
        }

        public void SetRating(string rating)
        {
            _rating = rating;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Google.Apis.Books.v1.Data.Review, Review>()
                .ForMember(dest => dest.Rating, opts => opts.Ignore())
                .AfterMap((src, dest) => dest.SetRating(src.Rating));
        }
    }
}
