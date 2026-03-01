using Market.Application.Modules.Catalog.Adresses.Commands.Create;
using Market.Application.Modules.Catalog.Adresses.Commands.Delete;
using Market.Application.Modules.Catalog.Adresses.Commands.Update;
using Market.Application.Modules.Catalog.Adresses.Queries.GetById;
using Market.Application.Modules.Catalog.Adresses.Queries.List;
using Market.Application.Modules.Shopping.ShippingMethods.Queries.List;
using Market.Application.Modules.Users.Commands.UpdateMyProfile;
using Market.Application.Modules.Users.Queries.GetById;
using Market.Application.Modules.Users.Queries.GetUserAddress;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ShippingMethodsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetShippingMethods(CancellationToken ct)
    {
        var result = await sender.Send(new ListShippingMethodsQuery(), ct);
        return Ok(result);
    }
}
