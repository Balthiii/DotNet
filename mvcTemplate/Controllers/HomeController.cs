using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string title, DateTime? date, string sortBy = "date", string sortOrder = "asc")
        {
            var eventsQuery = _context.Events.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                eventsQuery = eventsQuery.Where(e => e.Title.ToLower().Contains(title.ToLower()));
            }

            if (date.HasValue)
            {
                eventsQuery = eventsQuery.Where(e => e.EventDate.Date == date.Value.Date);
            }

            eventsQuery = eventsQuery.Where(e => e.EventDate > DateTime.Now);

            switch (sortBy.ToLower())
            {
                case "title":
                    eventsQuery = sortOrder == "asc" ? eventsQuery.OrderBy(e => e.Title) : eventsQuery.OrderByDescending(e => e.Title);
                    break;

                case "date":
                default:
                    eventsQuery = sortOrder == "asc" ? eventsQuery.OrderBy(e => e.EventDate) : eventsQuery.OrderByDescending(e => e.EventDate);
                    break;
            }

            var upcomingEvents = await eventsQuery.ToListAsync();

            return View(upcomingEvents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
