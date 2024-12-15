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

    // Afficher uniquement les enseignants
    public async Task<IActionResult> Index()
    {
        var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
        return View(teachers);
    }

    // Ajouter un enseignant
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Teacher teacher)
    {
        if (!ModelState.IsValid) return View();

        var result = await _userManager.CreateAsync(teacher, "DefaultPassword123!");
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(teacher, "Teacher");
            return RedirectToAction("Index");
        }

        return View();
    }

    // Afficher les détails d'un enseignant
    public async Task<IActionResult> ShowDetails(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id);
        if (teacher == null) return NotFound();
        return View(teacher);
    }

    // Modifier un enseignant
    [HttpGet]
    public async Task<IActionResult> Update(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id);
        if (teacher == null) return NotFound();
        return View(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> Update(string id, Teacher teacher)
    {
        if (id != teacher.Id) return NotFound();

        var existingTeacher = await _userManager.FindByIdAsync(id);
        if (existingTeacher == null) return NotFound();

        existingTeacher.Firstname = teacher.Firstname;
        existingTeacher.Lastname = teacher.Lastname;
        existingTeacher.PersonalWebSite = teacher.PersonalWebSite;

        var result = await _userManager.UpdateAsync(existingTeacher);
        if (result.Succeeded) return RedirectToAction("Index");

        return View(teacher);
    }

    // Supprimer un enseignant
    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id);
        if (teacher == null) return NotFound();
        return View(teacher);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id);
        if (teacher == null) return NotFound();

        var result = await _userManager.DeleteAsync(teacher);
        return RedirectToAction("Index");
    }
}
