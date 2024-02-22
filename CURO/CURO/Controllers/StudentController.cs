using CURO.DataBaesContext;
using CURO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CURO.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbcontext _dbcontext;

        public StudentController(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _dbcontext.Set<Student>().AsNoTracking().ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CeratForm(int id)
        {
            if (id == 0) {  return View(new Student()); }
            else
            {
                var data = await _dbcontext.Set<Student>().FindAsync(id);
                return View(data);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CeratForm(int id,Student student)
        {
            if (id == 0)
            {
                if(ModelState.IsValid)
                {
                    await _dbcontext.Set<Student>().AddRangeAsync(student);

                  _dbcontext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                _dbcontext.Set<Student>().Update(student);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var data = await _dbcontext.Set<Student>().FindAsync(id);
                if(data != null)
                {
                    _dbcontext.Set<Student>().Remove(data);
                    _dbcontext.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Ditelis(int id)
        {
            var data = await _dbcontext.Set<Student>().FindAsync(id);

            return View(data);
        }

    }
}
