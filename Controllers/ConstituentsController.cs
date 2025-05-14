using CornerstoneCRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CornerstoneCRM.Controllers;

public class ConstituentsController : Controller
{
    private readonly IConstituentService _service;

    public ConstituentsController(IConstituentService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index(string query = "")
    {
        var constituents = await _service.SearchConstituents(query ?? "");
        return View(constituents);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var constituent = await _service.GetConstituent(id);
        if (constituent is null) return NotFound();
        return View(constituent);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(string type, string name, string email, string phone, string address)
    {
        await _service.RegisterConstituent(type, name, email, phone, address);
        return RedirectToAction(nameof(Index));
    }
}
