using CornerstoneCRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornerstoneCRM.Controllers;

public class CasesController : Controller
{
    private readonly ICaseService _service;

    public CasesController(ICaseService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var cases = await _service.GetCases();
        return View(cases);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var caseEntity = await _service.GetCase(id);
        if (caseEntity is null) return NotFound();
        return View(caseEntity);
    }

    [HttpPost]
    public async Task<IActionResult> AdvanceStatus(Guid id, string newStatus)
    {
        await _service.AdvanceCaseStatus(id, newStatus);
        return RedirectToAction(nameof(Details), new { id });
    }
}
