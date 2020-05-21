using Elibrary.Application.Common.Mappings;
namespace Elibrary.Application.GoogleBooks.Models
{
    public class ImageLinks : IMapFrom<Google.Apis.Books.v1.Data.Volume.VolumeInfoData.ImageLinksData>
    {
        public string ExtraLarge { get; set; }
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
        public string SmallThumbnail { get; set; }
        public string Thumbnail { get; set; }
    }
}
