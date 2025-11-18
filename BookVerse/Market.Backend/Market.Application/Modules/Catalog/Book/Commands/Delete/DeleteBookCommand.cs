using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Book.Commands.Delete;
    public class DeleteBookCommand : IRequest<Unit>
    {
        public required int Id { get; set; }
    }

