
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
  public class StudiosController : Controller
  {
    private readonly MvcMovieContext _context;
    public StudiosController(MvcMovieContext context)
    {
      _context = context;
    }
    public async Task<IActionResult> Index()
    {
      var studios = from s in _context.Studio select s;

      var studioView = new StudioViewModel()
      {
        Studios = studios.ToList()
      };

      return View(studioView);
    }


    public IActionResult Create()
    {
      return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name")] Studio studio)
    {
      if (ModelState.IsValid)
      {
        Console.WriteLine("ModelState is valid");
        _context.Add(studio);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View(studio);
    }

    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var studio = await _context.Studio
          .FirstOrDefaultAsync(m => m.StudioID == id);
      if (studio == null)
      {
        return NotFound();
      }

      return View(studio);
    }

    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var studio = await _context.Studio.FindAsync(id);

      if (studio == null)
      {
        return NotFound();
      }


      return View(studio);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int StudioID, [Bind("StudioID,Name")] Studio studio)
    {
      if (StudioID != studio.StudioID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(studio);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!StudioExists((int)studio.StudioID))
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

      return View(studio);
    }

    private bool StudioExists(int id)
    {
      return _context.Studio.Any(e => e.StudioID == id);
    }
    // GET: Studio/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var studio = await _context.Studio
          .FirstOrDefaultAsync(m => m.StudioID == id);
      if (studio == null)
      {
        return NotFound();
      }

      return View(studio);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var studio = await _context.Studio.FindAsync(id);
      _context.Studio.Remove(studio);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }


  }

}

