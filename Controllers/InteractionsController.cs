using CornerstoneCRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornerstoneCRM.Controllers;

public class InteractionsController : Controller
{
    private readonly IInteractionService _service;

    public InteractionsController(IInteractionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Log(Guid relatedEntityId, string relatedEntityType, string type, string notes)
    {
        await _service.LogInteraction(relatedEntityId, relatedEntityType, type, notes);
        return RedirectToAction("Details", relatedEntityType == "Case" ? "Cases" : "Constituents", new { id = relatedEntityId });
    }
}
