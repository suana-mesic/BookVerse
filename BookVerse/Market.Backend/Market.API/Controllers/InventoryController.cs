using Market.Application.Modules.Catalog.Inventory.Commands.Create;
using Market.Application.Modules.Catalog.Inventory.Commands.Delete;
using Market.Application.Modules.Catalog.Inventory.Commands.Update;
using Market.Application.Modules.Catalog.Inventory.Queries.GetById;
using Market.Application.Modules.Catalog.Inventory.Queries.GetStoresAndBooksPairs;
using Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List;
namespace Market.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class InventoryController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<PageResult<ListInventoryQueryDto>> List([FromQuery] ListInventoryQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("storeBookPairs")]
    public async Task<Dictionary<int,Dictionary<int, string>>> List(CancellationToken ct)
    {
        var result = await sender.Send(new GetStoresAndBooksPairsQuery(), ct);
        return result;
    }

    [HttpGet("store/{storeId:int}/book/{bookId:int}")]
    public async Task<GetInventoryByIdQueryDto> GetById(int storeId,int bookId, CancellationToken ct)
    {
        var category = await sender.Send(new GetInventoryByIdQuery { StoreId = storeId, BookId = bookId }, ct);
        return category; // if NotFoundException -> 404 via middleware
    }

    [HttpPost]

    public async Task<ActionResult<Unit>> CreateInventory(CreateInventoryCommand command, CancellationToken ct)
    {
        return await sender.Send(command, ct);
    }

    [HttpPut("store/{storeId:int}/book/{bookId:int}")]

    public async Task UpdatInventory(int storeId, int bookId, UpdateInventoryCommand command, CancellationToken ct)
    {
        command.StoreId = storeId;
        command.BookId = bookId;
        await sender.Send(command, ct);
    }

    [HttpDelete("store/{storeId:int}/book/{bookId:int}")]
    public async Task<IActionResult> DeleteInventory(int storeId, int bookId, CancellationToken ct)
    {
        await sender.Send(new DeleteInventoryCommand { StoreId = storeId, BookId = bookId }, ct);
        return NoContent();
    }
}
