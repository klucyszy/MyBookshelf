using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Models;
using System.Collections.Generic;
using System.Linq;

namespace Elibrary.Application.BooksArea.Queries.GetBooks
{
    public class GetAllUserVolumesApiModel : ApiModel
    {
        public GetAllUserVolumesApiModel(IEnumerable<Volume> volumes = null)
        {
            if (volumes == null)
                Volumes = new List<Volume>();
            Volumes = volumes;
        }

        public GetAllUserVolumesApiModel() : this(null)
        {
        }

        public IEnumerable<Volume> Volumes { get; set; }
        public int Total => Volumes.Count();
    }
}
