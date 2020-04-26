using Elibrary.Application.Common.Mappings;
using System;

namespace Elibrary.Application.GoogleBooks.Models
{
    public class Bookshelf : IMapFrom<Google.Apis.Books.v1.Data.Bookshelf>
    {
        public string Access { get; set; }

        public virtual DateTime? Created { get; set; }

        public virtual string Description { get; set; }

        public virtual int? Id { get; set; }

        public virtual string Kind { get; set; }

        public virtual string Title { get; set; }

        public virtual DateTime? Updated { get; set; }

        public virtual int? VolumeCount { get; set; }
    }
}
