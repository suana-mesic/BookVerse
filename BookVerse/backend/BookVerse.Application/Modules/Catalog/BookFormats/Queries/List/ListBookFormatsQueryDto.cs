using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.BookFormats.Queries.List
{
    // DTO returned by GET /api/bookformats (anonymous endpoint).
    // IsDeleted is intentionally not exposed - a public listing should never reveal internal state.
    // The global query filter already hides soft-deleted formats from the response.
    public class ListBookFormatsQueryDto
    {
        public int Id { get; set; }
        public string Format { get; set; }
    }
}
