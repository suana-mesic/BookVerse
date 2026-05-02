using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Application.Modules.Shopping.ShippingMethods.Queries.List
{
    public class ListShippingMethodsQueryHandler(IAppDbContext context, ITranslationService translationService)
    : IRequestHandler<ListShippingMethodsQuery, List<ListShippingMethodsQueryDto>>
    {
        public async Task<List<ListShippingMethodsQueryDto>> Handle(ListShippingMethodsQuery request, CancellationToken cancellationToken)
        {
            var methods = await context.ShippingMethods
                .AsNoTracking()
                .Where(x=>!x.IsDeleted)
                .Select(x=> new ListShippingMethodsQueryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                }).ToListAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs")
            {
                await Task.WhenAll(methods.Select(async method =>
                {
                    var results = await Task.WhenAll(
                        translationService.Translate(method.Name, request.Language),
                        translationService.Translate(method.Description, request.Language)
                    );
                    method.Name = results[0];
                    method.Description = results[1];
                }));
            }

            return methods;
        }
    }
}
