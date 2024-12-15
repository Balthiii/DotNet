using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Data;
using Microsoft.EntityFrameworkCore;

public class EventsController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Events
    public async Task<IActionResult> Index()
    {
        return View(await _context.Events.ToListAsync());
    }

    // GET: Events/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem == null) return NotFound();
        return View(eventItem);
    }

    // GET: Events/Create
    [Authorize(Policy = "IsTeacher")]
    public IActionResult Create() => View();

    // POST: Events/Create
    [HttpPost, ValidateAntiForgeryToken, Authorize(Policy = "IsTeacher")]
    public async Task<IActionResult> Create(Event eventItem)
    {
        _context.Add(eventItem);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Events/Edit/id
    [Authorize(Policy = "IsTeacher")]
    public async Task<IActionResult> Edit(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem == null) return NotFound();
        return View(eventItem);
    }

    // POST: Events/Edit/5
    [HttpPost, ValidateAntiForgeryToken, Authorize(Policy = "IsTeacher")]
    public async Task<IActionResult> Edit(int id, Event eventItem)
    {
        if (id != eventItem.Id) return NotFound();

        _context.Update(eventItem);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Events/Delete/id
    [Authorize(Policy = "IsTeacher")]
    public async Task<IActionResult> Delete(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem == null) return NotFound();
        return View(eventItem);
    }

    // POST: Events/Delete/id
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken, Authorize(Policy = "IsTeacher")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);
        _context.Events.Remove(eventItem);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
