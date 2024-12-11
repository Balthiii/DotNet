using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;

public class TeacherController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeacherController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Afficher la liste des enseignants depuis la base de données
    public IActionResult Index()
    {
        // Récupérer tous les enseignants depuis la base de données
        var teachers = _context.Teachers.ToList();
        return View(teachers);  // Passer la liste des enseignants à la vue
    }

    // Ajouter un Teacher
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Teacher teacher)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _context.Teachers.Add(teacher);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // Afficher les détails d'un Teacher
    public IActionResult ShowDetails(int id)
    {
        // Récupérer un enseignant spécifique par ID depuis la base de données
        var teacher = _context.Teachers.Find(id);
        if (teacher == null)
        {
            return NotFound();  // Si l'enseignant n'est pas trouvé
        }
        return View(teacher);
    }

    // Modifier un Teacher
    [HttpGet]
    public IActionResult Update(int id)
    {
        var teacher = _context.Teachers.Find(id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }


    [HttpPost]
    public IActionResult Update(int id, Teacher teacher)
    {
        if (id != teacher.Id)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return View(teacher);
        }
        var existingTeacher = _context.Teachers.Find(id);
        if (existingTeacher == null)
        {
            return NotFound();
        }
        existingTeacher.Firstname = teacher.Firstname;
        existingTeacher.Lastname = teacher.Lastname;
        _context.SaveChanges();

        // Rediriger vers la page d'index
        return RedirectToAction("Index");
    }



    [HttpGet]
    public IActionResult Delete(int id)
    {
        var teacher = _context.Teachers.Find(id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var teacher = _context.Teachers.Find(id);
        if (teacher == null)
        {
            return NotFound();
        }

        _context.Teachers.Remove(teacher);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}
