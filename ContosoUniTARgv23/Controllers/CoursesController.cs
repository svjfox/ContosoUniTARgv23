using ContosoUniTARgv23.Data;
using ContosoUniTARgv23.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;




namespace ContosoUniTARgv23.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();



            return View(courses);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);

        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseId == id);


            if (course == null)
            {
                return NotFound();
            }
            PopulateDepartmrntDropDownList(course.DepartmentId);
            return View(course);
        }

        [HttpPost, ActionName("EditPosting")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (!await TryUpdateModelAsync<Course>(
                courseToUpdate,
                "",
                c => c.Credits, c => c.DepartmentId, c => c.Title))
            {
                try
                {
                    _context.Update(courseToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            PopulateDepartmrntDropDownList(courseToUpdate.DepartmentId);
            return View(courseToUpdate);
        }
        private void PopulateDepartmrntDropDownList(object selectedDepartment = null)
        {
            var departmentQuery = from d in _context.Departments
                                  orderby d.Name
                                  select d;
            ViewBag.DepartmentId = new SelectList(departmentQuery.AsNoTracking(), "DepartmentId", "Name", selectedDepartment);
        }


        public async Task<IActionResult> Delete(int? id)
        {
          if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                  .Include(c => c.Department)
                  .AsNoTracking()
                  .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'SchoolContext' is null.");
            }
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            PopulateDepartmrntDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Credits,DepartmentId,Title")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(course);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            PopulateDepartmrntDropDownList(course.DepartmentId);
            return View(course);
        }
    }

}
