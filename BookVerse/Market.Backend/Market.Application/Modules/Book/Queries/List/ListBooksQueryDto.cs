using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Book.Queries.List;
    public sealed class ListBooksQueryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public int UserCount { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
    }

