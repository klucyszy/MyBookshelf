using Elibrary.Application.Common.Models;
using Elibrary.Application.GoogleBooks.Models;
using System.Collections.Generic;

namespace Elibrary.Application.BooksArea.Queries.GetBooks
{
    public class GetAllUserVolumesApiModel : ApiModel
    {
        public GetAllUserVolumesApiModel()
        {
            Volumes = new List<Volume>();
        }

        public GetAllUserVolumesApiModel(IEnumerable<Volume> volumes)
        {
            Volumes = volumes;
        }

        public IEnumerable<Volume> Volumes { get; set; }
    }
}
