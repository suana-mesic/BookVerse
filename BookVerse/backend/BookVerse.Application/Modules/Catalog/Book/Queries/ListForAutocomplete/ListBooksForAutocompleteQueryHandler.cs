namespace BookVerse.Application.Modules.Catalog.Book.Queries.ListForAutocomplete
{
    public class ListBooksForAutocompleteQueryHandler(IAppDbContext ctx)
    : IRequestHandler<ListBooksForAutocompleteQuery, List<ListBooksForAutocompleteQueryDto>>
    {
        public async Task<List<ListBooksForAutocompleteQueryDto>> Handle(ListBooksForAutocompleteQuery request, CancellationToken ct)
        {
            return await ctx.Books
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Title)
                .Select(x => new ListBooksForAutocompleteQueryDto
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToListAsync(ct);
        }
    }
}
