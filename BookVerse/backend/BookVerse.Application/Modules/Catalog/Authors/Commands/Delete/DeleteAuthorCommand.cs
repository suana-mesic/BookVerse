using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Authors.Commands.Delete;
    public class DeleteAuthorCommand: IRequest<Unit>
{
    public required int Id { get; set; }
}