using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Application.Modules.Catalog.Languages.Queries.List
{
    public class ListLanguagesQueryHandler(IAppDbContext ctx, ITranslationService translationService)
        : IRequestHandler<ListLanguagesQuery, List<ListLanguagesQueryDto>>
    {
        public async Task<List<ListLanguagesQueryDto>> Handle(ListLanguagesQuery request, CancellationToken ct)
        {
            var items = await ctx.Languages
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Name)
                .Select(x => new ListLanguagesQueryDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync(ct);

            if (!string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs")
            {
                await Task.WhenAll(items.Select(async i =>
                {
                    i.Name = await translationService.Translate(i.Name, request.Language);
                }));
            }

            return items;
        }
    }
}
