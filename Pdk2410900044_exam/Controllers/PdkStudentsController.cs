
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pdk2410900044_exam.Models;

public class PdkStudentsController : Controller
{
    private readonly PdkStudent2410900044DbContext _context;

    public PdkStudentsController(PdkStudent2410900044DbContext context)
    {
        _context = context;
    }

    // GET: PDKSTUDENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.PdkStudents.ToListAsync());
    }

    // GET: PDKSTUDENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pdkstudent = await _context.PdkStudents
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pdkstudent == null)
        {
            return NotFound();
        }

        return View(pdkstudent);
    }

    // GET: PDKSTUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PDKSTUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,PdkName,PdkGender,PdkBirthDay,PdkEmail,PdkPhone,PdkActive")] PdkStudent pdkstudent)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pdkstudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(pdkstudent);
    }

    // GET: PDKSTUDENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pdkstudent = await _context.PdkStudents.FindAsync(id);
        if (pdkstudent == null)
        {
            return NotFound();
        }
        return View(pdkstudent);
    }

    // POST: PDKSTUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,PdkName,PdkGender,PdkBirthDay,PdkEmail,PdkPhone,PdkActive")] PdkStudent pdkstudent)
    {
        if (id != pdkstudent.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pdkstudent);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdkStudentExists(pdkstudent.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(pdkstudent);
    }

    // GET: PDKSTUDENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pdkstudent = await _context.PdkStudents
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pdkstudent == null)
        {
            return NotFound();
        }

        return View(pdkstudent);
    }

    // POST: PDKSTUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var pdkstudent = await _context.PdkStudents.FindAsync(id);
        if (pdkstudent != null)
        {
            _context.PdkStudents.Remove(pdkstudent);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PdkStudentExists(int? id)
    {
        return _context.PdkStudents.Any(e => e.Id == id);
    }
}
