using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Microsoft.AspNetCore.Identity;

public class TeacherController : Controller
{
    private readonly UserManager<Teacher> _userManager;

    public TeacherController(UserManager<Teacher> userManager)
    {
        _userManager = userManager;
    }

    // Afficher la liste des enseignants depuis la base de données
    public IActionResult Index()
    {
        var teachers = _userManager.Users.ToList();
        return View(teachers);
    }

    // Ajouter un Teacher
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Teacher teacher)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var result = await _userManager.CreateAsync(teacher, "DefaultPassword123!");
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View();
    }

    // Afficher les détails d'un Teacher
    public async Task<IActionResult> ShowDetails(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }
        return View(teacher);
    }

    // Modifier un Teacher
    [HttpGet]
    public async Task<IActionResult> Update(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> Update(string id, Teacher teacher)
    {
        if (id != teacher.Id)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return View(teacher);
        }

        var existingTeacher = await _userManager.FindByIdAsync(id);
        if (existingTeacher == null)
        {
            return NotFound();
        }

        // Mise à jour des informations de l'enseignant
        existingTeacher.Firstname = teacher.Firstname;
        existingTeacher.Lastname = teacher.Lastname;
        existingTeacher.PersonalWebSite = teacher.PersonalWebSite;

        var result = await _userManager.UpdateAsync(existingTeacher);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(teacher);
    }

    // Supprimer un Teacher
    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(teacher);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return RedirectToAction("Index");
    }
}
